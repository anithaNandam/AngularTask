using DinkToPdf;
using DinkToPdf.Contracts;
using System;
//using System.Drawing;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.Text.RegularExpressions;
using SkiaSharp;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Geom;
using System.Text;
using iText.Kernel.Font;
using iText.Kernel.Colors;
using iText.IO.Font.Constants;
using iText.Kernel.Pdf.Action;
using iText.Kernel.Events;
using iText.IO.Image;
using iText.Kernel.Pdf.Annot;
using iText.Kernel.Pdf.Xobject;
using Microsoft.AspNetCore.Hosting;


namespace AngularTask.Models
{
    public class ContentService
    {
        private readonly IConverter _pdfConverter;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public ContentService(IConverter pdfConverter, IWebHostEnvironment webHostEnvironment)
        {
            _pdfConverter = pdfConverter;
            _webHostEnvironment = webHostEnvironment;
        }
     
        public async Task<byte[]> GeneratePdf(ContentItem contentItem, PageSize pageSize, float scale)
        {

            string headerText = "News";
            var eventHandler = new PdfHeaderFooterEventHandler(headerText, _webHostEnvironment);
            using var stream = new MemoryStream();
            var writer = new PdfWriter(stream);
            var pdfDocument = new PdfDocument(writer);            
            pdfDocument.AddEventHandler(PdfDocumentEvent.START_PAGE, eventHandler);
            PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            Color fontColor =  new DeviceRgb(0, 0, 255); // blue color // black
            var document = new Document(pdfDocument, iText.Kernel.Geom.PageSize.A4);
            //Paragraph header = new Paragraph("Header text")
            //   .SetFont(font)
            //   .SetFontColor(fontColor)
            //   .SetTextAlignment(TextAlignment.CENTER)
            //   .SetFontSize(14);
          
            //document.Add(header);
            var page = pdfDocument.AddNewPage();
            var canvas = new PdfCanvas(page);
            var action = PdfAction.CreateURI("https://www.ecssr.ae/en/ecssr-at-a-glance/");
            var annotation = new PdfLinkAnnotation(new Rectangle(36, 770, 36, 20))
    .SetAction(action)
    .SetBorder(new PdfArray(new[] { 0, 0, 0 }))
    //.SetHighlightMode(PdfAnnotation.HIGHLIGHT_INVERT)
    .SetTitle(new PdfString("Link to external"));
    //.SetOpenInNewWindow(true);
            page.AddAnnotation(annotation);
            canvas.BeginText();
            canvas.SetFontAndSize(font, 16);
            canvas.MoveText(36, 780);
            canvas.ShowText(contentItem.Title);
            canvas.SetColor(fontColor,true);
            canvas.EndText();
   
            Paragraph contentheaerr = new Paragraph(contentItem.Title)
               .SetTextAlignment(TextAlignment.CENTER)
               .SetMarginTop(100f);
               
            document.Add(contentheaerr);
            document.Add(new Paragraph(contentItem.Description).SetMarginTop(80f));
            // Scale the content on each page of the document
            for (int i = 1; i <= pdfDocument.GetNumberOfPages(); i++)
            {
                var page2 = pdfDocument.GetPage(i);              
               var canvas2 = new PdfCanvas(page2);               
                // Scale the content
                canvas2.SaveState();
                canvas2.ConcatMatrix(scale, 0, 0, scale, 0, 0);
                canvas2.RestoreState();
            }
            document.Close();
            return stream.ToArray();
        }
        public byte[] GenerateMobileImage(ContentItem contentItem,float scale, string headerText="content Header", string footerText="Content Footer")
        {
        
            // Create the image
            var info = new SKImageInfo(640, 480);
            using (var surface = SKSurface.Create(info))
            {
                var canvas = surface.Canvas;

                // Clear the canvas
                canvas.Clear(SKColors.White);

                // Create the text paint
                var paint = new SKPaint
                {
                    Color = SKColors.Black,
                    TextSize = 24,
                    IsAntialias = true,
                    Typeface = SKTypeface.FromFamilyName("Arial")
                };                
                canvas.DrawText(contentItem.Title, 20, 40, paint);

                // Draw the content
                paint.TextSize = 16;
                canvas.DrawText(contentItem.Description, 20, 80, paint);

                // Save the image to a stream
                using (var image = surface.Snapshot())
                using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
                {
                    return data.ToArray();
                }
            }
        }


