using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Practic.BLL.Models
{
    internal class Book
    {
        public int Id { get; }
        public string Title { get; set; }
        public int YearofI { get; set; }
        public string Author { get; set; } 
        public string Genre { get; set; }
        public Book(int id, string title, int yearofI, string author, string genre)
        {
            Id = id;
            Title = title;
            YearofI = yearofI;
            Author = author;
            Genre = genre;
        }
    }
}
