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
            for(int fail=0; fail <100; fail++)
            {
                console.WriteLine(question, args);

                string possibleAnswer = console.ReadLine();
                
                bool isValid = IsValid<T>(possibleAnswer);

                if (isValid) return ConvertFromString<T>(possibleAnswer);

                console.Clear();
            }

            throw (new Exception("Possible infinite loop encountered."));
        }

        private bool IsValid<T>(string value) where T : struct
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));

            return (converter != null && converter.IsValid(value));
        }

        private T ConvertFromString<T>(string value) where T : struct
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));

            return (T)converter.ConvertFromString(value);
        }
    }
}
