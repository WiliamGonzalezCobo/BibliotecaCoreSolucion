using BibliotecaCore.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaCore.Service.Interface
{
    public interface IAuthorService
    {
        IEnumerable<Author> GetAuthors();
        void Add(Author entityDb);
        void Update(Author entityDb);
        void Delete(Object id);
    }
}
