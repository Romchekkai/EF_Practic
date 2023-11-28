using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_Practic.DAL.Entities;
using EF_Practic.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace EF_Practic.DAL.Repositories
{
    internal class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository() { CreateContext(); }
         public int Create(UserEntity userEntity)
        {
            int check = 0;
            
            if(userEntity != null)
            {
                _context.Users.Add(userEntity);
                SaveDB();
                check = 1;
            }
            return check;
        }

        public UserEntity FindByEmail(string email)
        {
            var searched_user = _context.Users.Where(e => e.Email == email).FirstOrDefault();
            if (searched_user != null)
            {  return searched_user; }
            return null;
        }

        public IEnumerable<UserEntity> FindAll() 
        {
            var users = _context.Users.ToList();
            return users;
        }

        public UserEntity FindById(int id)
        {
            var searched_user = _context.Users.Where(i  => i.Id == id).FirstOrDefault();
            return searched_user;
        }

        public int Update(int user_id, string name)
        {
            int check = 0;
            var updatableUser = _context.Users.Where(u=> u.Id == user_id).FirstOrDefault();

            if (updatableUser != null) 
            {
                updatableUser.Name = name;
                SaveDB();
                check = 1;
            }
            return check; 
        }

        public int DeleteById(int id)
        {
            int check = 0;
            var deletedUser = _context.Users.Where(u => u.Id == id).FirstOrDefault();
            if (deletedUser != null) 
            {
                _context.Users.Remove(deletedUser);
                SaveDB();
                check = 1;
            }
            return check;
        }

        public int GiveBook(int id, int book_id)
        {
            int check = 0;
            var user_who_get = FindById(id);
            var book_to_pass = _context.Books.Where(b => b.Id == book_id).FirstOrDefault();

            if (book_to_pass != null && user_who_get != null)
            {
                user_who_get.Books.Add(book_to_pass);
                check = 1;
                SaveDB();
                Console.WriteLine($"The book data: {book_to_pass.Title}");
            }

            return check;
        }
        public bool ifExistsBook(BookEntity bookEntity, UserEntity userEntity)
        {
            var check = _context.Users.Include(u => u.Books).Any(u => u.Id == userEntity.Id && u.Books.Contains(bookEntity));
            return check;
        }
        
        public int BooksCountOnUser(int id)
        {
            var ind = _context.Users.Where(u => u.Id == id).FirstOrDefault();
            return ind.Books.Count();
        }
        public List<BookEntity> GetBooksByUserEntityId(int userId)
        {
            var finding_user = _context.Users.Include(u => u.Books).Where(u => u.Id == userId).FirstOrDefault();

            var userbooks = finding_user.Books.ToList();

            return userbooks;
        }


    }

    internal interface IUserRepository
    {
        int Create(UserEntity userEntity);
        UserEntity FindByEmail(string email);
        IEnumerable<UserEntity> FindAll();
        UserEntity FindById(int id);
        int Update(int user_id, string name);
        int DeleteById(int id);
        int GiveBook(int id, int book_id);
        bool ifExistsBook(BookEntity bookEntity, UserEntity userEntity);
        int BooksCountOnUser(int id);
        List<BookEntity> GetBooksByUserEntityId(int userId);
    }
}

//public UserRepository(PracticContext context)  //_context.Users.Where(u => u.Id == userEntity.Id).FirstOrDefault();
//{
//   _context = context;  // _context.Books.Where(b=> b.Id == bookEntity.Id).FirstOrDefault();
//}