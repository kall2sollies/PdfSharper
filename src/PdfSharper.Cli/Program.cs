using System;
using System.IO;
using iText.Kernel.Pdf;

namespace PdfSharper.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            // env params
            var pdfDirectory = "D:\\Documents\\Dev\\PdfSharper\\docs\\jazz-books";

            // params to be automated from CSV reading
            var title = "Lush Life";
            var fileName = "New Real Book I";
            var fileNameWithExt = $"{fileName}.pdf";
            var page = 212;
            var length = 2;
            var filePath = Path.Combine(pdfDirectory, fileNameWithExt);

            // output params
            var outputFileName = $"{title} ({fileName})";
            var outputFileNameWithExt = $"{outputFileName}.pdf";
            var outputDirectory = Path.Combine(pdfDirectory, "slices");
            var outputPath = Path.Combine(outputDirectory, outputFileNameWithExt);
            if (!Directory.Exists(outputDirectory)) Directory.CreateDirectory(outputDirectory);
            if (File.Exists(outputPath)) File.Delete(outputPath);

            // Open document
            var pdfDocument = new PdfDocument(new PdfReader(filePath));

            // Write selected range
            var outPdfDocument = new PdfDocument(new PdfWriter(outputPath));
            pdfDocument.CopyPagesTo(page, page + length - 1, outPdfDocument);
            outPdfDocument.Close();
            pdfDocument.Close();
        }
    }
}
