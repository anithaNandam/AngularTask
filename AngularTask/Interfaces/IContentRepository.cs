using AngularTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularTask.Interfaces
{
    public interface IContentRepository   
    {
        Task<List<ContentItem>> GetContentItemsAsync(int pageNumber, int pageSize);
        Task<ContentItem> GetContentItemAsync(int id);
        Task<int> AddContentItemAsync(ContentItem contentItem);
        Task UpdateContentItemAsync(ContentItem contentItem);
        Task DeleteContentItemAsync(ContentItem contentItem);
    }
}
