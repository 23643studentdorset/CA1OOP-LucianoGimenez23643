using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1_LucianoGimenez_23643.Models
{
    public class Employee : Person
    {
        public static bool LogIn()
        {
            bool flag = true;
            do
            {
                Console.WriteLine("Please enter your pin or 9 to go back");
                string pin = Console.ReadLine();
                if (pin.Equals("A1234"))
                {
                    Console.WriteLine("Hello");
                    flag = false;
                }
                else if (pin.Equals("9"))
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Pin incorrect");
                }
            } while (flag == true);
            return true;
        }

       
        public void CreateCustomer(string FName, string LName, string Email)
        {

        }
        
        public void DeleteCustomer(string Fname, string Lname)
        {

        }

        public void ShowAccountBalances()
        {

        }

        public void ShowAccountsNumbers()
        {

        }
    }
}
