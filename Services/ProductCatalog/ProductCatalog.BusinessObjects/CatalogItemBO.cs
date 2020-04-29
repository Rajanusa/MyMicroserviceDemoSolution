using ProductCatalog.Domain;
using ProductCatalog.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.BusinessObjects
{

    public interface ICatalogItemBO
    {
        Task<IEnumerable<CatalogItem>> GetCatalogItems();
        Task<CatalogItem> GetCatalogItemDetails(int id);
        Task<CatalogItem> Add(CatalogItem item);
        Task Update(CatalogItem item);
        Task Delete(int id);
    }

    public class CatalogItemBO : ICatalogItemBO
    {
        ICatalogItemRepository _repository;
        public CatalogItemBO(ICatalogItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CatalogItem>> GetCatalogItems()
        {
            return await _repository.GetCatalogItems();
        }

        public async Task<CatalogItem> GetCatalogItemDetails(int id)
        {
            return await _repository.GetCatalogItemDetails(id);
        }

        public async Task<CatalogItem> Add(CatalogItem item)
        {
            return await _repository.Add(item);
        }

        public  async Task Update(CatalogItem item)
        {
           await _repository.Update(item);
        }

        public async Task Delete(int id)
        {
           await  _repository.Delete(id);
        }
    }
}
