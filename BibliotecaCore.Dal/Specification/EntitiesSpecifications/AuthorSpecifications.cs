using BibliotecaCore.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BibliotecaCore.Domain.Specification.EntitiesSpecifications
{
    public class AuthorAllSpecifications : Specification<Author>
    {
        public override Expression<Func<Author, bool>> ToExpression()
        {
            return author => author.id == author.id;
        }
    }
}
