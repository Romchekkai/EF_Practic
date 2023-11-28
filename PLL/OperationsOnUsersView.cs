using EF_Practic.BLL.Models;
using EF_Practic.BLL.Services;
using EF_Practic.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EF_Practic.PLL
{
    internal class OperationsOnUsersView
    {
        UserService userService;
        public OperationsOnUsersView(UserService userService)
        {
            this.userService = userService;
        }

        public void CreateUser()
        {
            var userRegistrationData = new RegistrationUserData();
            Console.WriteLine("Enter name to create a new user:");
            userRegistrationData.Name = Console.ReadLine();

            Console.Write("Email:");
            userRegistrationData.Email = Console.ReadLine();
            try
            {
                userService.CreateUser(userRegistrationData);

                Console.WriteLine("The user has been successfully created in the library.");
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

        public void UpdateUser() 
        {
            Console.WriteLine("Enter userID to update userName");
            int userID = Convert.ToInt32(Console.ReadLine());
            try
            {
                userService.FindById(userID);
            }
            catch (Exception) { Console.WriteLine("An error occurred during searching."); }

            Console.WriteLine("Enter new UserName :");
            string userName = Console.ReadLine();
            try
            {
                userService.Update(userID, userName);
                Console.WriteLine("UserName has been successfully update");
                userService.FindById(userID);
            }
            catch (Exception) { Console.WriteLine("An error occurred during updating."); }
        }

        public void DeleteUser() 
        {
            Console.WriteLine("Enter userID to delete user");
            int userID = Convert.ToInt32(Console.ReadLine());
            try
            {
                userService.DeleteUser(userID);
                Console.WriteLine("Check");
                userService.FindById(userID);
            }
            catch (Exception) { Console.WriteLine("An error occurred during deleting."); }
        }

        public void GiveBookToUser()
        {
            Console.WriteLine("Enter the user ID to transfer the book:");
            int userID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the book ID:");
            int bookID = Convert.ToInt32(Console.ReadLine());

            try
            {
                userService.GiveBook(userID, bookID);
                Console.WriteLine("The book transfered to user");
            }
            catch (Exception) { Console.WriteLine("An error occurred during registration."); }
        }

        public void CheckBookByUser()
        {
            Console.WriteLine("Enter the user ID to check the book by user:");
            int userID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the book ID:");
            int bookID = Convert.ToInt32(Console.ReadLine());

            try
            {
                userService.DoesBookExistByUser(userID,bookID);
            }
            catch (Exception) { Console.WriteLine("An error occurred during searching book by user."); }
        }

        public void CountBookByUser()
        {
            Console.WriteLine("Enter the user ID to count his books:");
            int userID = Convert.ToInt32(Console.ReadLine());
            try
            {
                userService.CountBooksByUser(userID);
            }
            catch (Exception) { Console.WriteLine("An error occurred during searching book by user."); }
        }

        public void GetUserBooksList()
        {
            Console.WriteLine("Enter the user ID to get his BooksList:");
            var findinguser = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("The list of UserBooks:");
            userService.GetBooksByUserId(findinguser);
        }
    }
}
