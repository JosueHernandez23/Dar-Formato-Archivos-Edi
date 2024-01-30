using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using Dar_Formato_Archivos_Edi.Forms_secundarios;
using Newtonsoft.Json;
using static Dar_Formato_Archivos_Edi.Form1;

namespace Dar_Formato_Archivos_Edi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ConfigButtonEfects();
        }

        #region Eventos Form1
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string segmento = txtSegmento.Text,
                       elemento = txtElemento.Text;

                using (OpenFileDialog Cargar_archivo = new OpenFileDialog())
                {
                    Cargar_archivo.InitialDirectory = "c:\\Escritorio";
                    Cargar_archivo.Filter = "txt files (*.txt)|*.txt|All files (*.edi)|*.edi";
                    Cargar_archivo.FilterIndex = 2;
                    //Cargar_archivo.RestoreDirectory = true;

                    if (Cargar_archivo.ShowDialog() == DialogResult.OK)
                    {
                        // Obtenemos el nombre del archivo
                        txtNombreArchivo.Text = Cargar_archivo.SafeFileName;

                        var fileStream = Cargar_archivo.OpenFile();

                        using (StreamReader reader = new StreamReader(fileStream))
                        {
                            string textoArchivo = reader.ReadToEnd();

                            if (rbHabilitar.Checked)
                            {
                                segmento = ObtenerSegmento(textoArchivo);
                                elemento = ObtenerElemento(textoArchivo);

                                if (segmento == "")
                                    segmento = txtSegmento.Text;
                                if (elemento == "")
                                    elemento = txtElemento.Text;
                            }

                            if (rbDeshabilitar.Checked)
                            {
                                if (segmento == "")
                                    segmento = ObtenerSegmento(textoArchivo);
                                if (elemento == "")
                                    elemento = ObtenerElemento(textoArchivo);
                            }

                            TxtFormatoTexto.Text = DarFormatoTexto(textoArchivo, segmento, elemento);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error: \n\n" + ex.Message);
            }
        }

        private void btnTexto_Click(object sender, EventArgs e)
        {
            try
            {
                string textoArchivo = TxtFormatoTexto.Text;
                string segmento = txtSegmento.Text;
                string elemento = txtElemento.Text;
                txtNombreArchivo.Text = "";

                if (rbHabilitar.Checked)
                {
                    segmento = ObtenerSegmento(textoArchivo);
                    elemento = ObtenerElemento(textoArchivo);

                    if (segmento == "")
                        segmento = txtSegmento.Text;
                    if (elemento == "")
                        elemento = txtElemento.Text;
                }

                if (rbDeshabilitar.Checked)
                {
                    if (segmento == "")
                        segmento = ObtenerSegmento(textoArchivo);
                    if (elemento == "")
                        elemento = ObtenerElemento(textoArchivo);
                }

                TxtFormatoTexto.Text = DarFormatoTexto(textoArchivo, segmento, elemento);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error: \n\n" + ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombreArchivo.Text = "";
            TxtFormatoTexto.Text = "";
        }

        private void Form1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                var archivo = (Array)e.Data.GetData(DataFormats.FileDrop);

                string rutaArchivo = archivo.GetValue(0).ToString();

                FileInfo fileInfo = new FileInfo(rutaArchivo);

                if (fileInfo.Extension.ToUpper() == ".TXT" || fileInfo.Extension.ToUpper() == ".EDI")
                {
                    FileStream filestream = fileInfo.OpenRead();
                    StreamReader streamreader = new StreamReader(filestream);

                    string textoArchivo = streamreader.ReadToEnd();
                    string segmento = txtSegmento.Text;
                    string elemento = txtElemento.Text;
                    txtNombreArchivo.Text = "";
                    filestream.Close();
                    filestream.Dispose();

                    if (rbHabilitar.Checked)
                    {
                        segmento = ObtenerSegmento(textoArchivo);
                        elemento = ObtenerElemento(textoArchivo);

                        if (segmento == "")
                            segmento = txtSegmento.Text;
                        if (elemento == "")
                            elemento = txtElemento.Text;
                    }

                    if (rbDeshabilitar.Checked)
                    {
                        if (segmento == "")
                            segmento = ObtenerSegmento(textoArchivo);
                        if (elemento == "")
                            elemento = ObtenerElemento(textoArchivo);
                    }

                    txtNombreArchivo.Text = fileInfo.Name;
                    TxtFormatoTexto.Text = DarFormatoTexto(textoArchivo, segmento, elemento);
                }
                else
                {
                    MessageBox.Show("No se permiten archivos con esta extension: " + fileInfo.Extension);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error: \n\n" + ex.Message);
            }
        }

        private string DarFormatoTexto(string textoArchivo, string segmento, string elemento)
        {
            string[] SeparadorSegmento = textoArchivo.Split(Convert.ToChar(segmento)).Where(s => s != "\r\n" && s != "").ToArray();
            string[] SeparadorElemento = new string[0];
            string textoFormato = ""; //textoArchivo.Replace(segmento, segmento + "\n");

            foreach (string BloqueSegmento in SeparadorSegmento)
            {
                textoFormato += BloqueSegmento.Replace("\r\n", "").Replace("\n", "") + segmento + "\n";
            }

            return textoFormato.TrimEnd();
        }

        private string ObtenerSegmento(string textoArchivo)
        {
            try
            {
                int lenghtTexto = textoArchivo.Trim().Length;

                string valorSegmento = (textoArchivo.Substring(lenghtTexto - 1, 1)).Trim();

                return valorSegmento;
            }

            catch
            {
                return "";
            }
        }

        private string ObtenerElemento(string textoArchivo)
        {
            //"*|"
            try
            {
                //int posicionElemento = textoArchivo.IndexOf("|");

                int posicionElemento = textoArchivo.Trim().IndexOf("ISA");

                string valorElemento = textoArchivo.Substring(posicionElemento + 3, 1).Trim();

                return valorElemento;
            }

            catch
            {
                return "";
            }

        }

        private void btnGenerarArchivo_Click(object sender, EventArgs e)
        {
            string contenido = TxtFormatoTexto.Text;

            if (string.IsNullOrEmpty(contenido.Trim()))
            {
                MessageBox.Show("Ingresar contenido de archivo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                string segmento = "";
                string elemento = "";
                string contenidoFormato = "";

                if (rbHabilitar.Checked)
                {
                    segmento = ObtenerSegmento(contenido);
                    elemento = ObtenerElemento(contenido);

                    if (segmento == "")
                        segmento = txtSegmento.Text;
                    if (elemento == "")
                        elemento = txtElemento.Text;
                }

                if (rbDeshabilitar.Checked)
                {
                    if (segmento == "")
                        segmento = ObtenerSegmento(contenido);
                    if (elemento == "")
                        elemento = ObtenerElemento(contenido);
                }

                contenidoFormato = DarFormatoTexto(contenido, segmento, elemento);

                using (SaveFileDialog guardar_archivo = new SaveFileDialog())
                {
                    //guardar_archivo.
                }
            }
        }

        #endregion

        #region Acceso otros forms

        private void btnListadoSegmentos_Click(object sender, EventArgs e)
        {
            //new Listado_Segmentos().Show();
            //this.Hide();

            var f = new Listado_Segmentos();
            f.Show();
        }

        private void btnGenerarEdi_Click(object sender, EventArgs e)
        {
            var f = new GenerarEdi();
            f.Show();
        }

        private void btnCorreosEdi_Click(object sender, EventArgs e)
        {
            var f = new CorreosEDI();
            f.Show();
        }

        private void btnEdiPedidos_Click(object sender, EventArgs e)
        {
            var f = new EdiPedidos(TxtFormatoTexto, txtNombreArchivo, btnTexto);
            f.Show();
        }

        private void btnReporteEventos_Click(object sender, EventArgs e)
        {
            var f = new ReporteDeEventos();
            f.Show();
        }

        private void btnDirectorioSFTP_Click(object sender, EventArgs e)
        {
            var f = new Directorio_SFTP(TxtFormatoTexto, txtNombreArchivo);
            f.Show();
        }

        private void btnEstadistica_Click(object sender, EventArgs e)
        {
            var f = new Dashboard();
            f.Show();
        }

        private void btnEventoEdi_Click(object sender, EventArgs e)
        {
            var f = new EventosEdi();
            f.Show();
        }

        private void btnInfoCruce_Click(object sender, EventArgs e)
        {
            var f = new InfoCruce();
            f.Show();
        }

        #endregion

        #region Efecto Hover (Buttons)
        public void ConfigButtonEfects()
        {
            //var la =  Controls.Cast<Control>().ToList().Where(vl => vl.Text == "");
            //Button[] bb = Controls.OfType<Button>().ToArray();

            //Botones del menu
            List<Button> ArrButtons = groupBox2.Controls.OfType<Button>().ToList();
            //Botones para mostrar la informacion del texto
            ArrButtons.AddRange(tableLayoutPanel3.Controls.OfType<Button>().ToList());


            foreach (Button btn in ArrButtons)
            {
                btn.MouseEnter += HoverEnter;
                btn.MouseLeave += HoverLeave;
            }
        }

        public static void HoverEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.White;
            btn.ForeColor = Color.Black;
            btn.Cursor = Cursors.Hand;
        }

        public static void HoverLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.FromArgb(46, 51, 73);
            btn.ForeColor = Color.White;
        }

        #endregion

        #region otros procesos (desuso)
        public void ExtraerTextoPDF()
        {
            using (OpenFileDialog Cargar_archivo = new OpenFileDialog())
            {
                Cargar_archivo.InitialDirectory = "c:\\Escritorio";
                Cargar_archivo.Filter = "PDF (*.pdf)|*.pdf";
                Cargar_archivo.RestoreDirectory = true;

                if (Cargar_archivo.ShowDialog() == DialogResult.OK)
                {
                    string pattern = @"\A([0-9]{1,3})[ ]([a-zA-Z]*)[ ]([a-zA-Z]*)";
                    string pattern2 = @"[ ]([0-9]{1,3})[ ]([a-zA-Z]*)[ ]([a-zA-Z]*)";

                    PdfReader reader2 = new PdfReader((string)Cargar_archivo.FileName);
                    string strText = string.Empty;
                    string txtar = string.Empty;

                    int numeroPaginas = 0;
                    string[] lines;

                    numeroPaginas = reader2.NumberOfPages;

                    for (int page = 1; page <= numeroPaginas; page++)
                    {
                        iTextSharp.text.pdf.parser.ITextExtractionStrategy its = new iTextSharp.text.pdf.parser.LocationTextExtractionStrategy();
                        PdfReader reader = new PdfReader((string)Cargar_archivo.FileName);
                        String s = iTextSharp.text.pdf.parser.PdfTextExtractor.GetTextFromPage(reader, page, its);

                        s = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8,
                              Encoding.Default.GetBytes(s)));
                        lines = s.Split('\n');
                        //strText = strText + s;
                        txtar = txtar + s;

                        for (int i = 0; i < lines.Length; i++)
                        {
                            Match m = Regex.Match(lines[i], pattern);

                            if (m.Success)
                            {
                                if (lines[i].EndsWith(" "))
                                {
                                    lines[i] += lines[i + 2];
                                }


                                strText = strText + lines[i];
                                strText += "\n";
                            }

                            else if (Regex.Match(lines[i], pattern2).Success)
                            {
                                strText = strText + Regex.Match(lines[i], pattern2).Value.TrimStart();
                                strText += "\n";
                            }

                            else if ((lines[i].Length >= 1 && lines[i].Length <= 3 && !lines[i - 1].Contains("SEGMENTS USED") && !lines[i - 1].Contains(" 997") && !lines[i - 1].Contains(" 947")) && Regex.Match(lines[i], @"\A([0-9]{1,3})").Success)
                            {
                                strText = strText + Regex.Match(lines[i], @"\A([0-9]{1,3})").Value + " " + lines[i - 1];
                                strText += "\n";
                            }
                        }

                        strText += "\n ===================== PAGINA " + page.ToString() + " ===================== \n";

                        reader.Close();
                    }
                    reader2.Close();

                    var fileStream = Cargar_archivo.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        string textoArchivo = reader.ReadToEnd();
                    }
                }
            }
        }

        public void LeerJson()
        {
            using (OpenFileDialog Cargar_archivo = new OpenFileDialog())
            {
                Cargar_archivo.InitialDirectory = "c:\\Escritorio";
                Cargar_archivo.Filter = "TXT (*.txt)|*.txt";
                Cargar_archivo.RestoreDirectory = true;

                if (Cargar_archivo.ShowDialog() == DialogResult.OK)
                {
                    var fileStream = Cargar_archivo.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        string textoArchivo = reader.ReadLine();
                        string nSeg = "";
                        bool CapturarSegmento = true;

                        List<Segmentos> Lista_Segmentos = new List<Segmentos>();
                        Segmentos segmentos = new Segmentos();

                        List<EdiCodes> Lista_EdiCodes = new List<EdiCodes>();
                        EdiCodes EdiCD = new EdiCodes();

                        while (textoArchivo != null)
                        {
                            if (textoArchivo.Trim().Length <= 4 && CapturarSegmento && textoArchivo != "")
                            {
                                segmentos = new Segmentos();
                                segmentos.Segmento = textoArchivo.Trim();
                                nSeg = segmentos.Segmento;
                            }

                            if (textoArchivo.StartsWith(nSeg) && nSeg != "" && CapturarSegmento)
                            {
                                // Ref     Code    Name                                             Req Rep   Min   Max   Type      

                                // ST1     143     TransactionSetIdentifierCode                     M   1     3     3     AN        
                                segmentos = new Segmentos();
                                string[] arrLinea = textoArchivo.Split(' ').Where(vl => vl != "").ToArray();

                                segmentos.Segmento = nSeg;
                                segmentos.Segmento_Ref = arrLinea[0];
                                segmentos.Code = Convert.ToInt32(arrLinea[1]);
                                segmentos.Name = arrLinea[2];
                                segmentos.Req = arrLinea[3];
                                segmentos.Rep = arrLinea[4];
                                segmentos.Min = Convert.ToInt32(arrLinea[5]);
                                segmentos.Max = Convert.ToInt32(arrLinea[6]);
                                segmentos.Type = arrLinea[7];

                                Lista_Segmentos.Add(segmentos);
                            }

                            if (!CapturarSegmento)
                            {
                                if (textoArchivo.Trim().Length <= 4 && textoArchivo != "" && !textoArchivo.Contains(","))
                                {
                                    EdiCD = new EdiCodes();
                                    EdiCD.Code = Convert.ToInt32(textoArchivo.Trim());
                                }

                                if (textoArchivo.Contains(","))
                                {
                                    string ConcatStrArray = "";

                                    while (textoArchivo != null && textoArchivo.Contains(","))
                                    {
                                        ConcatStrArray += textoArchivo + ",";
                                        textoArchivo = reader.ReadLine();
                                    }

                                    EdiCD.list_codes = ConcatStrArray.Trim().Split(',').Where(vl => vl != "").ToArray();
                                    Lista_EdiCodes.Add(EdiCD);
                                }
                            }

                            textoArchivo = reader.ReadLine();

                            if (textoArchivo != null && textoArchivo.Contains("                EDI CODES"))
                            {
                                CapturarSegmento = false;
                            }
                        }

                    }

                }
            }
        }

        public class Segmentos
        {
            public string Segmento { get; set; } = "";
            public string Segmento_Ref { get; set; }
            public int Code { get; set; }
            public string Name { get; set; }
            public string Req { get; set; }
            public string Rep { get; set; }
            public int Min { get; set; }
            public int Max { get; set; }
            public string Type { get; set; }
        }

        public class EdiCodes
        {
            public int Code { get; set; }
            public string[] list_codes { get; set; }
        }

        #endregion

    }
}