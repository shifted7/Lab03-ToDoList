using System;
using System.IO;

namespace ToDoList
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Quarantine To-do list:");
            Console.WriteLine("1. Add item");

            string userInput = Console.ReadLine();
            if (userInput == "1")
            {
                WriteToAFile("../../../List.txt");
            }
            else
            {
                Console.WriteLine("Invalid selection. Please enter the number of one of the above options.");
                Main();
            }
        }
        static void WriteToAFile(string path)
        {

            Console.WriteLine("What do you want to add to this list?");
            string[] input = { Console.ReadLine() };
            // File.WriteAllText(path, ""); 
            File.AppendAllLines(path, input);
        }
    }
}
