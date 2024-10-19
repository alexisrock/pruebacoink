using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Interfaces
{
    public interface IDataAccess<T> where T : class
    {

        Task<List<UserSp>> GetAll();     
        Task Insert(T obj);
        Task Update(T obj);
        Task Delete(T obj);        
        Task<UserSp> GetById(int id);
        Task<T> GetByIdOthers(int id);
    }
}
