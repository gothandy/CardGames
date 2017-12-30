using System;
using System.Collections;
using System.Collections.Generic;

namespace PlayingCardLibrary
{
    public class Pack
    {
        public int Count { get; set; }

        public Card this[int index]
        {
            get
            {
                throw (new NotImplementedException());
            }
        }
    }
}