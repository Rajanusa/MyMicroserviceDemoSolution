using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog.Domain
{
    [Table("CatalogType")]
    public class CatalogType
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }
}
