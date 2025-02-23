using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talapate.Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Discription { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }

        public int BrandId { get; set; } //FK
        public productBrand Brand { get; set; }


        public int CataegoryId { get; set; } //fk
        public ProductCataegory Cataegory { get; set; } //NP



    }
}
