﻿using Microsoft.EntityFrameworkCore;
using SaleOfProducts.Models;
using SaleOfProducts.Repositories;
using SaleOfProducts.Services.IService;

namespace SaleOfProducts.Services.Service
{
    public class NameCharacteristicProductService : INameCharacteristicProductService
    {
        IPostgreSQLRepository<NameCharacteristicProduct> _repository;

        public NameCharacteristicProductService(IPostgreSQLRepository<NameCharacteristicProduct> repository)
        {
            _repository = repository;
        }

        public string Create(NameCharacteristicProduct item)
        {
            try
            {
                if (string.IsNullOrEmpty(item.Name))
                {
                    return "The name cannot be empty";
                }
                else
                {
                    _repository.Create(item);
                    return $"Created new item with this ID: {item.Id}";
                }
            }
            catch (Exception ex)
            {

                return $"An error occurred while creating the item: {ex.Message}";
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

        public IQueryable<NameCharacteristicProduct> GetAll()
        {
            return _repository.GetAll();
        }

        public IQueryable<object> GetAllWithCharacteristic()
        {
            var result = _repository.GetAll()
                .Include(p => p.ValueCharacteristicProducts)
                .Select(p => new
                {
                    Id = p.Id, // Устанавливаем идентификатор из базы данных
                    Name = p.Name,
                    ValueCharacteristicProducts = p.ValueCharacteristicProducts.Select(ncp => new
                    {
                        Name = ncp.Name,
                    }).ToList()
                });

            return result;
        }

        public NameCharacteristicProduct GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public string Update(Guid id, NameCharacteristicProduct item)
        {
            var _item = _repository.GetById(id);
            if (_item is not null)
            {
                _item.Name = item.Name;


                var result = _repository.Update(_item);
                if (result)
                    return "Item updated";
            }

            return "Item updated";
        }
    }
}
