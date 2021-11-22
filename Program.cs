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
            /*
                BankAccount bankAcc1 = new BankAccount ("John", "Smith", "current", 50);
                BankAccount bankAcc2 = new BankAccount("John", "Smith", "savings", 150);
                Customer customer1 = new Customer("John", "Smith", "JhonSmith@gmail.com");
                customer1.addBankAccount(bankAcc1);
                customer1.addBankAccount(bankAcc2);
                List<string> listToWriteCustomers = new List<string>();
                listToWriteCustomers.Add(customer1.customerInfo());
                FileManaging.WriteFile("Customers.txt",listToWriteCustomers);
                FileManaging.WriteFile(bankAcc1.accountName + ".txt", bankAcc1.toStringList());
            */
            
            //Create Customer.txt
            
            List<string> CustomersFileList = new List<string>();
            
            FileManaging.WriteFile("Customers.txt", CustomersFileList);
            List<Customer> CustomerList = new List<Customer>();

            Console.WriteLine("Welcome are you a customer or an employee?");
            bool flag = true;
            //Do While to chose access Employee or Customer privileges
            do
            {
                Console.WriteLine("Please, enter 1 or 2 if you are:");
                Console.WriteLine("1.Employee ");
                Console.WriteLine("2.Customer "); 
                string option = Console.ReadLine();
                if (option == "1")
                {
                    Employee dummyEmployee = new Employee();
                    if (dummyEmployee.LogIn(CustomerList) == 1)
                    {
                        string option2 = "";
                        //Do while with options to execute Employee privileges
                        do
                        {

                            Console.WriteLine("Plase, Enter an option");
                            Console.WriteLine("1. Create a new customer");
                            Console.WriteLine("2. Delete a customer");
                            Console.WriteLine("3. Lodge to an account");
                            Console.WriteLine("4. Withdraw from an account");
                            Console.WriteLine("5. Show list of all customers");
                            Console.WriteLine("6. Show customers with balance");
                            Console.WriteLine("9. To go back");
                            option2 = Console.ReadLine();
                            switch (option2)
                            {
                                case "1": //Create a customer
                                    {
                                        Customer dummyCustomer = dummyEmployee.CreateCustomer();
                                        

                                        BankAccount accountCurrent = new BankAccount(dummyCustomer.firstName, dummyCustomer.lastName, "Current", 0);
                                        BankAccount accountSavings = new BankAccount(dummyCustomer.firstName, dummyCustomer.lastName, "Savings", 0);

                                        dummyCustomer.attachBankAccountToCustomer(accountCurrent);
                                        dummyCustomer.attachBankAccountToCustomer(accountSavings);
                                        dummyCustomer.setPin();

                                        List<string> emtyList = new List<string>();
                                        FileManaging.WriteFile(accountCurrent.accountNumber + "-" + accountCurrent.type + ".txt", accountCurrent.toStringList(emtyList));
                                        FileManaging.WriteFile(accountSavings.accountNumber + "-" + accountSavings.type + ".txt", accountSavings.toStringList(emtyList));

                                        CustomerList.Add(dummyCustomer);
                                        CustomersFileList = FileManaging.ListCustomersToString(CustomerList);
                                        FileManaging.WriteFile("Customers.txt", CustomersFileList);
                                        //Console.WriteLine(dummyCustomer.pin);
                                        Console.WriteLine();
                                        break;
                                    }
                                case "2": //Delete a customer
                                    {

                                        List<Customer> newCustomerList = new List<Customer>();
                                        foreach (Customer aCustomer in dummyEmployee.DeleteCustomer(CustomerList))
                                        {
                                            newCustomerList.Add(aCustomer);
                                        }

                                        CustomersFileList = FileManaging.ListCustomersToString(newCustomerList);
                                        FileManaging.WriteFile("Customers.txt", CustomersFileList);

                                        Console.WriteLine();
                                        break;
                                    }
                                case "3": //Lodge
                                    {
                                        int index = 0;
                                        index = dummyEmployee.searchCustomer(CustomerList);
                                        if (index == -1)
                                        {
                                            Console.WriteLine();
                                            break;
                                        }
                                        else
                                        {
                                            dummyEmployee.Lodge(CustomerList, index);
                                            Console.WriteLine();
                                            break;
                                        }

                                    }
                                case "4": //Withdraw
                                    {
                                        int index = 0;
                                        index = dummyEmployee.searchCustomer(CustomerList);
                                        if (index == -1)
                                        {
                                            Console.WriteLine();
                                            break;
                                        }
                                        else
                                        {
                                            dummyEmployee.Withdraw(CustomerList, index);
                                            Console.WriteLine();
                                            break;
                                        }
                                    }
                                case "5": //Shows a list of all customers
                                    {
                                        FileManaging.PrintFile("Customers.txt");
                                        break;
                                    }
                                case "6": //Shows a list of all accounts with their balance
                                    {
                                        dummyEmployee.ShowAccountWithBalances(CustomerList);
                                        break;
                                    }
                                case "9": //log out
                                    {
                                        dummyEmployee.LogOut();
                                        break;
                                    }

                            }

                        } while (option2 != "9");
                    }


                }
                else if (option == "2")
                {
                    Customer dummyCustomer = new Customer("Unknown", "Unknown", "Unknown");
                    int indexOfCustomer = dummyCustomer.LogIn(CustomerList);
                    
                    if (indexOfCustomer != -1)
                    {
                        string option2 = "";
                        //Do while with options to execute Employee privileges
                        do
                        {

                            Console.WriteLine("Plase, Enter an option");
                            Console.WriteLine("1. Show transacction History");
                            Console.WriteLine("2. Lodge to an account");
                            Console.WriteLine("3. Withdraw from an account");
                            Console.WriteLine("9. To go back");
                            option2 = Console.ReadLine();
                            switch (option2)
                            {
                                case "1": //show transacction history
                                    {
                                        dummyCustomer.ShowHistory(CustomerList, indexOfCustomer);
                                        break;
                                    }
                                case "2": //Lodge to an account
                                    {
                                        dummyCustomer.Lodge(CustomerList, indexOfCustomer);
                                        break;
                                    }
                                case "3": //Withdraw from an account
                                    {
                                        dummyCustomer.Withdraw(CustomerList, indexOfCustomer);
                                        break;
                                    }
                                case "4": //To go back
                                    {
                                        dummyCustomer.LogOut();
                                        break;
                                    }

                            }

                        } while (option2 != "9");
                    }
                }
            } while (flag);

        }
    }
}
