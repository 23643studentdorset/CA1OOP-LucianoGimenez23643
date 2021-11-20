using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1_LucianoGimenez_23643.Models
{

    interface Iperson{
        bool LogIn();
        void LogOut();
    }


    //abstract class person to manage withdraws, Lodges and LogOuts
    public abstract class Person : Iperson
    {
        //Method to lodge in one account 
        public void Lodge (List<Customer> CustomerList, Person dummyEmployee, int index)
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
                
                foreach (string newHistoryString in CustomerList[index].accounts[0].toStringList(FileManaging.ReadFile(fileName)))
                {
                    historyList.Add(newHistoryString);
                }

                historyList.Add($"{date}:Lodge:{amountDouble}:{CustomerList[index].accounts[0].balance}");
                
                FileManaging.WriteFile(fileName, historyList);
            }
            else if (typeOfAccount.Equals("2"))
            {
                CustomerList[index].accounts[1].balance += amountDouble;
                output = "Savings";

                string date = DateTime.Now.ToString("dd.MM.yyyy");
                List<string> historyList = new List<string>();
                string fileName = CustomerList[index].accounts[1].accountNumber + "-" + CustomerList[index].accounts[1].type + ".txt";
                foreach (string newHistoryString in CustomerList[index].accounts[1].toStringList(FileManaging.ReadFile(fileName)))
                {
                    historyList.Add(newHistoryString);
                }

                historyList.Add($"{date}:Lodge:{amountDouble}:{CustomerList[index].accounts[1].balance}");
                
                FileManaging.WriteFile(fileName, historyList);
            }
            

            Console.WriteLine($"You Lodge {amount} succesfuly in your {output} account ");
            
        }
        public void Withdraw(double amount, BankAccount account)
        {

        }
        public void LogOut()
        {
            Console.WriteLine("Thank you for using the system");
        }

        public abstract bool LogIn();
        

    }
}
