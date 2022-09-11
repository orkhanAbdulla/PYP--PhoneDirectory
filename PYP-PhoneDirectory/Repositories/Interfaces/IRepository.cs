using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PYP_PhoneDirectory.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        DbSet<T> Table { get;}
        Task<bool> AddAsync(T model);
        ICollection<T> GetAll();
        ICollection<T> GetWhere(Expression<Func<T, bool>> method);
        public Task<int> SaveAsync();
         
    }
}
