using System;

namespace ConsoleLibrary
{
    public interface IConsole
    {
        void Clear();

        string ReadLine();
        ConsoleKeyInfo ReadKey(bool intercept);

        void Write(string value);
        void Write(string format, object[] args);
        void WriteLine(string value);
        void WriteLine(string format, object[] args);
        
    }
}