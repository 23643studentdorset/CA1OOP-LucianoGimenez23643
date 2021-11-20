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


    //abstract class to manage withdraws, Lodges and LogOuts
    public abstract class Person : Iperson
    {
        public void Lodge (double amount, BankAccount account)
        {
            account.balance +=  amount;
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
