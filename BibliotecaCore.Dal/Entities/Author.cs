using BibliotecaCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BibliotecaCore.Dal.Entities
{
    public class Author : BaseEntity
    {
        [Key]
        public int id { get; set; }

        [MaxLength(length: 50)]
        [Required]
        public string Name { get; set; }

        [MaxLength(length: 50)]
        [Required]
        public string LastName { get; set; }
        
        public DateTime Birthdate { get; set; }
        
        //public ICollection<Book> Books { get; set; }
    }
}
