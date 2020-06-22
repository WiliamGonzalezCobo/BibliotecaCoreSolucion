using BibliotecaCore.Dal.Entities;
using BibliotecaCore.Domain.Repository;
using BibliotecaCore.Domain.Specification.EntitiesSpecifications;
using BibliotecaCore.Service.Interface;
using System;
using System.Collections.Generic;

namespace BibliotecaCore.Service.Implementation
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> bookRepository;

        public BookService(IRepository<Book> bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public Book GetBook(int id)
        {
            return bookRepository.Get(new BookByIdSpecifications(id));
        }

        public IEnumerable<Book> GetBooks()
        {
            return bookRepository.GetAll(new BookAllSpecifications()); ;
        }

        public void Add(Book entityDb)

        {
            bookRepository.Add(entityDb);
            bookRepository.Save();
            bookRepository.Dispose();
        }

        public void Update(Book entityDb)

        {
            bookRepository.Update(entityDb);
            bookRepository.Save();
            bookRepository.Dispose();
        }

        public void Delete(Object id)
        {
            bookRepository.Delete(id);
            bookRepository.Save();
            bookRepository.Dispose();
        }

    }
}
