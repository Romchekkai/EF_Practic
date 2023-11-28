using EF_Practic.BLL.Models;
using EF_Practic.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Practic.PLL
{
    internal class OperationsOnUserMenuView
    {
        public void Show()
        {
            while (true)
            {
                Console.WriteLine("To registration user to the library press 1");
                Console.WriteLine("To update user name on Id press 2");
                Console.WriteLine("To delete user press 3");
                Console.WriteLine("To give book to user press 4");
                Console.WriteLine("To check books by user press 5");
                Console.WriteLine("To count books by user press 6");
                Console.WriteLine("Get books of user list press 7");
                Console.WriteLine("Go back press 8");

                string key = Console.ReadLine();

                if (key == "8") break;
                switch (key)
                {
                    case "1":
                        {
                            Program.userOperations.CreateUser();
                            break;
                        }
                    case "2":
                        {
                            Program.userOperations.UpdateUser();
                            break;
                        }

                    case "3":
                        {
                            Program.userOperations.DeleteUser();
                            break;
                        }

                    case "4":
                        {
                            Program.userOperations.GiveBookToUser();
                            break;
                        }

                    case "5":
                        {

                            Program.userOperations.CheckBookByUser();
                            break;
                        }

                    case "6":
                        {
                            Program.userOperations.CountBookByUser();
                            break;
                        }

                    case "7":
                        {
                            Program.userOperations.GetUserBooksList();
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
