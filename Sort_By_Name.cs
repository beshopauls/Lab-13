using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab_10
{
    public class Sort_By_Name:IComparer<Person>
    {
        int IComparer<Person>.Compare(Person x, Person y)
        {
            Person person1 = x as Person;
            Person person2 = y as Person;
            if (person1.Name.Length > person2.Name.Length)
                return 1;
            else if (person1.Name.Length < person2.Name.Length)
                return -1;
            else
                return 0;
        }
    }
}