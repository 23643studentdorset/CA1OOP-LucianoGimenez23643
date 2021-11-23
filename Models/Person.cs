using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1_LucianoGimenez_23643.Models
{

    interface Iperson{
        int LogIn(List<Customer> customerList);
        void LogOut();
    }


    //abstract class person to manage withdraws, Lodges and LogOuts
    public abstract class Person : Iperson
    {
        //Method to lodge to a desired account 
        public void Lodge (List<Customer> CustomerList, int index)
        {
            Console.WriteLine("Would you like to Lodge to:");
            Console.WriteLine("Plase, Enter an option");
            Console.WriteLine("1. Current");
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
                return;
            }
            catch (OverflowException)
            {
                Console.WriteLine("The value is not an amount");
                return;
            }
            

            string output = "";
            if (typeOfAccount.Equals("1"))
            {
                CustomerList[index].accounts[0].balance += amountDouble;
                output = "Current";

                string fileName = CustomerList[index].accounts[0].accountNumber + "-" + CustomerList[index].accounts[0].type + ".txt";
                string date = DateTime.Now.ToString("dd.MM.yyyy");
                List<string> historyList = new List<string>();


                List<string> oldTransacctions = new List<string>(FileManaging.ReadFile(fileName));
                oldTransacctions.RemoveAt(0);

                foreach (string newTransacction in CustomerList[index].accounts[0].toStringList(oldTransacctions))
                {
                    historyList.Add(newTransacction);
                }

                historyList.Add($"{date}   :  Lodge:{amountDouble}  :   New balance:{CustomerList[index].accounts[0].balance}");

                FileManaging.WriteFile(fileName, historyList);
            }
            else if (typeOfAccount.Equals("2"))
            {
                CustomerList[index].accounts[1].balance += amountDouble;
                output = "Savings";

                string fileName = CustomerList[index].accounts[1].accountNumber + "-" + CustomerList[index].accounts[1].type + ".txt";
                string date = DateTime.Now.ToString("dd.MM.yyyy");
                List<string> historyList = new List<string>();
                

                List<string> oldTransacctions = new List<string>(FileManaging.ReadFile(fileName));
                oldTransacctions.RemoveAt(0);

                foreach (string newTransacction in CustomerList[index].accounts[1].toStringList(oldTransacctions))
                {
                    historyList.Add(newTransacction);
                }

                historyList.Add($"{date}    :  Lodge:{amountDouble}  :   New balance:{CustomerList[index].accounts[1].balance}");
                
                FileManaging.WriteFile(fileName, historyList);
            }
            

            Console.WriteLine($"You have Lodged succesfuly {amount} in {output} account ");
            
        }
        
        
        //Method to withdraw from a desired account
        public void Withdraw(List<Customer> CustomerList, int index)
        {
            Console.WriteLine("Would you like to Withdraw from:");
            Console.WriteLine("Plase, Enter an option");
            Console.WriteLine("1. Current");
            Console.WriteLine("2. Savings");
            string typeOfAccount = Console.ReadLine();

            Console.WriteLine("How much would you Withdraw?");
            string amount = Console.ReadLine();
            double amountDouble = 0;
            try
            {
                amountDouble = Convert.ToDouble(amount);
            }
            catch (FormatException)
            {
                Console.WriteLine("The value is not an amount");
                return;
            }
            catch (OverflowException)
            {
                Console.WriteLine("The value is not an amount");
                return;
            }


            string output = "";
            if (typeOfAccount.Equals("1"))
            {
                if (CustomerList[index].accounts[0].balance >= amountDouble)
                {
                    CustomerList[index].accounts[0].balance -= amountDouble;
                    output = "Current";

                    string fileName = CustomerList[index].accounts[0].accountNumber + "-" + CustomerList[index].accounts[0].type + ".txt";
                    string date = DateTime.Now.ToString("dd.MM.yyyy");
                    List<string> historyList = new List<string>();


                    List<string> oldTransacctions = new List<string>(FileManaging.ReadFile(fileName));
                    oldTransacctions.RemoveAt(0);

                    foreach (string newTransacction in CustomerList[index].accounts[0].toStringList(oldTransacctions))
                    {
                        historyList.Add(newTransacction);
                    }

                    historyList.Add($"{date}   :  withdraw:{amountDouble}  :   New balance:{CustomerList[index].accounts[0].balance}");

                    FileManaging.WriteFile(fileName, historyList);
                    Console.WriteLine($"You withdrawed succesfuly{amount} from {output} account");
                }
                else
                {
                    Console.WriteLine("The account does not have enought founds to withdraw that amount");
                    return;
                }
                
            }
            else if (typeOfAccount.Equals("2"))
            {
                if (CustomerList[index].accounts[0].balance >= amountDouble)
                {
                    CustomerList[index].accounts[1].balance -= amountDouble;
                    output = "Savings";

                    string fileName = CustomerList[index].accounts[1].accountNumber + "-" + CustomerList[index].accounts[1].type + ".txt";
                    string date = DateTime.Now.ToString("dd.MM.yyyy");
                    List<string> historyList = new List<string>();


                    List<string> oldTransacctions = new List<string>(FileManaging.ReadFile(fileName));
                    oldTransacctions.RemoveAt(0);

                    foreach (string newTransacction in CustomerList[index].accounts[1].toStringList(oldTransacctions))
                    {
                        historyList.Add(newTransacction);
                    }

                    historyList.Add($"{date}   :  withdraw:{amountDouble}  :   New balance:{CustomerList[index].accounts[1].balance}");

                    FileManaging.WriteFile(fileName, historyList);
                    Console.WriteLine($"You withdraw {amount} succesfuly from {output} account");
                }
                else
                {
                    Console.WriteLine("The account does not have enought founds to withdraw that amount");
                    return;
                }
            }


           

        }
        public void LogOut()
        {
            Console.WriteLine("Thank you for using the system");
        }

        public abstract int LogIn(List<Customer> customerList);
        

    }
}
