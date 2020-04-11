using AcaiLegal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AcaiLegal.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> Get(Guid id);

        Task<List<T>> GetAll();

        Task<T> Insert(T obj);

        Task<T> Update(T obj);

        Task<T> Delete(Guid id);
    }
}