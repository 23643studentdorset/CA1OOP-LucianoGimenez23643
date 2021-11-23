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
       //Method to Login as an employee return 1 to log in -1 to go out or pin incorrect
        public override int LogIn(List<Customer> CustomerList)
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
                    return -1;
                }
                else
                {
                    Console.WriteLine("Pin incorrect");
                }
            } while (flag == true);
            return 1;
        }

       //Method to create a customer instance
        public Customer CreateCustomer()
        {
            Console.WriteLine("Please enter first name");
            string fName = Console.ReadLine();
            Console.WriteLine("Please enter last name");
            string lName = Console.ReadLine();
            Console.WriteLine("Please enter email");
            string eMail = Console.ReadLine();
            Customer newCustomer = new Customer (fName, lName, eMail);
            Console.WriteLine("Customer Created successfully");
            return newCustomer;
        }
        
        //Method to delete a customer, it pop it out from the list of customers if it meets the requariments and returns
        //a new list of customers, and delete their file's accounts
        public List<Customer> DeleteCustomer(List<Customer> listOfCustomers)
        {
            List <Customer> copyListOfCustomers = new List<Customer>();
            foreach(Customer aCustomer in listOfCustomers)
            {
                copyListOfCustomers.Add(aCustomer);
            }
            bool flag = true;
                       
            Console.WriteLine("please, enter account number that would you would like to delete or  9 to go back" );
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
                        if (aCustomer.accounts[0].balance == 0 && aCustomer.accounts[1].balance == 0)
                        {
                            FileManaging.DeleteFile(aCustomer.accountNumber + "-Current.txt");
                            FileManaging.DeleteFile(aCustomer.accountNumber + "-Savings.txt");
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

        //Method to manage outputs takes a list of customers and returns the index of the customer with that account number
        public int searchCustomer(List<Customer> CustomerList)
        {
            int counter = 0;
            bool outputFlag = true;
            int index = 0;

            Console.WriteLine("Please enter the acount number or 9 to go back");
            string accountNumber = Console.ReadLine();
            if (accountNumber.Equals("9"))
            {
                return -1;
            }

            foreach (Customer aCustomer in CustomerList)
            {
                if (aCustomer.accountNumber.Equals(accountNumber))
                {
                    index = counter;
                    outputFlag = false;
                }
                counter++;
            }
            if (outputFlag)
            {
                Console.WriteLine($"The account {accountNumber} does not belong to one of our customers");
                return -1;
            }
            return index;
        }

        // Methods that returns strings with balances from all the customers
        public void ShowAccountWithBalances(List<Customer> CustomerList)
        {
            foreach (Customer aCustomer in CustomerList)
            {
                
                Console.WriteLine($"{aCustomer.accountNumber} {aCustomer.firstName} {aCustomer.lastName} Current balance: {aCustomer.accounts[0].balance} " +
                                  $"savings balance: {aCustomer.accounts[1].balance}");
            }
        }
    }
}
