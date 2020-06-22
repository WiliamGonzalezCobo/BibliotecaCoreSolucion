using BibliotecaCore.Dal.Entities;
using BibliotecaCore.Dal.Migrations;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BibliotecaCore.Domain.Specification.EntitiesSpecifications
{
    public class BookByIdSpecifications : Specification<Book>
    {
        private readonly int _id;
        public BookByIdSpecifications(int id)
        {
            _id = id;
        }

        public override Expression<Func<Book, bool>> ToExpression()
        {
            return book => book.id.Equals(_id);
        }
    }

    public class BookAllSpecifications : Specification<Book>
    {
        public override Expression<Func<Book, bool>> ToExpression()
        {
            return book => book.id == book.id;
        }
    }
}
