using BibliotecaCore.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BibliotecaCore.Domain.Specification.EntitiesSpecifications
{
    public class CategoryAllSpecifications : Specification<Category>
    {
        public override Expression<Func<Category, bool>> ToExpression()
        {
            return category => category.id == category.id;
        }
    }
}
