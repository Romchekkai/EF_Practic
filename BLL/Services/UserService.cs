using EF_Practic.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_Practic.BLL.Models;
using System.ComponentModel.DataAnnotations;
using EF_Practic.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_Practic.BLL.Services
{
    internal class UserService
    {

        IUserRepository _userRepository;
        IBookRepository _bookRepository;
        public UserService()
        {
            
            _userRepository = new UserRepository();
            _bookRepository = new BookRepository();
        }

        public void CreateUser(RegistrationUserData userRegistrationData)
        {
            if (String.IsNullOrEmpty(userRegistrationData.Name))
                throw new ArgumentNullException();

            if (String.IsNullOrEmpty(userRegistrationData.Email))
                throw new ArgumentNullException();

            if (!new EmailAddressAttribute().IsValid(userRegistrationData.Email))
                throw new ArgumentNullException();
            if (_userRepository.FindByEmail(userRegistrationData.Email) != null)
                throw new ArgumentNullException();

            var userEntity = new UserEntity()
            {
                Name = userRegistrationData.Name,
                Email = userRegistrationData.Email,
            };

            if (this._userRepository.Create(userEntity) == 0)
                throw new Exception();
        }

        public User FindByEmail(string email)
        {
            var findUserEntity = _userRepository.FindByEmail(email);
            if (findUserEntity is null) { Console.WriteLine("User is not found");  throw new Exception(); }

            Console.WriteLine($"User name: {findUserEntity.Name}  User email {findUserEntity.Email}");
            return ConstructUserModel(findUserEntity);
        }

        public User FindById(int id)
        {
            var findUserEntity = _userRepository.FindById(id);
            if (findUserEntity is null) throw new Exception();

            var user = ConstructUserModel(findUserEntity);
            Console.WriteLine($"UserName: {user.Name}, User email: {user.Email}");

            return user;
        }

        public void Update(int user_id, string name)
        {

            if (this._userRepository.Update(user_id, name) == 0)
                throw new Exception();
        }

        public void DeleteUser(int id) 
        { 
            if (this._userRepository.FindById(id) is not null)
                this._userRepository.DeleteById(id);
            Console.WriteLine("User has been successfully deleted");
        }

        public void GiveBook(int id, int book_id)
        {
            this._userRepository.GiveBook(id, book_id);
        }

        public void DoesBookExistByUser(int id, int book_id)
        {
            var serсhedbook = this._bookRepository.FindById(book_id);
            var serсhedUser = this._userRepository.FindById(id);
            var boolSerched = this._userRepository.ifExistsBook(serсhedbook, serсhedUser);
            if (boolSerched) Console.WriteLine($"User has book: {serсhedbook.Title}");
        }

        public int CountBooksByUser(int id)
        {
            var serсhedUser = this._userRepository.FindById(id);
            var countBooks = this._userRepository.BooksCountOnUser(id);
            Console.WriteLine($"User {serсhedUser.Email} have {countBooks} books");
            return countBooks;
        }

        public List<Book> GetBooksByUserId(int userId)
        {
            var books = new List<Book>();
           /* var userEntituBooks = _userRepository.GetBooksByUserEntityId(userId);
            foreach (var  book in userEntituBooks)
            {
                books.Add(new Book(book.Id, book.Title, book.YearofI, book.Author, book.Genre));
            }*/
            _userRepository.GetBooksByUserEntityId(userId).ForEach(m =>
            {
                books.Add(new Book(m.Id, m.Title, m.YearofI, m.Author, m.Genre));
            });
            var user = _userRepository.FindById(userId);
            Console.WriteLine($"User {user.Name} has: ");
            foreach (var book in books)
            {
                Console.WriteLine($"Title {book.Title}, Year of publishing {book.YearofI}, Author {book.Author}, Genre {book.Genre} \n");
            }

            return books;
        }
        private User ConstructUserModel (UserEntity userEntity)
        {
            var booksOFUser = GetBooksByUserId(userEntity.Id);
            return new User(userEntity.Id, userEntity.Name,userEntity.Email, booksOFUser);
        }
    }
}
