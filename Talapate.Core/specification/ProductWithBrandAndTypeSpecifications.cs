using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talapate.Core.Entities;

namespace Talapate.Core.specification
{
    public class ProductWithBrandAndTypeSpecifications:BaseSpecifiction<Product>
    {

        public ProductWithBrandAndTypeSpecifications() : base()
        {
            Includes.Add(p => p.Brand); 
            Includes.Add(p => p.Cataegory);
        }

        public ProductWithBrandAndTypeSpecifications(int id):base(p => p.Id == id) 
        {

            Includes.Add(p => p.Brand);
            Includes.Add(p => p.Cataegory);
        }
    }
}
