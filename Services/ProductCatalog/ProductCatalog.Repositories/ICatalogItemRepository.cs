using ProductCatalog.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Repositories
{
    public interface ICatalogItemRepository
    {
        Task<IEnumerable<CatalogItem>> GetCatalogItems();
        Task<CatalogItem> GetCatalogItemDetails(int id);
        Task<CatalogItem> Add(CatalogItem item);
        Task Update(CatalogItem item);
        Task Delete(int id);
    }
}
