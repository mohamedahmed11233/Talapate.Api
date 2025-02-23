using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talapate.Core.Entities
{
    public class ProductCataegory : BaseEntity
    {
        public string Name { get; set; }

        //public ICollection<Product> Products { get; set; } = new HashSet<Product>(); handel it using Fluint Api

    }
}
