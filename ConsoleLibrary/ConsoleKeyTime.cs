using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleLibrary
{
    public class ConsoleKeyTime
    {
        TimeSpan timeSpan;

        public ConsoleKeyTime(TimeSpan timeSpan)
        {
            this.timeSpan = timeSpan;
        }

        public TimeSpan TimeSpan => timeSpan;
    }
}
