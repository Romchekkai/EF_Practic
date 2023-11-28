using EF_Practic.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Practic.BLL.Models
{
    internal class User
    {
        public int Id { get; }
        public string Name { get; set; }
        public string Email { get; set; }

        public List<Book> Books { get; } = new List<Book>();

        public User(int id, string name, string email, List<Book> books)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Books = books;
        }
    }
}
