using BibliotecaCore.Dal.Entities;
using BibliotecaCore.Domain.Repository;
using BibliotecaCore.Domain.Specification.EntitiesSpecifications;
using BibliotecaCore.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaCore.Service.Implementation
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepository<Author> _authorRepository;

        public AuthorService(IRepository<Author> authorRepository) {
            this._authorRepository = authorRepository;
        }

        public void Add(Author entityDb)
        {
            _authorRepository.Add(entityDb);
            _authorRepository.Save();
            _authorRepository.Dispose();
        }

        public void Delete(object id)
        {
            _authorRepository.Delete(id);
            _authorRepository.Save();
            _authorRepository.Dispose();
        }

        public IEnumerable<Author> GetAuthors()
        {
            return _authorRepository.GetAll(new AuthorAllSpecifications());
        }

        public void Update(Author entityDb)
        {
            _authorRepository.Update(entityDb);
            _authorRepository.Save();
            _authorRepository.Dispose();
        }
    }
}
