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
using SkiaSharp.Views;
//using System.Drawing;
using WkHtmlToXSharp;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Geom;

namespace AngularTask.Models
{
    public class ContentService
    {
        private readonly IConverter _pdfConverter;

        public ContentService(IConverter pdfConverter)
        {
            _pdfConverter = pdfConverter;
        }

        //public async Task<byte[]> GeneratePdf(ContentItem contentItem)
        //{
        //    var doc = new HtmlToPdfDocument()
        //    {
        //        GlobalSettings = {
        //        ColorMode = ColorMode.Color,
        //        Orientation = Orientation.Portrait,
        //        PaperSize = PaperKind.A5
        //    },
        //        Objects = {
        //        new ObjectSettings()
        //        {
        //            HtmlContent = $"<html><body><h1>{contentItem.Title}</h1><p>{contentItem.Description}</p></body></html>"
        //        }
        //    }
        //    };

        //    return _pdfConverter.Convert(doc);
        //}

        //public async Task<byte[]> GenerateImage(ContentItem contentItem)
        //{
        //    // Set the desired DPI for the image
        //        float dpi = 72f;

        //    // Calculate the target size of the image based on the screen dimensions of a typical mobile device
        //    float width = 720f / dpi;
        //    float height = 1280f / dpi;
        //    using var bitmap = new SKBitmap((int)width, (int)height);
        //    using var canvas = new SKCanvas(bitmap);
        //    canvas.Clear(SKColors.White);
        //    using var paint = new SKPaint();
        //    paint.Color = SKColors.Black;
        //    paint.TextSize = 30.0f;
        //    using var font = SKTypeface.FromFamilyName("Arial");
        //    paint.Typeface = font;
        //    canvas.DrawText(contentItem.Title, 10, 50, paint);
        //    canvas.DrawText(contentItem.Description, 10, 100, paint);

        //    using var image = SKImage.FromBitmap(bitmap);
        //    using var data = image.Encode(SKEncodedImageFormat.Jpeg, 100);
        //    return data.ToArray();
        //}
        public async Task<byte[]> GeneratePdf(ContentItem contentItem, PageSize pageSize, float scale)
        {
            using var stream = new MemoryStream();
            var writer = new PdfWriter(stream);
            var pdfDocument = new PdfDocument(writer);
            // Set the scale factor for the entire document
            //pdfDocument.SetPageScale(scale);
            var document = new Document(pdfDocument, iText.Kernel.Geom.PageSize.A4);
            document.Add(new Paragraph(contentItem.Title).SetTextAlignment(TextAlignment.CENTER));
            document.Add(new Paragraph(contentItem.Description));
            // Scale the content on each page of the document
            for (int i = 1; i <= pdfDocument.GetNumberOfPages(); i++)
            {
                var page = pdfDocument.GetPage(i);
               // var contentStream = page.GetContentStream();
               var canvas = new PdfCanvas(page);
               // page.put(PdfName.UserUnit, new PdfNumber(2.5f));
                // Scale the content
                canvas.SaveState();
                canvas.ConcatMatrix(scale, 0, 0, scale, 0, 0);
                canvas.RestoreState();
            }
            document.Close();
            return stream.ToArray();
        }
        public byte[] GenerateMobileImage(ContentItem contentItem, string headerText="content Header", string footerText="Content Footer")
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
                //// Draw the header
                //paint.TextAlign = SKTextAlign.Left;
                //canvas.DrawText(headerText, 20, 20 + paint.FontMetrics.Ascent, paint);

                //// Draw the footer
                //paint.TextAlign = SKTextAlign.Right;
                //canvas.DrawText(footerText, info.Width - 20, info.Height - 20 - paint.FontMetrics.Descent, paint);


                // Draw the title
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


        public async Task<byte[]> GenerateA4Pdf(ContentItem contentItem)
            {
            try
            {
                // var contentItem = _contentItemRepository.GetById(id);

                if (contentItem == null)
                {
                    return null;
                }

                var document = new HtmlToPdfDocument()
                {
                    GlobalSettings = {
                PaperSize = PaperKind.A4,
            },
                    Objects = {
                new ObjectSettings()
                {
                    HtmlContent = $"<h1>{contentItem.Title}</h1><p>{contentItem.Description}</p>",
                }
            }
                };

                var converter = new BasicConverter(new PdfTools());

                return converter.Convert(document);
            }
            catch (Exception ex)
            {

                throw ex;
            }
               
            }

            public async Task<byte[]> GenerateMobilePdf(ContentItem contentItem)
            {
               // var contentItem = _contentItemRepository.GetById(id);

                if (contentItem == null)
                {
                    return null;
                }

                var document = new HtmlToPdfDocument()
                {
                    GlobalSettings = {
                PaperSize = new PechkinPaperSize("360", "640"),
            },
                    Objects = {
                new ObjectSettings()
                {
                    HtmlContent = $"<h1>{contentItem.Title}</h1><p>{contentItem.Description}</p>",
                }
            }
                };

                var converter = new BasicConverter(new PdfTools());

                return converter.Convert(document);
            }

       
    }
}
