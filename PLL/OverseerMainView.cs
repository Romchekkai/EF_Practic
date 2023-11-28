using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Practic.PLL
{
    internal class OverseerMainView
    {
        public void Show()
        {
            Console.WriteLine("Press 1: All operations on users");
            Console.WriteLine("Press 2: All operations on books");

            switch (Console.ReadLine()) 
            {
                case "1":
                    {
                        Program.operationsOnUser.Show();
                        break;
                    }
                case "2": 
                    {
                        Program.operationsOnBook.Show();
                        break;
                    }
                default: Console.WriteLine("Select 1 or 2");
                    break;
            }
        }
    }
}
