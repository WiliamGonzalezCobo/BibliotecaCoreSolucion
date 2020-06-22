using BibliotecaCore.Domain.Context;
using BibliotecaCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BibliotecaCore.Dal.Entities
{
    public class Book : BaseEntity
    {
        [Key]
        public int id { get; set; }

        [MaxLength(length: 50)]
        [Required]
        public string title { get; set; }

        [MaxLength(length: 50)]
        [Required]
        public string ISBN { get; set; }

        public int Authorid { get; set; }

        [NavigationProperty]
        public virtual Author Author { get; set; }

        public int Categoryid { get; set; }
        [NavigationProperty]
        public virtual Category Category { get; set; }
    }
}
