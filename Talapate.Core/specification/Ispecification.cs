using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talapate.Core.Entities;

namespace Talapate.Core.specification
{
    public interface Ispecification<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>>? Criteria { get; set; } // where (p=>p.Id ==id )
       public List<Expression<Func<T, object>>> Includes { get; set; } //Includes(p=>p.Brand) 
    }
}
