using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Practic.DAL.Entities
{
    internal class BookEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int YearofI { get; set; }
        public string Author { get; set; } //Можно создать отдельную сущность

        public string Genre { get; set; } // Нельзя совместить к примеру повесть и поэму (или я неверно понял вопрос задния 25.4.3)


    }
}
