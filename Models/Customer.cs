using System;
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
        public string accountNumber { get; set; }
        public string pin { get; set; }

        public List<BankAccount> accounts = new List<BankAccount>();

        public Customer(string _firstName, string _lastName, string _eMail)
        {
            firstName = _firstName;
            lastName = _lastName;
            eMail = _eMail; 
        }
        
        //Mehod that takes a bank account instance to attach it to a customer
        public void attachBankAccountToCustomer(BankAccount account)
        {
            accounts.Add(account);
            accountNumber = account.NameOfAccount();
        }
        
        //Method to set the pin of a customer to login 
        public void setPin()
        {
            char[] accountNumbertoCharArray = accountNumber.ToCharArray();
            
            string newPin = accountNumbertoCharArray[6].ToString() + accountNumbertoCharArray[7].ToString() 
                          + accountNumbertoCharArray[9].ToString() + accountNumbertoCharArray[10].ToString();
            pin = newPin;
        }


        //Login to a customer account returns index of a customer if the customer exist and -1 if the customers does not exist
        public override int LogIn(List<Customer> CustomerList)
        {
            Console.WriteLine("Hello");
            Console.WriteLine("Please enter your first name:");
            string fName = Console.ReadLine();
            Console.WriteLine("Please enter your last name:");
            string lName = Console.ReadLine();
            Console.WriteLine("Please enter your account number");
            string accountNumberToLogIn = Console.ReadLine();
            Console.WriteLine("Please enter your pin");
            string pinToLogIn = Console.ReadLine();

            int counter = 0;
            foreach (Customer aCustomer in CustomerList)
            {
                if (fName.Equals(aCustomer.firstName) && lName.Equals(aCustomer.lastName) && accountNumberToLogIn.Equals(aCustomer.accountNumber) && pinToLogIn.Equals(aCustomer.pin))
                {
                    return counter;
                }
                counter++;
            }
            Console.WriteLine("The customer is not in our Data Base");
            return -1;

            
        }

        //Display all the transactions of the desired customer
        public void ShowHistory(List <Customer> CustomerList, int indexOfCustomer)
        {
            Console.WriteLine("Would you like to see the transacction history from:");
            Console.WriteLine("Plase, Enter an option");
            Console.WriteLine("1. Current");
            Console.WriteLine("2. Savings");
            string typeOfAccount = Console.ReadLine();

            string fileName = "";
            if (typeOfAccount.Equals("1"))
            {
                fileName = CustomerList[indexOfCustomer].accounts[0].NameOfAccount() + "-Current.txt";
            }
            else if (typeOfAccount.Equals("2"))
            {
                fileName = CustomerList[indexOfCustomer].accounts[0].NameOfAccount() + "-Savings.txt";
            }
            else
            {
                Console.WriteLine("The option you enter is not available");
                return;
            }
            
            FileManaging.PrintFile(fileName);
        }

        //Method that retrieve a string with all customer public data
        public string customerInfo()
        {
            string customerInfoString = accountNumber + ":" + firstName + ":" + lastName + ":" + eMail;
            return customerInfoString;
        }

    }
}
