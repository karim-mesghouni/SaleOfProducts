﻿using SaleOfProducts.Models;
using SaleOfProducts.Repositories;

namespace SaleOfProducts.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly MemoryContext _dbContext;

        public EmployeeService(MemoryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string Create(Employee worker)
        {
            throw new NotImplementedException();
        }

        public string Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public Employee GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public string Update(Guid id, Employee item)
        {
            throw new NotImplementedException();
        }
    }
}
