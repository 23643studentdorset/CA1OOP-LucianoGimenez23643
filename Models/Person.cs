using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1_LucianoGimenez_23643.Models
{ 
    
    public abstract class Person
    {
        public void Lodge (double amount, string account)
        {
           
        }
        public void Withdraw(double amount, string account)
        {

        }

        public void LogOut()
        {
            Console.WriteLine("Thank you for using  system");
        }

    }
}
