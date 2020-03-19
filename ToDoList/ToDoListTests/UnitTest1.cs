using System;
using System.IO;
using Xunit;
using ToDoList;

namespace ToDoListTests
{
    public class ProgramTests
    {
        string path = "List.txt";

        [Fact]
        public void ViewingListDoesntChangeList()
        {
            string test = "Some dummy text.";
            File.WriteAllText(path, test);

            string fileText = File.ReadAllText(path);
            Program.ReadAllLines(path);
            Assert.Equal(fileText, File.ReadAllText(path));
        }

        [Fact]
        public void WritingToFileWritesToFile()
        {
            File.Delete(path);

            string[] test = { "Some writing and stuff and things." };
            Program.WriteToAFile(path, test);

            Assert.Equal(test, File.ReadAllLines(path));
        }
    }
}
