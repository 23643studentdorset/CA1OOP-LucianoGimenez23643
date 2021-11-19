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
            BankAccount bankAcc1 = new BankAccount ("John", "Smith", "current", 50);
            BankAccount bankAcc2 = new BankAccount("John", "Smith", "savings", 150);
            Customer customer1 = new Customer("John", "Smith", "JhonSmith@gmail.com");
            customer1.addBankAccount(bankAcc1);
            customer1.addBankAccount(bankAcc2);
            List<string> listToWriteCustomers = new List<string>();
            listToWriteCustomers.Add(customer1.customerInfo());
            FileManaging.WriteFile("Customers.txt",listToWriteCustomers);
            FileManaging.WriteFile(bankAcc1.accountName + ".txt", bankAcc1.toStringList());
       

            Console.WriteLine("Welcome are you a customer or an employee?");
            bool flag = true;
            do
            {
                Console.WriteLine("Please, enter 1 or 2 if you are:");
                Console.WriteLine("1.Employee ");
                Console.WriteLine("2.Customer "); 
                string option = Console.ReadLine();
                if (option == "1")
                {
                    if (Employee.LogIn())
                    {
                        string option2;
                        do
                        {
                            Console.WriteLine("Enter one option");
                            Console.WriteLine("1. Create a new customer");
                            Console.WriteLine("2. Delete a customer");
                            Console.WriteLine("3. Lodge from an account");
                            Console.WriteLine("4. Withdraw from an account");
                            Console.WriteLine("5. Show list of all customers");
                            Console.WriteLine("6. Show customers with balance");
                            Console.WriteLine("0. To go back");
                            option2 = Console.ReadLine();
                            switch
                        } while (option2.Equals("0"));
                    }
                        flag = false;
                    
                }else if (option == "2")
                {
                    //do while
                    //Customer.LogIn();
                    flag = false;
                }else
                {
                    Console.WriteLine("The option entered is not a valid valid option");

                }
            } while (flag);

        }
    }
}
