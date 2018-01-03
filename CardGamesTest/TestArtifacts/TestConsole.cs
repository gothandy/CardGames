using ConsoleLibrary;
using System;
using System.Collections.Generic;

namespace CardGames
{
    public class TestConsoleClear { }
    
    public class TestConsole : IConsole
    {
        public List<object> Output = new List<object>();
        public List<object> Input = new List<object>();

        public TestConsole()
        {
            Output.Add(String.Empty);
        }

        public void Clear()
        {
            Output.Add(new TestConsoleClear());
            Output.Add(String.Empty);
        }

        public ConsoleKeyInfo ReadKey(bool intercept)
        {
            ConsoleKeyInfo keyInfo = (ConsoleKeyInfo)Input[0];

            if (!intercept) Write(keyInfo.KeyChar.ToString());

            return keyInfo;
        }

        public string ReadLine()
        {
            string line = (string)Input[0];
            Input.RemoveAt(0);
            return line;
        }

        public void Write(string value)
        {
            if (Output.Count == 0) Output.Add(String.Empty);

            Output[Output.Count - 1] = String.Concat(Output[Output.Count - 1], value);
        }

        public void Write(string format, object[] args)
        {
            this.Write(String.Format(format, args));
        }

        public void WriteLine(string value)
        {
            this.Write(value);
            this.Output.Add(String.Empty);
        }

        public void WriteLine(string format, object[] args)
        {
            this.WriteLine(string.Format(format, args));
        }
    }
}