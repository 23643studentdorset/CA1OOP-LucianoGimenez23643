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

        //Read and show a File
        public static void ReadFile(string fileName)
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
       
    }
}
