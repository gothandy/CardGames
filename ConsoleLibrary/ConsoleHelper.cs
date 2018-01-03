﻿using System;
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
        
        public T AskQuestionLine<T>(string question, params object[] args) where T : struct
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

        public ConsoleKey AskQuestionKey(string question, params object[] args)
        {
            console.Write(question, args);
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            console.WriteLine(keyInfo.KeyChar.ToString().ToUpper());
            return keyInfo.Key;

        }

        public void Clear()
        {
            console.Clear();
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
