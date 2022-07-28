﻿using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dar_Formato_Archivos_Edi.Forms_secundarios
{
    public partial class CorreosEDI : Form
    {
        Microsoft.Office.Interop.Outlook.Application outlookApp = new Microsoft.Office.Interop.Outlook.Application();
        NameSpace outlookNS = null;
        MAPIFolder mails = null;
        List<Document> listado_correos = new List<Document> ();

        public CorreosEDI()
        {
            InitializeComponent();
            outlookNS = outlookApp.GetNamespace("MAPI");
            //outlookNS.Logon("1", "1", null, true);
            mails = outlookNS.GetDefaultFolder(OlDefaultFolders.olFolderInbox);

            //ObtenerCorreosEdi();

            listado_correos = ObtenerCorreosEdi();
            listbox_Emails.DataSource = listado_correos.Select(vl => vl.Email_Subject + " - " + vl.ReceivedTime.ToString() + " - " + vl.List_Documents.Count.ToString()).ToList();
        }

        public  List<Document> ObtenerCorreosEdi()
        {
            string folder_ErroresEdi = "Errores EDI Transplace";
            try
            {
                //var carpetas = outlookNS.Folders["desarrollohg03@hgtransportaciones.com"].Folders.Count;
                //var listadoEmails = outlookNS.Folders[folder_ErroresEdi].Items;
                List<Document> Emails_documents = new List<Document>();
                var listadoEmails = mails.Folders[folder_ErroresEdi].Items;

                foreach (object obj in listadoEmails)
                {
                    MailItem Mail = obj as MailItem;

                    switch (Mail.Subject)
                    {
                        case "RV: GISP: Transplace TMS Carrier Shipment Status Errors  (HGTM/666A)":
                            Emails_documents.Add(ObtenerInformacionCorreo_ShipmentStatusErrors(obj));
                        break;
                    }
                }

                return Emails_documents;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return null;
            }            
        }

        public static Document ObtenerInformacionCorreo_ShipmentStatusErrors(object MailsObj)
        {
            MailItem Mail = MailsObj as MailItem;
            Mail.BodyFormat = OlBodyFormat.olFormatPlain;

            Document document = new Document() { ReceivedTime = Mail.ReceivedTime, Email_Subject = Mail.Subject, List_Documents = new List<Document_Ind>() };
            Document_Ind document_ind = new Document_Ind();

            string body = Mail.Body;
            string[] arrDocuments = SepararDocumentosErrores(body).Where(vl => vl != "").ToArray();

            for (int i = 0; i < arrDocuments.Length; i++)
            {
                document_ind = new Document_Ind() { Id = "Document " + (i + 1).ToString() };

                string[] arrDocuments_sections = arrDocuments[i].Trim().Split('\n').Where(vl => vl != "").ToArray();

                for (int j = 0; j < arrDocuments_sections.Length; j++)
                {
                    if (arrDocuments_sections[j].Contains("DOCUMENT_TYPE")) document_ind.DocumentType = arrDocuments_sections[j].Substring(arrDocuments_sections[j].IndexOf("-->") + 3, arrDocuments_sections[j].Length - (arrDocuments_sections[j].IndexOf("-->") + 3)).Trim();
                    if (arrDocuments_sections[j].Contains("GS_CONTROL_NUMBER")) document_ind.GS_Control_Number = arrDocuments_sections[j].Substring(arrDocuments_sections[j].IndexOf("-->") + 3, arrDocuments_sections[j].Length - (arrDocuments_sections[j].IndexOf("-->") + 3)).Trim();
                    if (arrDocuments_sections[j].Contains("REFERENCE")) document_ind.Reference = arrDocuments_sections[j].Substring(arrDocuments_sections[j].IndexOf("-->") + 3, arrDocuments_sections[j].Length - (arrDocuments_sections[j].IndexOf("-->") + 3)).Trim();
                    if (arrDocuments_sections[j].Contains("STATUS CODE")) document_ind.Status_Code = arrDocuments_sections[j].Substring(arrDocuments_sections[j].IndexOf("-->") + 3, arrDocuments_sections[j].Length - (arrDocuments_sections[j].IndexOf("-->") + 3)).Trim();
                    if (arrDocuments_sections[j].Contains("ERROR_CODE")) document_ind.Error_Code = arrDocuments_sections[j].Substring(arrDocuments_sections[j].IndexOf("-->") + 3, arrDocuments_sections[j].Length - (arrDocuments_sections[j].IndexOf("-->") + 3)).Trim();
                    if (arrDocuments_sections[j].Contains("ERROR_MESSAGE")) document_ind.Error_Message = arrDocuments_sections[j].Substring(arrDocuments_sections[j].IndexOf("-->") + 3, arrDocuments_sections[j].Length - (arrDocuments_sections[j].IndexOf("-->") + 3)).Trim();
                    if (arrDocuments_sections[j].Contains("ERROR_DESCRIPTION")) document_ind.Error_Description = arrDocuments_sections[j].Substring(arrDocuments_sections[j].IndexOf("-->") + 3, arrDocuments_sections[j].Length - (arrDocuments_sections[j].IndexOf("-->") + 3)).Trim();
                }
                document.List_Documents.Add(document_ind);
            }

            return document;
        }

        public static string[] SepararDocumentosErrores(string body)
        {
            int body_inicio = body.IndexOf("========== DOCUMENT 1 ==========");
            int body_fin = body.IndexOf("***If you have any questions");
            int cont = 1;

            string body_info = body.Substring(body_inicio, body_fin - body_inicio);
            bool ExisteDocumento = true;

            while (ExisteDocumento)
            {
                string Document_Titulo = "========== DOCUMENT " + cont.ToString() + " ==========";
                if (body_info.Contains(Document_Titulo))
                {
                    body_info = body_info.Replace(Document_Titulo, "@");
                    cont++;
                }
                else
                {
                    ExisteDocumento = false;
                }
            }

            return body_info.Split('@');
        }

        public class Document
        {
            public string Email_Subject { get; set; }
            public DateTime ReceivedTime { get; set; }
            public List<Document_Ind> List_Documents { get; set; }
        }

        public class Document_Ind
        {
            public string Id { get; set; }
            public string DocumentType { get; set; }
            public string GS_Control_Number { get; set; }
            public string Reference { get; set; }
            public string Status_Code { get; set; }
            public string Error_Code { get; set; }
            public string Error_Message { get; set; }
            public string Error_Description { get; set; }
        }

        private void listbox_Emails_SelectedIndexChanged(object sender, EventArgs e)
        {
            DTG_EmailDetalles.DataSource = null;

            DTG_EmailDetalles.DataSource = listado_correos[listbox_Emails.SelectedIndex].List_Documents;

            //for (int i = 0; i < listado_correos[listbox_Emails.SelectedIndex].List_Documents.Count ; i++)
            //{
            //    string Id = listado_correos[listbox_Emails.SelectedIndex].List_Documents[i].Id;
            //    string DocumentType = listado_correos[listbox_Emails.SelectedIndex].List_Documents[i].DocumentType;
            //    string ControlNumber = listado_correos[listbox_Emails.SelectedIndex].List_Documents[i].GS_Control_Number;
            //    string ErrorCode = listado_correos[listbox_Emails.SelectedIndex].List_Documents[i].Error_Code;
            //    string ErrorDescription = listado_correos[listbox_Emails.SelectedIndex].List_Documents[i].Error_Description;
            //    string Shipment = listado_correos[listbox_Emails.SelectedIndex].List_Documents[i].Reference;
            //    string StatusCode = listado_correos[listbox_Emails.SelectedIndex].List_Documents[i].Status_Code;

            //    string Formato_Correo = $@"
            //        {Id} 
            //        {DocumentType}
            //        {ControlNumber}
            //        {ErrorCode}
            //        {ErrorDescription}
            //        {Shipment}
            //        {StatusCode}";

            //    listbox_EmailDetalles.Items.Add(Formato_Correo);
            //}
        }
    }
}
