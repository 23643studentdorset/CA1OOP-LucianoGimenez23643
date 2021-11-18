﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1_LucianoGimenez_23643.Models
{
    public class Customer : Person
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string eMail { get; set; }

        public List<BankAccount> accounts = new List<BankAccount>();

        public Customer(string _firstName, string _lastName, string _eMail)
        {
            firstName = _firstName;
            lastName = _lastName;
            eMail = _eMail;
            

        }

        public void addBankAccount(BankAccount account)
        {
            accounts.Add(account);
        }

    
        public void LogIn()
        {
            bool flag = true;
            Console.WriteLine("Hello");
            do
            {
                Console.WriteLine("Please enter your first name:");
                string fName = Console.ReadLine();
                Console.WriteLine("Please enter your last name:");
                string lName = Console.ReadLine();
                Console.WriteLine("Please enter your pin");
                string pin = Console.ReadLine();

                
                //correct that (check what C# gives you when the file is not there
                if (pin.Equals(BankAccount.NameOfAccount(fName, lName, "current").ToCharArray()))
                {
                    Console.WriteLine($"Welcome {fName} {lName}");
                }
                else
                {
                    Console.WriteLine("Your data is not correct please try again");
                }

            } while (flag == true);
        }

        public void ShowHistory(BankAccount account)
        {
            FileManaging.ReadFile(account.NameOfAccount() + ".txt");
        }

        public List<string> customerInfo()
        {
            List<string> customerInfoList = new List<string>();
            customerInfoList.Add(firstName);
            customerInfoList.Add(lastName);
            customerInfoList.Add(eMail);
            foreach

            return customerInfoList;
        }

    }
}