       //public async Task<byte[]> GenerateMobilePdf1(ContentItem contentItem,float scale)
       //     {
       //        // var contentItem = _contentItemRepository.GetById(id);

       //         if (contentItem == null)
       //         {
       //             return null;
       //         }

       //         var document = new HtmlToPdfDocument()
       //         {
       //             GlobalSettings = {
       //         PaperSize = new PechkinPaperSize("360", "640"),
       //     },
       //             Objects = {
       //         new ObjectSettings()
       //         {
       //             HtmlContent = $"<h1>{contentItem.Title}</h1><p>{contentItem.Description}</p>",
       //         }
       //     }
       //         };

       //         var converter = new BasicConverter(new PdfTools());

       //         return converter.Convert(document);
       //     }

        public byte[] GenerateMobilePdf(ContentItem contentItem, float scale)
        {

            string headerText = "News";
            var eventHandler = new PdfHeaderFooterEventHandler(headerText, _webHostEnvironment);
            using var stream = new MemoryStream();
            var writer = new PdfWriter(stream, new WriterProperties().SetCompressionLevel(5));
            var pdfDocument = new PdfDocument(writer);
            pdfDocument.AddEventHandler(PdfDocumentEvent.START_PAGE, eventHandler);
            PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            Color fontColor = new DeviceRgb(0, 0, 255); // blue color // black
            var document = new Document(pdfDocument, iText.Kernel.Geom.PageSize.A4);            
            var page = pdfDocument.AddNewPage();
            var canvas = new PdfCanvas(page);
            var action = PdfAction.CreateURI("https://www.ecssr.ae/en/ecssr-at-a-glance/");
            var annotation = new PdfLinkAnnotation(new Rectangle(36, 770, 36, 20))
    .SetAction(action)
    .SetBorder(new PdfArray(new[] { 0, 0, 0 }))
    //.SetHighlightMode(PdfAnnotation.HIGHLIGHT_INVERT)
    .SetTitle(new PdfString("Link to external"));
            //.SetOpenInNewWindow(true);
            page.AddAnnotation(annotation);
            canvas.BeginText();
            canvas.SetFontAndSize(font, 16);
            canvas.MoveText(36, 780);
            canvas.ShowText(contentItem.Title);
            canvas.SetColor(fontColor, true);
            canvas.EndText();

            Paragraph contentheaerr = new Paragraph(contentItem.Title)
               .SetTextAlignment(TextAlignment.CENTER)
               .SetMarginTop(100f);

            document.Add(contentheaerr);
            document.Add(new Paragraph(contentItem.Description).SetMarginTop(80f));
            // Scale the content on each page of the document
            for (int i = 1; i <= pdfDocument.GetNumberOfPages(); i++)
            {
                var page2 = pdfDocument.GetPage(i);
                var canvas2 = new PdfCanvas(page2);
                // Scale the content
                canvas2.SaveState();
                canvas2.ConcatMatrix(scale, 0, 0, scale, 0, 0);
                canvas2.RestoreState();
            }
            document.Close();
            return stream.ToArray();
        }

    }

    public class PdfHeaderFooterEventHandler : IEventHandler
    {
        private readonly Image _headerImage;
        private readonly Image _footerImage;
        private readonly string headerText;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public PdfHeaderFooterEventHandler(string headerText, IWebHostEnvironment webHostEnvironment)
        {
            //_headerImage = new Image(ImageDataFactory.Create(headerImagePath));
            //_footerImage = new Image(ImageDataFactory.Create(footerImagePath));
            headerText = headerText;
            _webHostEnvironment = webHostEnvironment;
        }

