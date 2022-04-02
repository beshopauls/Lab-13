using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Lab_10;
using lab12;

namespace Lab_13
{
    public class CollectionHandlerEventArgs<T>:EventArgs
    {
        
        public string Name { get; set; }
        public string EventName { get; set; }
        public T[] EventParticipants { get; set; }
        public CollectionHandlerEventArgs(string name, string eventName, T[] obj)
        {
            Name = name;
            EventName = eventName;
            EventParticipants = obj;
        }

       
    }
}