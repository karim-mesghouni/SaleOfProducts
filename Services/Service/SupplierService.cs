﻿using Microsoft.EntityFrameworkCore;
using SaleOfProducts.Models;
using SaleOfProducts.Repositories;
using SaleOfProducts.Services.IService;

namespace SaleOfProducts.Services.Service
{
    public class SupplierService : ISupplierService
    {
        IPostgreSQLRepository<Supplier> _repository;

        public SupplierService(IPostgreSQLRepository<Supplier> repository)
        {
            _repository = repository;
        }

        public string Create(Supplier item)
        {
            if (string.IsNullOrEmpty(item.Name))
            {
                return "The name cannot be empty";
            }
            else
            {
                _repository.Create(item);
                _repository.SaveChangesAsync().Wait();
                return $"Created new item with this ID: {item.Id}";
            }
        }

        public string Delete(Guid id)
        {
            var result = _repository.Delete(id);
            if (result)
                return "Item deleted";
            else
                return "Item not found";
        }

        public IQueryable<Supplier> GetAll()
        {
            return _repository.GetAll();
        }

        public Supplier GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public string Update(Guid id, Supplier item)
        {
            var _item = _repository.GetById(id);
            if (_item is not null)
            {
                _item.Name = item.Name;
                _item.Address = item.Address;
                _item.State = item.State;
                _item.Status = item.Status;
                _item.INN = item.INN;
                _item.Phone = item.Phone;

                _repository.Update(_item);
                _repository.SaveChangesAsync().Wait();
                return "Item updated";
            }

            return "Item not found";
        }

        public async Task CreateAsync(Supplier supplier)
        {
            _repository.Create(supplier);
            await _repository.SaveChangesAsync();
        }
    }
}
