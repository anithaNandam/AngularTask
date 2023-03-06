using AngularTask.Data;
using AngularTask.Interfaces;
using AngularTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularTask.Repository
{ 
public class ContentRepository : IContentRepository
{
    private readonly ContentDbContext _context;

    public ContentRepository(ContentDbContext context)
    {
        _context = context;
    }

    public async Task<List<ContentItem>> GetContentItemsAsync(int pageNumber, int pageSize)
    {
        return await _context.ContentItems
            .OrderByDescending(c => c.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<ContentItem> GetContentItemAsync(int id)
    {
        return await _context.ContentItems.FindAsync(id);
    }

    public async Task<int> AddContentItemAsync(ContentItem contentItem)
    {
        _context.ContentItems.Add(contentItem);
        await _context.SaveChangesAsync();
        return contentItem.Id;
    }

    public async Task UpdateContentItemAsync(ContentItem contentItem)
    {
        _context.Entry(contentItem).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteContentItemAsync(ContentItem contentItem)
    {
        _context.ContentItems.Remove(contentItem);
        await _context.SaveChangesAsync();
    }
}
}
