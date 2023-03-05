using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngularTask.Models
{
    public class ContentItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string ThumbnailUrl { get; set; }

        [Required]
        public int DownloadCount { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }
       
        public int TotalsDownloadsA4 { get; set; }
        public int TotalsDownloadsmobile { get; set; }
        public int TotalsDownloadsimage { get; set; }

       
    }

    public enum PageSize
    {
        A4,
        Mobile
    }

    public enum ImageSize
    {
        Mobile
    }

    public class FileContent
    {
        public byte[] Content { get; set; }
        public string ContentType { get; set; }
        public string Format { get; set; }
    }

    public class PaginatedResponse<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
