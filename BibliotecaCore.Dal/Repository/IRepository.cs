using BibliotecaCore.Domain.Entities;
using BibliotecaCore.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BibliotecaCore.Domain.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Get(Specification<T> specification);
        IEnumerable<T> GetAll(Specification<T> specification);
        void Add(T model);
        void Update(T model);
        void Delete(object id);
        void Save();
        void Dispose();

    }
}
