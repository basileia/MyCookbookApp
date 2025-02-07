﻿using System.Linq.Expressions;

namespace MyCookbook.Data.Contracts
{
    public interface IBaseRepository<T> where T : class
    {       
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
