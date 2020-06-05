using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookList.Model
{
    public class Book
    {
        [Key] //[Key is used for auto increment]
        public int Id { get; set; }
        [Required] //[Required] is used to require string, it means field cannot be empty
        public string Name { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }

    }
}
