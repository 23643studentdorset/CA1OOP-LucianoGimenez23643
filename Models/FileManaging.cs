using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA1_LucianoGimenez_23643.Models
{
    public class FileManaging
    {
        

        //Write a file
        public static void WriteFile(string filename, List<string> fileInfo)
        {
            string path = "C:/Users/lucia/Downloads/CA_1_Files";

            string fileToWrite = $"{path}/{filename}";



            try
            {
                using (StreamWriter sw = new StreamWriter(fileToWrite))
                {
                    foreach (string line in fileInfo)
                    {
                        sw.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"The {fileToWrite} could not be written");
                Console.WriteLine(e.Message);
            }

        }

        //Read a File and retrive a string list with all the lines
        public static List<string> ReadFile(string fileName)
        {
            string path = "C:/Users/lucia/Downloads/CA_1_Files";
            string fileToRead = $"{path}/{fileName}";

            List<string> fileInStrings = new List<string>();

            try
            {
                using (StreamReader sr = new StreamReader(fileToRead))
                {
                    string line;

                    while ((line = sr.ReadLine()) is not null)
                    {
                        fileInStrings.Add(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"The {fileToRead} could not be read");
                Console.WriteLine(e.Message);
            }
            return fileInStrings;
        }
        public static void PrintFile(string fileName)
        {
            string path = "C:/Users/lucia/Downloads/CA_1_Files";
            string fileToRead = $"{path}/{fileName}";

            try
            {
                using (StreamReader sr = new StreamReader(fileToRead))
                {
                    string line;

                    while ((line = sr.ReadLine()) is not null)
                    {
                        string[] splitData = line.Split(":");
                        string info = String.Format("{0,-20}", splitData[0]);
                        Console.WriteLine($"{info}\t{splitData[1]}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"The {fileToRead} could not be read");
                Console.WriteLine(e.Message);
            }
        }

        //Returns a string list with the info required of each customer in every element of the list
        public static List<String> ListCustomersToString(List<Customer> ListOfCustomers)
        {
            List<string> CustomersFileList = new List<string>();

            foreach (Customer aCustomer in ListOfCustomers)
            {
                CustomersFileList.Add(aCustomer.customerInfo());
            }
            return CustomersFileList;
        }
        
        //Delete a file
        public static void DeleteFile(string fileName)
        {
            string path = "C:/Users/lucia/Downloads/CA_1_Files";
            File.Delete(path + "/" + fileName);

        }
    }
}
