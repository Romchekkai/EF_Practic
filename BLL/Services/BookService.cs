using EF_Practic.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_Practic.DAL.Entities;
using EF_Practic.BLL.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace EF_Practic.BLL.Services
{
    internal class BookService
    {
        IBookRepository _bookRepository;

        public BookService()
        {
            _bookRepository = new BookRepository();
        }

        public void CreateBook(CreateBookData creating_book)
        {
            if (String.IsNullOrEmpty(creating_book.Title))
                throw new ArgumentNullException();

            if(creating_book.YearofI<0 && creating_book.YearofI> 3000)
                throw new ArgumentNullException();

            if (String.IsNullOrEmpty(creating_book.Author))
                throw new ArgumentNullException();

            if (String.IsNullOrEmpty(creating_book.Genre))
                throw new ArgumentNullException();

            var bookEntity = new BookEntity()
            {
                Title = creating_book.Title,
                YearofI = creating_book.YearofI,
                Author = creating_book.Author,
                Genre = creating_book.Genre,
                
            };

            if (this._bookRepository.Create(bookEntity) == 0)
                throw new Exception();
        }

        public void FindAllBooks()
        {
            this._bookRepository.FindAll(); //часть метода можно было перенести сюда
        }

        public Book FindBookById(int id)
        {
            var serhedBook = this._bookRepository.FindById(id); //часть метода можно было перенести сюда
            if (serhedBook is null) throw new Exception();

            return ConstructBookModel(serhedBook);
        }

        public void Update(int bookID, int year)
        {

            if (this._bookRepository.Update(bookID, year) == 0)
                throw new Exception();
        }

        public void DeleteBook(int id) 
        { 
            if(this._bookRepository.FindById(id) is not null)
            this._bookRepository.DeleteById(id);
        
        }

        public List<Book> FindBooksBetweenDates(int start, int end, string genre)
        {
            var books = new List<Book>();
            var serchedBooks = this._bookRepository.findBooksBetweenDates(start, end, genre);
            foreach (var book in serchedBooks)
            {
                books.Add(new Book(book.Id,book.Title,book.YearofI,book.Genre,book.Author));
            }
            int n = 1;
            foreach (var book in books)
            {
                Console.WriteLine($" {n} Title { book.Title}, Year of publishing { book.YearofI}, Author { book.Author}, Genre { book.Genre} \n");
                n++;
            }
            return books;
        }

        public int GetBooksCountByAuthor(string author)
        {
            var counterBook = this._bookRepository.GetBooksCountByAuthor(author);
            Console.WriteLine($"The numbers of books by {author}: {counterBook}");
            return counterBook;
        }

        public int GetBooksCountByGenre(string genre)
        {
            var counterBook = this._bookRepository.GetBooksCountByGenre(genre);
            Console.WriteLine($"The numbers of books of {genre}: {counterBook}");
            return counterBook;
        }

        public bool ifExistsByAuthorAndGenre(string author, string genre)
        {
            var existing_book = this._bookRepository.ifExistsByAuthorAndGenre(author, genre);
            return existing_book;
        }

        public Book GetLastYearOfIBook()
        {
            var BookOfmaxYearPublishing = this._bookRepository.GetLastYearOfIBook();
            if (BookOfmaxYearPublishing is null) throw new Exception();
            var book = ConstructBookModel(BookOfmaxYearPublishing);
            Console.WriteLine($"Title {book.Title}, Year of publishing {book.YearofI}, Author {book.Author}, Genre {book.Genre}");
            return ConstructBookModel(BookOfmaxYearPublishing);
        }

        public List<Book> GetBooksByTitleAsc()
        {
            var books = new List<Book>();
            var serchedBooks = this._bookRepository.GetBooksByTitleAsc();
            foreach (var book in serchedBooks)
            {
                books.Add(new Book(book.Id, book.Title, book.YearofI, book.Genre, book.Author));
            }
            int n = 1;
            foreach (var book in books)
            {
                Console.WriteLine($" {n} Title {book.Title}, Year of publishing {book.YearofI}, Author {book.Author}, Genre {book.Genre} \n");
                n++;
            }
            return books;
        }

        public List<Book> GetBooksByYearOFIDesc()
        {
            var books = new List<Book>();
            var serchedBooks = this._bookRepository.GetBooksByYearOFIDesc();
            foreach (var book in serchedBooks)
            {
                books.Add(new Book(book.Id, book.Title, book.YearofI, book.Genre, book.Author));
            }
            int n = 1;
            foreach (var book in books)
            { 
                Console.WriteLine($" {n} Title {book.Title}, Year of publishing {book.YearofI}, Author {book.Author}, Genre {book.Genre} \n");
                n++;
            }
            return books;
        }

        private Book ConstructBookModel(BookEntity bookEntity)
        {
            return new Book(bookEntity.Id, bookEntity.Title, bookEntity.YearofI, bookEntity.Genre, bookEntity.Author);
        }

    }
}
