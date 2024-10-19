
using DataAccess.Interfaces;
using Domain.Common;
using Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class DataAccess<T> : IDataAccess<T> where T : class
    {

        private readonly PruebaDBContext _Context;
        private readonly DbSet<T> table;

        public DataAccess(PruebaDBContext Context)
        {
            _Context = Context;
            table = _Context.Set<T>();
        }
       
        public async Task<List<UserSp>> GetAll()
        {
            var list = await _Context.SpGetUser.FromSqlRaw(" EXEC  SpGetUser ").ToListAsync();
            return list;
        }
        public async Task<UserSp> GetById(int id)
        {
            var list = await _Context.SpGetUserById.FromSqlRaw(" EXEC  SpGetUserById @IdUser ", new SqlParameter("@IdUser", id)).ToListAsync();
            var result = list.FirstOrDefault();
            return result;
        }
        public async Task<T?> GetByIdOthers(int id)
        {
            T? t = await table.FindAsync(id);
            return t;
        }
        public  async Task Insert(T obj)
        {
            table.Add(obj);
            await Save();

        }
        public async Task Update(T obj)
        {
            table.Update(obj);
            await Save();
        }
        public async Task Delete(T obj)
        {
            table.Remove(obj);
            await _Context.SaveChangesAsync();
        }
        public async Task Save()
        {
            await _Context.SaveChangesAsync();
        }

       
    }
}
