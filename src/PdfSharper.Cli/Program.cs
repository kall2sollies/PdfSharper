using System;
using System.IO;
using System.Linq;
using Aspose.Pdf;

namespace PdfSharper.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            // env params
            var pdfDirectory = "D:\\Documents\\Dev\\PdfSharper\\docs\\jazz-books";

            // params to be automated from CSV reading
            var title = "Desafinado";
            var fileName = "New Real Book I";
            var fileNameWithExt = $"{fileName}.pdf";
            var page = 80;
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
            var pdfDocument = new Document(filePath);
            var startIndex = page - 1;
            var endIndex = page + length - 1;
            var outputDocument = new Document();
            var pagesToExtract = pdfDocument.Pages.Where(x => x.Number >= page).Take(length).ToList();
            outputDocument.Pages.Add(pagesToExtract);
            outputDocument.Save(outputPath);
        }
    }
}
