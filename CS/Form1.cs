using System;
using System.Windows.Forms;

using System.Diagnostics;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
// ...

namespace ExportToPdfCS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // A path to export a report.
            string reportPath = "c:\\Test.pdf";

            // Create a report instance.
            XtraReport1 report = new XtraReport1();

            // Get its PDF export options.
            PdfExportOptions pdfOptions = report.ExportOptions.Pdf;

            // Set PDF-specific export options.
            pdfOptions.Compressed = true;
            pdfOptions.ImageQuality = PdfJpegImageQuality.Low;
            pdfOptions.NeverEmbeddedFonts = "Tahoma;Courier New";
            pdfOptions.DocumentOptions.Application = "Test Application";
            pdfOptions.DocumentOptions.Author = "DX Documentation Team";
            pdfOptions.DocumentOptions.Keywords = "XtraReports, XtraPrinting";
            pdfOptions.DocumentOptions.Subject = "Test Subject";
            pdfOptions.DocumentOptions.Title = "Test Title";

            // Set the pages to be exported.
            pdfOptions.PageRange = "1, 3-5";

            // Export the report to PDF.
            report.ExportToPdf(reportPath);

            // Show the result.
            StartProcess(reportPath);
        }

        // Use this method if you want to automaically open
        // the created PDF file in the default program.
        public void StartProcess(string path)
        {
            Process process = new Process();
            try
            {
                process.StartInfo.FileName = path;
                process.Start();
                process.WaitForInputIdle();
            }
            catch { }
        }
    }
}