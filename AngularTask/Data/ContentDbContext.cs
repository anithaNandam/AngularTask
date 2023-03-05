using AngularTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularTask.Data
{
    public class ContentDbContext : DbContext
    {
        public ContentDbContext(DbContextOptions<ContentDbContext> options)
            : base(options)
        {
        }

        public DbSet<Content> Contents { get; set; }
        public DbSet<ContentItem> ContentItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Content>().HasData(
                new Content
                {
                    Id = 1,
                    Title = "Sample Content 1",
                    Description = "This is a sample content.",
                    DownloadUrl = "https://example.com/sample-content-1.pdf"
                },
                new Content
                {
                    Id = 2,
                    Title = "Sample Content 2",
                    Description = "This is another sample content.",
                    DownloadUrl = "https://example.com/sample-content-2.pdf"
                },
                new Content
                {
                    Id = 3,
                    Title = "Sample Content 3",
                    Description = "This is yet another sample content.",
                    DownloadUrl = "https://example.com/sample-content-3.pdf"
                }
            );

            modelBuilder.Entity<ContentItem>().HasData(
    new List<ContentItem>
    {
        new ContentItem
        {
            Id = 1,
            Title = "First Item",
            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse quis risus quam. Nulla quis mauris vel libero mollis facilisis. Ut vitae fringilla nisi. Nam eu augue eget arcu rutrum vestibulum. In hac habitasse platea dictumst. Curabitur id urna at mauris auctor malesuada. Sed non ipsum ac nisi iaculis ullamcorper vel vel lectus.",
            ImageUrl = "https://example.com/image1.jpg",
            ThumbnailUrl = "https://example.com/thumb1.jpg",
            DownloadCount = 0,
            TotalsDownloadsA4  = 0,
            TotalsDownloadsmobile  = 0,
            TotalsDownloadsimage = 0,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        },
        new ContentItem
        {
            Id = 2,
            Title = "Second Item",
            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse quis risus quam. Nulla quis mauris vel libero mollis facilisis. Ut vitae fringilla nisi. Nam eu augue eget arcu rutrum vestibulum. In hac habitasse platea dictumst. Curabitur id urna at mauris auctor malesuada. Sed non ipsum ac nisi iaculis ullamcorper vel vel lectus.",
            ImageUrl = "https://example.com/image2.jpg",
            ThumbnailUrl = "https://example.com/thumb2.jpg",
            DownloadCount = 0,
             TotalsDownloadsA4  = 0,
            TotalsDownloadsmobile  = 0,
            TotalsDownloadsimage = 0,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        },
        new ContentItem
        {
            Id = 3,
            Title = "Third Item",
            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse quis risus quam. Nulla quis mauris vel libero mollis facilisis. Ut vitae fringilla nisi. Nam eu augue eget arcu rutrum vestibulum. In hac habitasse platea dictumst. Curabitur id urna at mauris auctor malesuada. Sed non ipsum ac nisi iaculis ullamcorper vel vel lectus",
            ImageUrl = "https://example.com/image3.jpg",
            ThumbnailUrl = "https://example.com/thumb3.jpg",
            DownloadCount = 0,
            TotalsDownloadsA4  = 0,
            TotalsDownloadsmobile  = 0,
            TotalsDownloadsimage = 0,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        },
         new ContentItem
        {
            Id = 4,
            Title = "Fourth Item",
            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse quis risus quam. Nulla quis mauris vel libero mollis facilisis. Ut vitae fringilla nisi. Nam eu augue eget arcu rutrum vestibulum. In hac habitasse platea dictumst. Curabitur id urna at mauris auctor malesuada. Sed non ipsum ac nisi iaculis ullamcorper vel vel lectus.",
            ImageUrl = "https://example.com/image1.jpg",
            ThumbnailUrl = "https://example.com/thumb1.jpg",
            DownloadCount = 0,
            TotalsDownloadsA4  = 0,
            TotalsDownloadsmobile  = 0,
            TotalsDownloadsimage = 0,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        },
        new ContentItem
        {
            Id = 5,
            Title = "Fifth Item",
            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse quis risus quam. Nulla quis mauris vel libero mollis facilisis. Ut vitae fringilla nisi. Nam eu augue eget arcu rutrum vestibulum. In hac habitasse platea dictumst. Curabitur id urna at mauris auctor malesuada. Sed non ipsum ac nisi iaculis ullamcorper vel vel lectus.",
            ImageUrl = "https://example.com/image2.jpg",
            ThumbnailUrl = "https://example.com/thumb2.jpg",
            DownloadCount = 0,
             TotalsDownloadsA4  = 0,
            TotalsDownloadsmobile  = 0,
            TotalsDownloadsimage = 0,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        },
        new ContentItem
        {
            Id = 6,
            Title = "Sixth Item",
            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse quis risus quam. Nulla quis mauris vel libero mollis facilisis. Ut vitae fringilla nisi. Nam eu augue eget arcu rutrum vestibulum. In hac habitasse platea dictumst. Curabitur id urna at mauris auctor malesuada. Sed non ipsum ac nisi iaculis ullamcorper vel vel lectus.",
            ImageUrl = "https://example.com/image3.jpg",
            ThumbnailUrl = "https://example.com/thumb3.jpg",
            DownloadCount = 0,
            TotalsDownloadsA4  = 0,
            TotalsDownloadsmobile  = 0,
            TotalsDownloadsimage = 0,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        }
    });
        }
    }
}

