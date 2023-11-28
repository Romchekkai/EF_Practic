using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Practic.DAL.Repositories
{
    internal class BaseRepository
    {
        public PracticContext _context;

        public BaseRepository() { _context = new PracticContext(); }
        public void CreateContext()
        {
            _context = new PracticContext();
        }
        public void CreateDB()
        {
            _context.Database.EnsureCreated();
        }
        public void DeleteDB() 
        { 
            _context.Database.EnsureDeleted(); 
        }
        public void SaveDB()
        {
            _context.SaveChanges();
        }
    }
}
// public BaseRepository(PracticContext context)
//{
 //   _context = context;
//}
