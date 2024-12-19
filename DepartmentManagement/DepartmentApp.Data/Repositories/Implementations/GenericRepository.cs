using DepartmentApp.Core.Base;
using DepartmentApp.Data.DAL;
using DepartmentApp.Data.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentApp.Data.Repositories.Implementations
{
    public class GenericRepository<Tentity> : IGenericRepository<Tentity> where Tentity : BaseEntity, new()
    {
        private readonly AppDbContext _appDbContext;
        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        DbSet<Tentity> table => _appDbContext.Set<Tentity>();
        public async Task<Tentity> CreateAsync(Tentity entity)
        {
            await table.AddAsync(entity);
            return entity;
 
        }

        public void Delete(Tentity entity)
        {
            table.Remove(entity);
        }

        public async Task<ICollection<Tentity>> GetAllAsync()
        {
          return await _appDbContext.Set<Tentity>().ToListAsync();
        }

        public async Task<Tentity> GetByIdAsync(int id)
        {
           var result= await table.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public void Update(Tentity entity)
        {
            table.Update(entity);
            
        }

    }
}
