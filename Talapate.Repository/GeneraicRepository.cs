using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talapate.Core.Entities;
using Talapate.Core.Interfaces;
using Talapate.Core.specification;
using Talapate.Repository.Data.Context;
using Talapate.Repository.Specification;

namespace Talapate.Repository
{
    public class GeneraicRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext context;

        public GeneraicRepository(StoreContext _context)
        {
            context = _context;
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            if(typeof(T) == typeof(Product)) 
            {
                return (IEnumerable<T>) await context.Set<Product>().Include(b=>b.Brand).Include(B=>B.Cataegory).ToListAsync();
            }

           return await context.Set<T>().ToListAsync();
        }


        public async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);   
        }
        public async Task<IEnumerable<T>> GetAllWithSpecAsync(Ispecification<T> spec)
        {
            return await ApllaySpecifiction(spec).ToListAsync();
        }

        public async Task<T> GetByIdWithSpecAsync(Ispecification<T> spec)
        {
            return await ApllaySpecifiction(spec).FirstOrDefaultAsync();
        }

        private IQueryable<T> ApllaySpecifiction(Ispecification<T> spec)
        {
            return SpecifictionEvalutor<T>.GetQuery(context.Set<T>(), spec);
        }
    }
}
