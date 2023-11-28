using EF_Practic.BLL.Models;
using EF_Practic.BLL.Services;
using EF_Practic.DAL.Entities;
using EF_Practic.DAL.Repositories;
using EF_Practic.PLL;


namespace EF_Practic
{
    internal class Program
    {
        
        static UserService userService;
        static BookService bookService;
        public static OverseerMainView mainView;
        public static OperationsOnBookMenuView operationsOnBook;
        public static OperationsOnUserMenuView operationsOnUser;
        public static OperationsOnBooksView bookOperations;
        public static OperationsOnUsersView userOperations;
        static void Main(string[] args)
        {
            //baseRepository.DeleteDB();
            //baseRepository.CreateDB();
            userService = new UserService();
            bookService = new BookService();

            mainView = new OverseerMainView();

            bookOperations = new OperationsOnBooksView(bookService);
            userOperations = new OperationsOnUsersView(userService);
            operationsOnBook = new OperationsOnBookMenuView();
            operationsOnUser = new OperationsOnUserMenuView();

             while (true) 
             {
                 mainView.Show();
             } 
        }
    }
}



