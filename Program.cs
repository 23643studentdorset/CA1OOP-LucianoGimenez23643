using CA1_LucianoGimenez_23643.Models;
using System;
using System.Collections.Generic;

namespace CA1_LucianoGimenez_23643
{
    class Program
    {
        static void Main(string[] args)
        {
            //test
            BankAccount b1 = new BankAccount ("John", "Smith", "current", 50);
            BankAccount b2 = new BankAccount("John", "Smith", "savings", 50);
            Customer c1 = new Customer("John", "Smith", "JhonSmith@gmail.com");
            c1.addBankAccount(b1);
            c1.addBankAccount(b2);
            FileManaging.WriteFile("Customers.txt", c1.customerInfo);

       

            Console.WriteLine("Welcome are you a customer or an employee?");
            bool flag = true;
            do
            {
                Console.WriteLine("Please, enter if you are:");
                Console.WriteLine("1.Employee ");
                Console.WriteLine("2.Customer "); 
                string option = Console.ReadLine();
                if (option == "1")
                {   
                    //do while
                    Employee.LogIn();
                    flag = false;

                }else if (option == "2")
                {
                    //do while
                    Customer.LogIn();
                    flag = false;
                }else
                {
                    Console.WriteLine("The option entered is not a valid valid option");

                }
            } while (flag);

        }
    }
}
