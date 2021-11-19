using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1_LucianoGimenez_23643.Models
{
    //Class for Employee with all the methods for an employee to manage account and customers
    public class Employee : Person
    {
       
        public override bool LogIn()
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

       
        public Customer CreateCustomer()
        {
            Console.WriteLine("please enter first name");
            string fName = Console.ReadLine();
            Console.WriteLine("please enter last name");
            string lName = Console.ReadLine();
            Console.WriteLine("please enter email");
            string eMail = Console.ReadLine();
            Customer newCustomer = new Customer (fName, lName, eMail);
            Console.WriteLine("Customer Created successfully");
            return newCustomer;
        }
        
        public void DeleteCustomer(string Fname, string Lname)
        {

        }

        public void ShowAccountWithBalances()
        {

        }

        public void ShowCustomersAccounts()
        {

        }
    }
}
