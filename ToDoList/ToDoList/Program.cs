using System;
using System.IO;

namespace ToDoList
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Quarantine To-do list:");
            Console.WriteLine("1. Add item");
            Console.WriteLine("2. View Items");
            Console.WriteLine("3. Update Items");

            string userInput = Console.ReadLine();
            if (userInput == "1")
            {
                WriteToAFile("../../../List.txt");
            }
            else if (userInput == "2")
            {
                ReadAllLines("../../../List.txt");
            }
            else if (userInput == "3")
            {
                UpdateList("../../../List.txt");
            }
            else
            {
                Console.WriteLine("Invalid selection. Please enter the number of one of the above options.");
                Main();
            }
        }
        public static void WriteToAFile(string path)
        {
            try
            {
                Console.WriteLine("What do you want to add to this list?");
                string[] input = { Console.ReadLine() };
                // File.WriteAllText(path, ""); 
                File.AppendAllLines(path, input);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Your file is not available"); ;
            }
         
        }
        /// <summary>
        /// Reading from the list
        /// </summary>
        /// <param name="path">path of text files</param>
        public static void ReadAllLines(string path)
        {
            string[] myList = File.ReadAllLines(path);
            for (int i = 0; i < myList.Length; i++)
            {
                Console.WriteLine(myList[i]);
            }
        }

        //update the list
        public static void UpdateList(string path)
        {
            string[] myList = File.ReadAllLines(path);

            for (int i = 0; i < myList.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {myList[i]} ");
            }
            Console.WriteLine("What do you want to update?");
            string index = Console.ReadLine();
            int indexParse = Convert.ToInt32(index);
            Console.WriteLine("What do you want to change it to?");
            string input = Console.ReadLine();
            myList[indexParse-1] = input;
            File.WriteAllLines(path, myList);
        }


    }
}
