Imports System.Diagnostics
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.UI
' ...


Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' A path to export a report.
        Dim reportPath As String = "c:\\Test.pdf"

        ' Create a report instance.
        Dim report As New XtraReport1()

        ' Get its PDF export options.
        Dim pdfOptions As PdfExportOptions = report.ExportOptions.Pdf

        ' Set PDF-specific export options.
        pdfOptions.Compressed = True
        pdfOptions.ImageQuality = PdfJpegImageQuality.Low
        pdfOptions.NeverEmbeddedFonts = "Tahoma;Courier New"
        pdfOptions.DocumentOptions.Application = "Test Application"
        pdfOptions.DocumentOptions.Author = "DX Documentation Team"
        pdfOptions.DocumentOptions.Keywords = "XtraReports, XtraPrinting"
        pdfOptions.DocumentOptions.Subject = "Test Subject"
        pdfOptions.DocumentOptions.Title = "Test Title"

        ' Set the pages to be exported.
        pdfOptions.PageRange = "1, 3-5"

        ' Export the report to PDF.
        report.ExportToPdf(reportPath)

        ' Show the result.
        StartProcess(reportPath)
    End Sub

    ' Use this method if you want to automaically open
    ' the created PDF file in the default program.
    Public Sub StartProcess(ByVal path As String)
        Dim process As New Process()
        Try
            process.StartInfo.FileName = path
            process.Start()
            process.WaitForInputIdle()
        Catch
        End Try
    End Sub
End Class
