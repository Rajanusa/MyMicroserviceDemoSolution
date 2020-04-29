using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.API.Domain;

    public class CatalogServiceContext : DbContext
    {
        public CatalogServiceContext (DbContextOptions<CatalogServiceContext> options)
            : base(options)
        {
        }

        public DbSet<ProductCatalog.API.Domain.CatalogItem> CatalogItems { get; set; }

        public DbSet<ProductCatalog.API.Domain.CatalogBrand> CatalogBrands { get; set; }

        public DbSet<ProductCatalog.API.Domain.CatalogType> CatalogTypes { get; set; }
    }
