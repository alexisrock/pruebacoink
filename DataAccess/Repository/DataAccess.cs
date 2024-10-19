
using DataAccess.Interfaces;
using Domain.Entities; 
using Microsoft.EntityFrameworkCore;


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
            var list = await _Context.SpGetUser.FromSqlRaw("  SELECT * FROM   SpGetUser()").ToListAsync();
            return list;
        }
        public async Task<UserSp> GetById(int id)
        {
            var list = await _Context.SpGetUserById.FromSqlRaw("SELECT * FROM  SpGetUserById({0})", id).ToListAsync();
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
