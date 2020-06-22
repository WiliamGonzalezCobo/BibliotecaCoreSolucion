using BibliotecaCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BibliotecaCore.Dal.Entities
{
    public class Category : BaseEntity
    {
        [Key]
        public int id { get; set; }

        [MaxLength(length: 50)]
        [Required]
        public string Name { get; set; }

        [MaxLength(length: 500)]
        [Required]
        public string Description { get; set; }

        //public ICollection<Book> Books { get; set; }
    }
}
