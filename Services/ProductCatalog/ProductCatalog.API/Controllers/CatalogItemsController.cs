using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.BusinessObjects;
using ProductCatalog.Domain;

namespace ProductCatalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogItemsController : ControllerBase
    {
        ICatalogItemBO _catalogItemBO;
        public CatalogItemsController(ICatalogItemBO catalogItemBO)
        {
            _catalogItemBO = catalogItemBO;
        }

        public async Task<ActionResult<IEnumerable<CatalogItem>>> GetCatalogItem()
        {
            var item = await _catalogItemBO.GetCatalogItems();
            return Ok(item);
        }

        // GET: api/CatalogItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CatalogItem>> GetCatalogItem(int id)
        {
            var catalogItem = await _catalogItemBO.GetCatalogItemDetails(id);

            if (catalogItem == null)
            {
                return NotFound();
            }

            return catalogItem;
        }

        // PUT: api/CatalogItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatalogItem(int id, CatalogItem catalogItem)
        {
            if (id != catalogItem.Id)
            {
                return BadRequest();
            }

           

            try
            {
                await _catalogItemBO.Update(catalogItem);
            }
            catch (ApplicationException ex)
            {
                if (ex.Message == "Not Found")
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CatalogItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<ActionResult<CatalogItem>> PostCatalogItem(CatalogItem catalogItem)
        {
            await _catalogItemBO.Add(catalogItem);

            return CreatedAtAction("GetCatalogItem", new { id = catalogItem.Id }, catalogItem);
        }

        // DELETE: api/CatalogItems/5
        [HttpDelete("{id}")]
        public async Task DeleteCatalogItem(int id)
        {
           await _catalogItemBO.Delete(id);
           
        }
    }
}
