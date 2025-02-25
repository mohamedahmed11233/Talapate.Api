using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talapate.Core.Entities;
using Talapate.Core.specification;

namespace Talapate.Repository.Specification
{
    internal static class SpecifictionEvalutor<T> where T : BaseEntity
    {
        public static IQueryable<T>GetQuery(IQueryable<T> innerQuery ,Ispecification<T> spec)
        {

            var query = innerQuery;  //_dbContext.Products 

            if (spec.Criteria is not null)
                query = innerQuery.Where(spec.Criteria);    //_dbContext.Products.where(p=>p.Id==id)

            query = spec.Includes.Aggregate(query, (currentQuery, IncludsExpression) =>
            currentQuery.Include(IncludsExpression));
            //output = _dbContext.Products.where(p => p.Id).Include(p => 
           // p.productBrand).Include(p => p.productType).FirstOrDefaultAsync();
            return query;
        }

    }
}
