using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreCodeFirstDemo.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public string? Description { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }
    }


    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
