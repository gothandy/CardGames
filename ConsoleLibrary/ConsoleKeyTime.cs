using System;

namespace ConsoleLibrary
{
    public class ConsoleKeyTime
    {
        ConsoleKey consoleKey;
        TimeSpan timeSpan;

        public ConsoleKeyTime(ConsoleKey consoleKey, TimeSpan timeSpan)
        {
            this.consoleKey = consoleKey;
            this.timeSpan = timeSpan;
        }

        public ConsoleKey ConsoleKey => consoleKey;
        public TimeSpan TimeSpan => timeSpan;
    }
}
