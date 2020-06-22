using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaCore.Domain.Context
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public class NavigationPropertyAttribute : Attribute
    {
        public NavigationPropertyAttribute()
        {
        }
    }
}
