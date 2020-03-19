using System;
using System.IO;

namespace ToDoList
{
    public class Program
    {
        static void Main()
        {
            try
            {
                StartSequence();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Thanks for self isolating!");
            }
        }

        public static void StartSequence()
        {
            try
            {
                Console.WriteLine("Quarantine To-do list:");
                Console.WriteLine("1. Add item");
                Console.WriteLine("2. View Items");
                Console.WriteLine("3. Update Items");
                Console.WriteLine("4. Delete Item");
                Console.WriteLine("5. Exit Application");

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
                else if (userInput == "4")
                {
                    Console.WriteLine("Enter the index of the item you want to delete:");
                    int lineToDelete = Convert.ToInt32(Console.ReadLine());
                    DeleteItem("../../../List.txt", lineToDelete);
                }
                else if (userInput == "5")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Invalid selection. Please enter the number of one of the above options.");
                }
                StartSequence();
            }
            catch (FormatException e)
            {
                Console.WriteLine($"So this happened: {e.Message}");
                StartSequence();
            }
            catch (OverflowException e)
            {
                Console.WriteLine($"Why did you do this: {e.Message}");
            }
        }

        /// <summary>
        /// Writes a new to do list item to the file at the end of the file.
        /// </summary>
        /// <param name="path">The path of the file to write to.</param>
        public static void WriteToAFile(string path)
        {
            try
            {
                Console.WriteLine("What do you want to add to this list?");
                string[] input = { Console.ReadLine() };
                if (input == null)
                {
                    throw new Exception("Cannot add empty dreams to your list.");
                }
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

        /// <summary>
        /// Update an item on the to do list.
        /// </summary>
        /// <param name="path">The path of the file to write to.</param>
        public static void UpdateList(string path)
        {
            try
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
                myList[indexParse - 1] = input;
                File.WriteAllLines(path, myList);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                UpdateList(path);
            }
        }

        /// <summary>
        /// Deletes an item from the to do list.
        /// </summary>
        /// <param name="path">The path of the file to write to.</param>
        /// <param name="lineToDelete">Index number of the item to delete.</param>
        public static void DeleteItem(string path, int lineToDelete)
        {
            string[] fileText = File.ReadAllLines(path);

            using (StreamWriter writer = new StreamWriter(path))
            {
                for (int i = 0; i < fileText.Length; i++)
                {

                    if (i != lineToDelete)
                    {
                        writer.WriteLine(fileText[i]);
                    }
                }
            }
        }


    }
}
