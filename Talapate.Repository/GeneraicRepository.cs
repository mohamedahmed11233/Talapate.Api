using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talapate.Core.Entities;
using Talapate.Core.Interfaces;
using Talapate.Repository.Data.Context;

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
    }
}
