using System;
using System.Collections.Generic;
using System.Text;
using BibliotecaCore.Dal.Entities;

namespace BibliotecaCore.Service.Interface
{
    public  interface IBookService
    {
        IEnumerable<Book> GetBooks();
        Book GetBook(int id);
        void Add(Book entityDb);
        void Update(Book entityDb);
        void Delete(Object id);
    }
}
