using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
namespace Lab_13
{
    public class JournalResult<T>
    {
        public List<Journal<T>> Journal;

        public JournalResult()
        {
            Journal = new List<Journal<T>>();
        }

        public void Add(object source, CollectionHandlerEventArgs<T> args)
        {
            Journal<T> journalElem = new Journal<T>(args.Name, args.EventName, args.EventParticipants);
            Journal.Add(journalElem);
        }

        public void Print()
        {
            foreach (var elem in Journal)
            {
                Console.WriteLine(" Collection Name :  {0}  , Event Name :  {1}  , Event Participants : ", elem.CollectionName, elem.EventName);
                elem.Print();
               
            }
        }
    }
}