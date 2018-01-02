using System;
using System.ComponentModel;

namespace ConsoleLibrary
{
    public class ConsoleHelper
    {
        private IConsole console;

        public ConsoleHelper(IConsole console)
        {
            this.console = console;
        }
        
        public T AskQuestion<T>(string question, params object[] args) where T : struct
        {
            while (true)
            {
                console.WriteLine(question, args);

                string possibleAnswer = console.ReadLine();

                TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));

                if (converter != null && converter.IsValid(possibleAnswer))
                {
                    return (T)converter.ConvertFromString(possibleAnswer);
                }

                console.Clear();
            }
        }
    }
}
