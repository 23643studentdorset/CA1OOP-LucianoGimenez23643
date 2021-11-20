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
        
        //Method to delete a customer it pop it out from the list of customers if it meets the requariments and returns a new list of customers
        public List<Customer> DeleteCustomer(List<Customer> listOfCustomers)
        {
            
            List <Customer> copyListOfCustomers = new List<Customer>(listOfCustomers);
            bool flag = true;
            
            
            Console.WriteLine("please enter account number that would you would like to delete or  9 to go back" );
            string accountNumberToDelete  = Console.ReadLine();

            if (accountNumberToDelete.Equals("9"))
            {
                return listOfCustomers;
            }
            else
            {
                int index = 0;
                foreach (Customer aCustomer in copyListOfCustomers)
                {

                    if (aCustomer.accountNumber.Equals(accountNumberToDelete))
                    {
                        if (aCustomer.accounts[0].balance != 0 && aCustomer.accounts[1].balance != 0)
                        {
                            listOfCustomers.RemoveAt(index);
                            return listOfCustomers;
                        }
                        else
                        {
                            Console.WriteLine($"You can not remove the account {accountNumberToDelete} the balance it is not in 0");
                        }
                        flag = false;
                    }
                    index++;
                }
                if (flag)
                {
                    Console.WriteLine($"The account {accountNumberToDelete} does not belong to one of our customers");
                }
                
                return listOfCustomers;

            }

        }

        public void ShowAccountWithBalances()
        {

        }

        public void ShowCustomersAccounts()
        {

        }
    }
}
