using System;

namespace ConsoleLibrary
{
    public class ConsoleStandard : IConsole
    {
        public void Clear()
        {
            Console.Clear();
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string question, object[] args)
        {
            Console.WriteLine(question, args);
        }
    }
}