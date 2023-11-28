using EF_Practic.BLL.Models;
using EF_Practic.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Practic.PLL
{
    internal class OperationsOnBooksView
    {
        BookService bookService;
        public OperationsOnBooksView(BookService bookService)
        {
            this.bookService = bookService;
        }

        public void AddBookToLibrary()
        {
            var bookCreateData = new CreateBookData();
            Console.WriteLine("Enter Title to create a new book:");
            bookCreateData.Title = Console.ReadLine();

            Console.WriteLine("Year of publishing:");
            bookCreateData.YearofI = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Author:");
            bookCreateData.Author = Console.ReadLine();

            Console.WriteLine("Genre:");
            bookCreateData.Genre = Console.ReadLine();

            try
            {
                bookService.CreateBook(bookCreateData);

                Console.WriteLine("The user has been successfully added to the library.");
            }

            catch (ArgumentNullException)
            {
                Console.WriteLine("Please enter a valid value.");
            }

            catch (Exception)
            {
                Console.WriteLine("An error occurred during registration.");
            }
        }

        public void UpdateBook()
        {
            Console.WriteLine("Enter bookID to update Year of publishing");
            int bookID = Convert.ToInt32(Console.ReadLine());
            try
            {
                var book = bookService.FindBookById(bookID);
                Console.WriteLine($"Book : {book.Title}, {book.YearofI}");
            }
            catch (Exception) { Console.WriteLine("An error occurred during searching."); }

            Console.WriteLine("Enter new Year of publishing:");
            int year_new = Convert.ToInt32(Console.ReadLine());
            try
            {
                bookService.Update(bookID, year_new);
                Console.WriteLine("Year of publishing has been successfully update");
                var book = bookService.FindBookById(bookID);
                Console.WriteLine($"Book : {book.Title}, {book.YearofI}");
            }
            catch (Exception) { Console.WriteLine("An error occurred during updating."); }
        }

        public void DeleteBook()
        {
            Console.WriteLine("Enter bookID to delete book");
            int bookID = Convert.ToInt32(Console.ReadLine());
            try
            {
                bookService.DeleteBook(bookID);
            }
            catch (Exception) { Console.WriteLine("An error occurred during deleting."); }
        }

        public void GetBooksList()
        {
            try
            {
                bookService.FindAllBooks();
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred during GetBooksList processing.");
            }
        }

        public void FindBooksBetweenDatesandGenre()
        {
            Console.WriteLine("Enter genre");
            string genre = Console.ReadLine();
            Console.WriteLine("Enter year from");
            int yearfrom = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter year to");
            int yearto = Convert.ToInt32(Console.ReadLine());

            try
            {
                bookService.FindBooksBetweenDates(yearfrom, yearto, genre);
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred during FindBooks processing.");
            }
        }
        public void GetBooksCountByAuthor()
        {
            Console.WriteLine("Enter Author to get count book:");
            string author = Console.ReadLine();

            try
            {
                bookService.GetBooksCountByAuthor(author);
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred during GetBooksCountByAuthor processing.");
            }
        }

        public void GetBooksCountByGenre()
        {
            Console.WriteLine("Enter genre to get count book:");
            string genre = Console.ReadLine();

            try
            {
                bookService.GetBooksCountByGenre(genre);
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred during GetBooksCountByAuthor processing.");
            }
        }

        public void ifExistsByAuthorAndGenre()
        {
            Console.WriteLine("Enter author to find book:");
            string author = Console.ReadLine();
            Console.WriteLine("Enter genre to find book:");
            string genre = Console.ReadLine();

            try
            {
                bookService.ifExistsByAuthorAndGenre(author, genre);
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred during ifExistsByAuthorAndName processing.");
            }
        }

        public void GetLastYearOfIBook()
        {
            try
            {
                var book = bookService.GetLastYearOfIBook();
                Console.WriteLine($"Max Year book : Title {book.Title}, Year of publishing {book.YearofI}, Author {book.Author}, Genre {book.Genre}");
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred during GetLastYearOfIBook processing.");
            }
        }

        public void GetBooksByTitleAsc()
        {
            try
            {
                Console.WriteLine("The list of books:");
                bookService.GetBooksByTitleAsc();
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred during GetBooksByTitleAsc processing.");
            }
        }

        public void GetBooksByYearOFIDesc()
        {
            try
            {
                Console.WriteLine("The list of books by year:");
                bookService.GetBooksByYearOFIDesc();
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred during GetBooksByTitleAsc processing.");
            }
        }
    }
}
