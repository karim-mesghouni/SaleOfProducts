﻿using Microsoft.AspNetCore.Authentication;
using SaleOfProducts.Infrastructure;
using SaleOfProducts.Models.BaseClassModels;

namespace SaleOfProducts.Repositories
{
    public class PostgreSQLRepository<T> : IPostgreSQLRepository<T> where T : BaseEntity
    {
        readonly MemoryContext _context;
        public PostgreSQLRepository(MemoryContext bankContext)
        {
            _context = bankContext;
        }
        public bool Create(T item)
        {
            try
            {
                _context.Add(item);
                var result = _context.SaveChanges();
                return result > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(Guid id)
        {
            return _items.Remove(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _items.Values;
        }

        public T GetById(Guid id)
        {
            return _items.SingleOrDefault(w => w.Key == id).Value;
        }

        public bool Update(T item)
        {
            try
            {
                _items[item.Id] = item;
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }


}
