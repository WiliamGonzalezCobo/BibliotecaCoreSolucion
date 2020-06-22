using BibliotecaCore.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaCore.Service.Interface
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();
        void Add(Category entityDb);
        void Update(Category entityDb);
        void Delete(Object id);
    }
}
