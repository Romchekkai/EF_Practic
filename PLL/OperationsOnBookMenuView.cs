using EF_Practic.BLL.Models;
using EF_Practic.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Practic.PLL
{
    internal class OperationsOnBookMenuView
    {
        public void Show()
        {
            while (true) 
            {
                Console.WriteLine("To add book to the library press 1");
                Console.WriteLine("To update book by year of publishing press 2");
                Console.WriteLine("To delete book press 3");
                Console.WriteLine("Get books list press 4");
                Console.WriteLine("To find books between data press 5");
                Console.WriteLine("Get books count by author press 6");
                Console.WriteLine("Get books count by genre press 7");
                Console.WriteLine("Check books by author and genre press 8");
                Console.WriteLine("Get last year of publishing book press 9");
                Console.WriteLine("Get list of books by title press 10");
                Console.WriteLine("Get list of books by year of publishing press 11");
                Console.WriteLine("Go back press 12");

                string key = Console.ReadLine();

                if (key == "12") break;
                switch (key)
                {
                    case "1":
                        {
                            Program.bookOperations.AddBookToLibrary();
                            break;
                        }
                    case "2":
                        {
                            Program.bookOperations.UpdateBook();
                            break;
                        }

                    case "3":
                        {
                            Program.bookOperations.DeleteBook();
                            break;
                        }

                    case "4":
                        {
                            Program.bookOperations.GetBooksList();
                            break;
                        }

                    case "5":
                        {

                            Program.bookOperations.FindBooksBetweenDatesandGenre();
                            break;
                        }

                    case "6":
                        {
                            Program.bookOperations.GetBooksCountByAuthor();
                            break;
                        }

                    case "7":
                        {
                            Program.bookOperations.GetBooksCountByGenre();
                            break;
                        }
                    case "8":
                        {
                            Program.bookOperations.ifExistsByAuthorAndGenre();
                            break;
                        }
                    case "9":
                        {
                            Program.bookOperations.GetLastYearOfIBook();
                            break;
                        }
                    case "10":
                        {
                            Program.bookOperations.GetBooksByTitleAsc();
                            break;
                        }
                    case "11":
                        {
                            Program.bookOperations.GetBooksByYearOFIDesc();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Enter correct value:");
                            break;
                        }
                }
            }
        }
    }
}
