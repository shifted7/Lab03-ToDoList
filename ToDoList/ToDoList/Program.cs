using System;
using System.IO;

namespace ToDoList
{
    public class Program
    {
        public static string logPath = "../../../Log.txt";
        public static string path = "../../../List.txt";
        static void Main()
        {
            try
            {
                StartSequence();
            }
            catch (Exception e)
            {
                string[] errors = { $"{DateTime.Now}: {e.Message}" };
                File.AppendAllLines(logPath, errors);
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
                Console.WriteLine("");
                if (userInput == "1")
                {
                    Console.WriteLine("What do you want to add to this list?");
                    string[] input = { Console.ReadLine() };
                    WriteToAFile("../../../List.txt", input);
                }
                else if (userInput == "2")
                {
                    ReadAllLines("../../../List.txt");
                }
                else if (userInput == "3")
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

                    UpdateList(path, indexParse, input, myList);
                }
                else if (userInput == "4")
                {
                    ReadAllLines(path);
                    Console.WriteLine("Enter the index of the item you want to delete:");
                    int lineToDelete = Convert.ToInt32(Console.ReadLine());
                    DeleteItem("../../../List.txt", lineToDelete-1);
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
                string[] errors = { $"{DateTime.Now}: {e.Message}" };
                File.AppendAllLines(logPath, errors);
                Console.WriteLine($"So this happened: {e.Message}");
                StartSequence();
            }
            catch (OverflowException e)
            {
                string[] errors = { $"{DateTime.Now}: {e.Message}" };
                File.AppendAllLines(logPath, errors);
                Console.WriteLine($"Why did you do this: {e.Message}");
            }
        }

        /// <summary>
        /// Writes a new to do list item to the file at the end of the file.
        /// </summary>
        /// <param name="path">The path of the file to write to.</param>
        public static void WriteToAFile(string path, string[] input)
        {
            try
            {
                if (input == null)
                {
                    throw new Exception("Cannot add empty dreams to your list.");
                }
                File.AppendAllLines(path, input);
            }
            catch (FileNotFoundException e)
            {
                string[] errors = { $"{DateTime.Now}: {e.Message}" };
                File.AppendAllLines(logPath, errors);
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
            Console.WriteLine("");
        }

        /// <summary>
        /// Update an item on the to do list.
        /// </summary>
        /// <param name="path">The path of the file to write to.</param>
        public static void UpdateList(string path, int indexParse, string input, string[] myList)
        {
            try
            {
                // cut here
                myList[indexParse - 1] = input;
                File.WriteAllLines(path, myList);
            }
            catch (IndexOutOfRangeException e)
            {
                string[] errors = { $"{DateTime.Now}: {e.Message}" };
                File.AppendAllLines(logPath, errors);
                Console.WriteLine(e.Message);
                UpdateList(path, indexParse, input, myList);
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
