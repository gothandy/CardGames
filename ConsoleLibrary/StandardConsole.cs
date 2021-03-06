﻿using System;

namespace ConsoleLibrary
{
    public class StandardConsole : IConsole
    {
        public void Clear()
        {
            Console.Clear();
        }

        public ConsoleKeyInfo ReadKey(bool intercept)
        {
            return Console.ReadKey(intercept);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void Write(string value)
        {
            Console.Write(value);
        }

        public void Write(string format, object[] args)
        {
            Console.Write(format, args);
        }

        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }

        public void WriteLine(string format, object[] args)
        {
            Console.WriteLine(format, args);
        }
    }
}