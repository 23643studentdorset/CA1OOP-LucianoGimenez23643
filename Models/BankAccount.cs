using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1_LucianoGimenez_23643.Models
{
    public class BankAccount
    {
        public string ownerFirstName { get; set; }
        public string ownerLastName { get; set; }
        public string type { get; set; }
        public double balance { get; set; }
        public string accountNumber { get; set; }
        
        public List<string> TransacctionHistory = new List<string>();

        public BankAccount(string _ownerFirstName, string _ownerLastName, string _type, int _balance)
        {
            ownerFirstName = _ownerFirstName;
            ownerLastName = _ownerLastName;
            type = _type;
            balance = _balance;
            accountNumber = NameOfAccount();

        }


        //Generates and return the account name 
        public string NameOfAccount()
        {

            string Cname = ownerFirstName + ownerLastName;

            char[] X1 = ownerFirstName.ToCharArray();
            char[] X2 = ownerLastName.ToCharArray();
            char X1Capitalized = char.ToUpper(X1[0]);
            char X2Capitalized = char.ToUpper(X2[0]);

            string XX = X1Capitalized.ToString() + X2Capitalized.ToString();

            string NN = (Cname.Length).ToString();

            var yyzzDictionary = new Dictionary<string, string>(){
                {"A", "01"}, {"B", "02"}, {"C", "03"}, {"D", "04"}, {"E", "05"}, {"F", "06"}, {"G", "07"}, {"H", "08"}, {"I", "09"}, {"J", "10"}, {"K", "11"}, {"L", "12"}, {"M", "13"},
                {"N", "14"}, {"O", "15"}, {"P", "16"}, {"Q", "17"}, {"R", "18"}, {"S", "19"}, {"T", "20"}, {"U", "21"}, {"V", "22"}, {"W", "23"}, {"X", "24"}, {"Y", "25"}, {"Z", "26"}};

            string YY = yyzzDictionary[X1Capitalized.ToString()];

            string ZZ = yyzzDictionary[X2Capitalized.ToString()];
            string accountName = XX + "-" + NN + "-" + YY + "-" + ZZ;

            return accountName;
        }

        //Method that returns a list that has current balance as first element and transaction history in the others positions 
        public List<string> toStringList(List<string> TransacctionHistory)
        {
            List<string> stringsToWriteAccounts = new List<string>();
            stringsToWriteAccounts.Add("Balance: " + balance.ToString());
            
            foreach (string transacction in TransacctionHistory)
            {
                stringsToWriteAccounts.Add(transacction);
                
            }
            return stringsToWriteAccounts;
        }

    }
}
