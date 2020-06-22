using BibliotecaCore.Dal.Entities;
using BibliotecaCore.Domain.Repository;
using BibliotecaCore.Domain.Specification.EntitiesSpecifications;
using BibliotecaCore.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaCore.Service.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryService(IRepository<Category> categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        public void Add(Category entityDb)
        {
            _categoryRepository.Add(entityDb);
            _categoryRepository.Save();
            _categoryRepository.Dispose();
        }

        public void Delete(object id)
        {
            _categoryRepository.Delete(id);
            _categoryRepository.Save();
            _categoryRepository.Dispose();
        }

        public IEnumerable<Category> GetCategories()
        {
            return _categoryRepository.GetAll(new CategoryAllSpecifications());
        }


        public void Update(Category entityDb)
        {
            _categoryRepository.Update(entityDb);
            _categoryRepository.Save();
            _categoryRepository.Dispose();
        }
    }
}
