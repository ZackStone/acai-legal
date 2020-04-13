using AcaiLegal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcaiLegal.Domain.Interfaces.Services
{
    public interface IService<T> where T : BaseEntity
    {
        Task<T> Post(T obj);

        Task<T> Put(T obj);

        Task<T> Delete(Guid id);

        Task<T> Get(Guid id);

        Task<List<T>> GetAll();
    }
}