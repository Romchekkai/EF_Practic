using EF_Practic.DAL.Entities;
using EF_Practic.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Practic.DAL.Repositories
{
    internal class BookRepository: BaseRepository, IBookRepository
    {
        public BookRepository() { CreateContext(); }
        public int Create(BookEntity bookEntity)
        {
            int check = 0;

            if (bookEntity != null)
            {
                _context.Books.Add(bookEntity);
                SaveDB();
                check = 1;
            }
            return check;
        }

        public IEnumerable<BookEntity> FindAll()
        {
            var books = _context.Books.ToList();
            foreach (var book in books)
            {
                Console.WriteLine($"Title {book.Title}, Year of publishing {book.YearofI}, Author {book.Author}, Genre {book.Genre} \n");
            }
            return books;
        }

        public BookEntity FindById(int id)
        {
            var searched_book = _context.Books.Where(i => i.Id == id).FirstOrDefault();
            if(searched_book != null)
            {
                return searched_book;
            }
            return null;
        }

        public int Update(int bookID, int year)
        {
            int check = 0;
            var updatableBook = _context.Books.Where(b =>  b.Id == bookID).FirstOrDefault();
            if (updatableBook != null)
            {
                updatableBook.YearofI = year;
                SaveDB();
                check = 1; //поменять местами с 0
                Console.WriteLine($"UpdatableBook: Title {updatableBook.Title}, Year of publishing {updatableBook.YearofI}, Author {updatableBook.Author}, Genre {updatableBook.Genre} ");
            }
            return check;
        }

        public int DeleteById(int id)
        {
            int check = 0;
            var deletedBook = _context.Books.Where(b =>b.Id == id).FirstOrDefault();
            if (deletedBook != null)
            {
                _context.Books.Remove(deletedBook);
                SaveDB();
                Console.WriteLine("The book has been deleted");
                check = 1;
            }
            return check;
        }

        public List<BookEntity> findBooksBetweenDates(int start, int end, string genre)
        {
            return _context.Books.Where(g => g.Genre == genre && g.YearofI >= start && g.YearofI <=end).ToList();
        }

        public int GetBooksCountByAuthor(string author)
        {
            return _context.Books.Where(a => a.Author == author).Count();
        }

        public int GetBooksCountByGenre(string genre)
        {
            return _context.Books.Where(g => g.Equals(genre)).Count();
        }

        public bool ifExistsByAuthorAndGenre(string author, string genre)
        {
            var ex = _context.Books.Any(b => b.Author ==author && b.Genre==genre);
            if(ex) { Console.WriteLine("True"); }
            return ex;
        }

        public BookEntity GetLastYearOfIBook()
        {
            var z = _context.Books.Max(b => b.YearofI);
            var table =_context.Books.Where(u=> u.YearofI== z).FirstOrDefault();
            if (table is not null)
            {
                return table;
            }
            return null;
        }

        public List<BookEntity> GetBooksByTitleAsc()
        {
            return _context.Books.OrderBy(a => a.Title).ToList();
        }

        public List<BookEntity> GetBooksByYearOFIDesc()
        {
            return _context.Books.OrderByDescending(a => a.YearofI).ToList();
        }
    }

    internal interface IBookRepository
    {
        int Create(BookEntity bookEntity);
        IEnumerable<BookEntity> FindAll();
        BookEntity FindById(int id);
        int Update(int bookID, int year);
        int DeleteById(int id);
        List<BookEntity> findBooksBetweenDates(int start, int end, string genre);
        int GetBooksCountByAuthor(string author);
        int GetBooksCountByGenre(string genre);
        bool ifExistsByAuthorAndGenre(string author, string genre);
        public BookEntity GetLastYearOfIBook();
        List<BookEntity> GetBooksByTitleAsc();
        List<BookEntity> GetBooksByYearOFIDesc();
    }
}

//public BookRepository(PracticContext context)
//{
 //   _context = context;
//}