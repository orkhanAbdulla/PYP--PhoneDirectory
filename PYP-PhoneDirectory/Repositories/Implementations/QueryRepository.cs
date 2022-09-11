using Microsoft.EntityFrameworkCore;
using PYP_PhoneDirectory.Helpers;
using PYP_PhoneDirectory.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PYP_PhoneDirectory.Repositories.Implementations
{
    public class QueryRepository<T> : IRepository<T> where T : class
    {
        private readonly SqlConnection _connection;
        private static string table = typeof(T).Name.ToString();
        public QueryRepository(SqlConnection conection)
        {
            _connection = conection;
        }

        public DbSet<T> Table => throw new NotImplementedException();

        public async Task<bool> AddAsync(T model)
        {
            string command = Helper.AddQueryGenerate(model);
            await _connection.OpenAsync();
            int result;
            using (SqlCommand comn = new SqlCommand(command, _connection))
            {
                result=comn.ExecuteNonQuery();
            }
            _connection.Close();
            if (result!=1)
            {
                return false;
            }
            return true;
        }

        public ICollection<T> GetAll()
        {
            _connection.Open();
            SqlDataReader dr;
            using (SqlCommand comn = new SqlCommand($"select * from {table}", _connection)) { 

                dr = comn.ExecuteReader();
            }
            ICollection<T> values = new List<T>();
            foreach (var item in dr.GetType().GetProperties())
            {

            }

            return values;
        }

        public ICollection<T> GetWhere(Expression<Func<T, bool>> method)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
