using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EF_Practic.BLL.Models
{
    internal class CreateBookData
    {
        public string Title { get; set; }
        public int YearofI { get; set; }
        public string Author { get; set; } 

        public string Genre { get; set; }
    }
}
