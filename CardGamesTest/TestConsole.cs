using ConsoleLibrary;
using System.Collections.Generic;

namespace CardGames
{
    public class TestConsoleClear { }
    
    public class TestConsole : IConsole
    {
        public List<object> Output = new List<object>();
        public List<object> Input = new List<object>();

        public void Clear()
        {
            Output.Add(new TestConsoleClear());
        }

        public string ReadLine()
        {
            string line = (string)Input[0];
            Input.RemoveAt(0);
            return line;
        }

        public void WriteLine(string question, object[] args)
        {
            Output.Add(string.Format(question, args));
        }
    }
}