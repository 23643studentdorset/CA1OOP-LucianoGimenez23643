using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1_LucianoGimenez_23643.Models
{
    public class Employee : Person
    {
        public static void LogIn()
        {

            Console.WriteLine("Please enter your pin");
            string pin = Console.ReadLine(); 
            if (pin.Equals ("A1234"))
            {
                Console.WriteLine("Hello");
            }
            else
            {
                Console.WriteLine("Pin incorrect");
            } 
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
