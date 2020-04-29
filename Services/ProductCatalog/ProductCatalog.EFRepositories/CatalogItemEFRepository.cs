using Microsoft.EntityFrameworkCore;
using ProductCatalog.Domain;
using ProductCatalog.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.EFRepositories
{
    public class CatalogItemEFRepository : ICatalogItemRepository
    {
        CatalogServiceContext _context;
        public CatalogItemEFRepository(CatalogServiceContext catalogServiceContex)
        {
            _context = catalogServiceContex;
        }

        public async Task<CatalogItem> Add(CatalogItem item)
        {
            _context.CatalogItems.Add(item);
            await _context.SaveChangesAsync();

            return item;
        }

        public async Task Delete(int id)
        {
            var catalogItem = await _context.CatalogItems.FindAsync(id);
            if (catalogItem == null)
            {
                throw new ApplicationException("Not found");
            }

            _context.CatalogItems.Remove(catalogItem);
            await _context.SaveChangesAsync();
        }

        public async Task<CatalogItem> GetCatalogItemDetails(int id)
        {
            var catalogItem = await _context.CatalogItems.FindAsync(id);

            if (catalogItem == null)
            {
                throw new ApplicationException("Not Found");
            }

            return catalogItem;
        }

        public async Task<IEnumerable<CatalogItem>> GetCatalogItems()
        {
            return await _context.CatalogItems.Include("CatalogType").Include("CatalogBrand").ToListAsync();
        }

        public async Task Update(CatalogItem item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