        public void HandleEvent(Event @event)
        {
            PdfDocumentEvent documentEvent = (PdfDocumentEvent)@event;
            PdfDocument pdfDocument = documentEvent.GetDocument();
            PdfPage page = documentEvent.GetPage();

            Rectangle pageSize = page.GetPageSize();
            PdfCanvas pdfCanvas = new PdfCanvas(page.NewContentStreamBefore(), page.GetResources(), pdfDocument);

            // Add header
            pdfCanvas.BeginText();
            pdfCanvas.SetFontAndSize(PdfFontFactory.CreateFont(), 12);
           // pdfCanvas.MoveText(pageSize.GetWidth() / 2 - 30, pageSize.GetTop() - 20);
            pdfCanvas.ShowText(headerText);
            pdfCanvas.EndText();
            var imagePath = System.IO.Path.Combine(_webHostEnvironment.WebRootPath, "header.PNG");
            var imageBytes = File.ReadAllBytes(imagePath);
            var image = new PdfImageXObject(ImageDataFactory.Create(imageBytes));
            var headerImage = new Image(image);
            pdfCanvas.AddImageAt(ImageDataFactory.Create(imageBytes), pageSize.GetLeft()-30, pageSize.GetTop() - 130, true);

            // Add footer
            pdfCanvas.BeginText();
            pdfCanvas.SetFontAndSize(PdfFontFactory.CreateFont(), 10);
           // pdfCanvas.MoveText(pageSize.GetWidth() / 2 - 30, pageSize.GetBottom() + 20);
            pdfCanvas.ShowText($"Page {pdfDocument.GetPageNumber(page)} of {pdfDocument.GetNumberOfPages()}");
            var imagePath1 = System.IO.Path.Combine(_webHostEnvironment.WebRootPath, "footer.PNG");
            var imageBytes1 = File.ReadAllBytes(imagePath1);
            pdfCanvas.AddImageAt(ImageDataFactory.Create(imageBytes1), pageSize.GetLeft()-30, pageSize.GetBottom()+30, true);
            pdfCanvas.EndText();

            pdfCanvas.Release();
            //var documentEvent = (PdfDocumentEvent)@event;

            //var currentPageNumber = 1;// documentEvent.GetPageNumber();
            //var totalPages = documentEvent.GetDocument().GetNumberOfPages();

            //var page = documentEvent.GetPage();
            //var pageSize = page.GetPageSize();
            //var pageWidth = pageSize.GetWidth();

            //// Add header
            //var header = new Paragraph("This is the header.");
            //header.SetFixedPosition(0, pageSize.GetTop(), pageWidth);
            //page.Add(header);

            //var canvas = new Canvas(page, pageSize);
            //var headerImage = new Image(_headerImage);
            //canvas.Add(headerImage.SetFixedPosition(0, pageSize.GetTop() - 50, pageWidth));

            //// Add footer
            //var footer = new Paragraph($"Page {currentPageNumber} of {totalPages}");
            //footer.SetFixedPosition(0, pageSize.GetBottom() - 20, pageWidth);
            //page.Add(footer);

            //var footerCanvas = new Canvas(page, pageSize);
            //var footerImage = new Image(_footerImage);
            //footerCanvas.Add(footerImage.SetFixedPosition(0, pageSize.GetBottom() + 30, pageWidth));
        }
        //private string headerText;

        //public PdfHeaderFooterEventHandler(string headerText)
        //{
        //    this.headerText = headerText;
        //}

        //public void HandleEvent(Event @event)
        //{
        //    PdfDocumentEvent documentEvent = (PdfDocumentEvent)@event;
        //    PdfDocument pdfDocument = documentEvent.GetDocument();
        //    PdfPage page = documentEvent.GetPage();

        //    Rectangle pageSize = page.GetPageSize();
        //    PdfCanvas pdfCanvas = new PdfCanvas(page.NewContentStreamBefore(), page.GetResources(), pdfDocument);

        //    // Add header
        //    pdfCanvas.BeginText();
        //    pdfCanvas.SetFontAndSize(PdfFontFactory.CreateFont(), 12);
        //    pdfCanvas.MoveText(pageSize.GetWidth() / 2 - 30, pageSize.GetTop() - 20);
        //    pdfCanvas.ShowText(headerText);
        //    pdfCanvas.EndText();

        //    // Add footer
        //    pdfCanvas.BeginText();
        //    pdfCanvas.SetFontAndSize(PdfFontFactory.CreateFont(), 10);
        //    pdfCanvas.MoveText(pageSize.GetWidth() / 2 - 30, pageSize.GetBottom() + 20);
        //    pdfCanvas.ShowText($"Page {pdfDocument.GetPageNumber(page)} of {pdfDocument.GetNumberOfPages()}");
        //    pdfCanvas.EndText();

        //    pdfCanvas.Release();
        //}
    }
}
