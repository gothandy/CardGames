namespace ConsoleLibrary
{
    public interface IConsole
    {
        void WriteLine(string question, object[] args);
        string ReadLine();
        void Clear();
    }
}