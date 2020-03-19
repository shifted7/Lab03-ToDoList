using System;
using System.IO;
using Xunit;
using ToDoList;

namespace ToDoListTests
{
    public class ProgramTests
    {
        string path = "List.txt";

        /// <summary>
        /// This is a method for viewing all of the lists.
        /// </summary>
        [Fact]
        public void ViewingListDoesntChangeList()
        {
            string test = "Some dummy text.";
            File.WriteAllText(path, test);

            string fileText = File.ReadAllText(path);
            Program.ReadAllLines(path);
            Assert.Equal(fileText, File.ReadAllText(path));
        }
        /// <summary>
        /// This is for test for writing a file method 
        /// </summary>
        [Fact]
        public void WritingToFileWritesToFile()
        {
            File.Delete(path);

            string[] test = { "Some writing and stuff and things." };
            Program.WriteToAFile(path, test);

            Assert.Equal(test, File.ReadAllLines(path));
        }

        /// <summary>
        /// This to test update method
        /// </summary>
        [Fact]
        public void UpdateToFiles()
        {

            File.Delete(path);

            string[] test = { "Some dummy text.",
                               "Some dumb text" };

            File.WriteAllLines(path, test);

            string[] myList = File.ReadAllLines(path);

            string updatedText = "Banana";

            Program.UpdateList(path, 2, updatedText, myList);

            Assert.Equal("Banana", myList[1]);

        }
        /// <summary>
        /// Check if the length of original array is minus one after using delete method
        /// </summary>
        [Fact]
        public void DeleteLine()
        {
            File.Delete(path);

            string[] test = { "1banana", "2apple", "3melon", "4celery" };
            File.WriteAllLines(path, test);
            int length1 = test.Length;

            string[] arrayList = File.ReadAllLines(path);

            int delIndex = 3;
            Program.DeleteItem(path, delIndex);
            
            string[] newArray = File.ReadAllLines(path);

            Assert.Equal(length1 - 1, newArray.Length);
        }
    }
}
