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
            
            //Create empty Customer.txt
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
                    if (dummyEmployee.LogIn())
                    {
                        string option2 = "";
                        //Do while with options to execute Employee privileges
                        do
                        {
                            
                            Console.WriteLine("Plase, Enter an option");
                            
                            Console.WriteLine("1. Create a new customer");
                            Console.WriteLine("2. Delete a customer");
                            Console.WriteLine("3. Lodge from an account");
                            Console.WriteLine("4. Withdraw from an account");
                            Console.WriteLine("5. Show list of all customers");
                            Console.WriteLine("6. Show customers with balance");
                            Console.WriteLine("0. To go back");
                            option2 = Console.ReadLine();
                            switch (option2)
                            {
                                case "1": //Create a customer
                                    {
                                        Customer dummyCustomer = dummyEmployee.CreateCustomer();
                                        
                                        BankAccount accountCurrent = new BankAccount(dummyCustomer.firstName, dummyCustomer.lastName, "current", 0);
                                        BankAccount accountSavings = new BankAccount(dummyCustomer.firstName, dummyCustomer.lastName, "savings", 0);

                                        FileManaging.WriteFile(accountCurrent.accountNumber + "- " + accountCurrent.type + ".txt", accountCurrent.toStringList());
                                        FileManaging.WriteFile(accountSavings.accountNumber + "- " + accountSavings.type + ".txt", accountSavings.toStringList());

                                        dummyCustomer.attachBankAccountToCustomer(accountCurrent);
                                        dummyCustomer.attachBankAccountToCustomer(accountSavings);
                                        dummyCustomer.setPin();

                                        CustomerList.Add(dummyCustomer);
                                        CustomersFileList = FileManaging.ListCustomersToString(CustomerList);
                                        
                                        FileManaging.WriteFile("Customers.txt", CustomersFileList);
                                        break;
                                    }
                                case "2": //Delete a customer
                                    {
                                        CustomerList = dummyEmployee.DeleteCustomer(CustomerList);
                                        CustomersFileList = FileManaging.ListCustomersToString(CustomerList);
                                        FileManaging.WriteFile("Customers.txt", CustomersFileList);
                                        break;
                                    }
                                case "3": //Lodge
                                    {
                                        int counter = 0;
                                        bool outputFlag = true;
                                        int index = 0;
                                        
                                        Console.WriteLine("Please enter the acount number or 9 to go back");
                                        string accountNumber = Console.ReadLine();
                                        
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
                                        }
                                        
                                        Console.WriteLine("Would you like to Lodge to:");
                                        Console.WriteLine("Plase, Enter an option");
                                        Console.WriteLine("1. Current" );
                                        Console.WriteLine("2. Savings");
                                        string typeOfAccount = Console.ReadLine();
                                        
                                        Console.WriteLine("How much would you Lodge?");
                                        string amount = Console.ReadLine();
                                        double amountDouble = 0;
                                        try
                                        {
                                            amountDouble = Convert.ToDouble(amount);
                                        }
                                        catch (FormatException)
                                        {
                                            Console.WriteLine("The value is not an amount");
                                            break;
                                        }
                                        catch (OverflowException)
                                        {
                                            Console.WriteLine("The value is not an amount");
                                            break;
                                        }

                                        if (typeOfAccount.Equals("1"))
                                        {
                                            dummyEmployee.Lodge(amountDouble, CustomerList[index].accounts[0]);
                                        }else if (typeOfAccount.Equals("2"))
                                        {
                                            dummyEmployee.Lodge(amountDouble, CustomerList[index].accounts[2]);
                                        }

                                            
                                        break;
                                    }
                                case "4":
                                    {
                                        break;
                                    }
                                case "5":
                                    {
                                        break;
                                    }
                                case "6":
                                    {
                                        break;
                                    }
                                case "0":
                                    {
                                        dummyEmployee.LogOut();
                                        break;
                                    }

                            }

                        } while (option2 != "0");
                    }
                        
                    
                }else if (option == "2")
                {
                    //do while
                    //Customer.LogIn();
                    
                }else
                {
                    Console.WriteLine("The option entered is not a valid valid option");

                }
            } while (flag);

        }
    }
}
