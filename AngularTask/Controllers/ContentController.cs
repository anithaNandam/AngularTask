using AngularTask.Data;
using AngularTask.Interfaces;
using AngularTask.Models;
using DinkToPdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContentController : ControllerBase
    {
        private readonly ContentDbContext _context;
        private readonly ContentService _contentService;

        private readonly IContentRepository _repository;
       // private readonly ContentService _contentService;

        public ContentController(IContentRepository repository, ContentDbContext context, ContentService contentService)
        {
            _context = context;
            _contentService = contentService;
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedResponse<ContentItem>>> GetContent(int pageNumber = 1, int pageSize = 10)
        {
           var contentItems = await _repository.GetContentItemsAsync(pageNumber, pageSize);

            var totalCount = await _context.ContentItems.CountAsync();

            var response = new PaginatedResponse<ContentItem>
            {
                Items = contentItems,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return response;
        }

        [HttpPost]
        public async Task<ActionResult<ContentItem>> AddContent(ContentItem contentItem)
        {
            var id = await _repository.AddContentItemAsync(contentItem);
            return CreatedAtAction(nameof(GetContentItem), new { id = id }, contentItem);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContentItem>> GetContentItem(int id)
        {
            var contentItem = await _repository.GetContentItemAsync(id);

            if (contentItem == null)
            {
                return NotFound();
            }
            // create dynamic header and footer
            var headerHtml = $"<h1>{contentItem.Title}</h1>";
            var footerHtml = $"<p>Downloads: {contentItem.TotalsDownloadsA4} A4, {contentItem.TotalsDownloadsmobile} Mobile, {contentItem.TotalsDownloadsimage} Image</p>";
            Response.Headers.Add("HeaderHtml", headerHtml);
            Response.Headers.Add("FooterHtml", footerHtml);
            return contentItem;
        }


        [HttpGet("{id}/download")]
        public async Task<IActionResult> DownloadContent(int id, float scale, string format = "pdf-a4")
        {
            scale = 3f;
            var contentItem = await _repository.GetContentItemAsync(id);
            if (contentItem == null)
            {
                return NotFound();
            }

          if(format == "pdf-a4")
            {
                contentItem.TotalsDownloadsA4++;
            }
            else if (format == "pdf-mobile")
            {
                contentItem.TotalsDownloadsmobile++;
            }
            else if (format == "image-mobile")
            {
                contentItem.TotalsDownloadsimage++;
            }
            // Increment download count
            contentItem.DownloadCount++;
            _context.Entry(contentItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
           

            // Get file content
            var fileContent = await GetFileContent(contentItem, format,scale);


            if (fileContent == null)
            {
                return BadRequest($"Invalid format: {format}");
            }

            // Return file for download
            var fileName = $"{contentItem.Title}.{fileContent.Format}";
            return File(fileContent.Content, fileContent.ContentType, fileName);
        }

        [HttpGet("{id}/download/pdf-a4")]
        public async Task<IActionResult> DownloadA4Pdf(int id,float scale)
        {
            return await DownloadContent(id, scale,"pdf-a4");
        }

        [HttpGet("{id}/download/pdf-mobile")]
        public async Task<IActionResult> DownloadMobilePdf(int id, float scale)
        {
            return await DownloadContent(id, scale, "pdf-mobile");
        }

        [HttpGet("{id}/download/image-mobile")]
        public async Task<IActionResult> DownloadMobileImage(int id, float scale)
        {
            return await DownloadContent(id, scale, "image-mobile");
        }

        private async Task<FileContent> GetFileContent(ContentItem contentItem, string format, float scale)
        {
            switch (format.ToLower())
            {
                case "pdf-a4":
                    return await GeneratePdf(contentItem, PageSize.A4, scale);
                case "pdf-mobile":
                    return await GenerateMobilePdf(contentItem, PageSize.Mobile, scale);
                case "image-mobile":
                    return await GenerateImage(contentItem, ImageSize.Mobile, scale);
                default:
                    return null;
            }
        }

        private async Task<FileContent> GeneratePdf(ContentItem contentItem, PageSize pageSize, float scale)
        {

        
            // Generate A4 PDF            
            var pdfContent = await _contentService.GeneratePdf(contentItem, PageSize.A4, scale);

            //var pdfContent = await _contentService.GeneratePdfWithDynamicHeaderFooterAndScaling();
            return new FileContent
            {
                Content = pdfContent,
                ContentType = "image/jpeg",
                Format = "jpg"
            };
        }


        private async Task<FileContent> GenerateMobilePdf(ContentItem contentItem, PageSize pageSize, float scale)
        {
           
            // Generates mobile PDF
            var pdfContent =  _contentService.GenerateMobilePdf(contentItem, scale);

            return new FileContent
            {
                Content = pdfContent,
                ContentType = "image/jpeg",
                Format = "jpg"
            };
        }

        private async Task<FileContent> GenerateImage(ContentItem contentItem, ImageSize imageSize, float scale)
        {
            // Generates mobile image 
            var imageContent = _contentService.GenerateMobileImage(contentItem, scale);

            return new FileContent
            {
                Content = imageContent,
                ContentType = "image/jpeg",
                Format = "jpg"
            };
         
        }

      

        
           
        
    }
}
