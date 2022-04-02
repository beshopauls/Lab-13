using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab_10;
using lab12;
using System.Collections;

namespace Lab_13
{
    public class Journal<T>
    {
        public string CollectionName { get; set; }
        public string EventName { get; set; }
        public T[] EventParticipants { get; set; }
        public Journal(string name, string evName,T[] obj)
        {
            CollectionName = name;
            EventName = evName;
            EventParticipants = obj;
        }
        public void Print()
        {
            for (int i = 0; i < EventParticipants.Length; i++)
            {
               
                Console.WriteLine(EventParticipants[i].ToString());
            }
            
        }
    }
}