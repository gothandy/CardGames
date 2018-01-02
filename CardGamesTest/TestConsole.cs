using ConsoleLibrary;
using System.Collections.Generic;

namespace CardGamesTest
{
    public class TestConsole : IConsole
    {
        private string line;

        public List<string> Output = new List<string>();

        public TestConsole(string line)
        {
            this.line = line;
        }

        public void Clear()
        {
            // Need to test somehow.
        }

        public string ReadLine()
        {
            return line;
        }

        public void WriteLine(string question, object[] args)
        {
            Output.Add(string.Format(question, args));
        }
    }
}