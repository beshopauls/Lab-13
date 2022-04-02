using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab12;
using Lab_10;

namespace Lab_13
{
    public class Program
    {
        static List<Student> students = new List<Student>();
        static List<Student> students2 = new List<Student>();
       public  static void FirstPart(MyNewCollection<Student> listFirst, JournalResult<Student> journalFirst)
        {
           Student student = new Student(101, 0, 22, "Bisho", true, "sw");
            Student student2 = new Student(102, 0, 22, "Makarious", true, "cs");
            Console.WriteLine(" Count and Reference events on the first collection ");     
            students.Add(student); 
            students.Add(student);
            students.Add(student);
            students.Add(student);
            students.Add(student);

            listFirst.Add_element(student);
            listFirst.Add_element(new Student(101, 0, 22, "Bisho", true, "sw"));
            listFirst.Add_Range(students);

            if (listFirst.index != 0)
                foreach (Student std in listFirst)
                    Console.WriteLine(std.Id + " " + std.Name + " " + std.Age + " " + std.GenderMale + " " + std.Section);

            Console.WriteLine(" Journal : ");
            journalFirst.Print();
           
            Console.WriteLine(" Element removed : ");
            listFirst.Delete_element(student);
            students2.Add(student);
            students2.Add(student);
            students2.Add(student);
            listFirst.DeleteRange(0, 3, students2);
            if (listFirst.index != 0)
                foreach (Student std in listFirst)
                    Console.WriteLine(std.Id + " " + std.Name + " " + std.Age + " " + std.GenderMale + " " + std.Section);
            Console.WriteLine("Journal:");
            journalFirst.Print();
            
            Console.WriteLine(" Changed link : ");
            listFirst.Change(student2);

            if (listFirst.index != 0)
                foreach (Student std in listFirst)
                    Console.WriteLine(std.Id + " " + std.Name + " " + std.Age + " " + std.GenderMale + " " + std.Section);

            Console.WriteLine("Journal:");
            journalFirst.Print();
         

        }

       public static void SecondPart(MyNewCollection<Student> listFirst, MyNewCollection<Student> listSecond, JournalResult<Student> journalSecond)
        {
            students.Clear();
             Student student = new Student(101, 0, 22, "Bisho", true, "sw");
             Student student2 = new Student(102, 0, 22, "Makarious", true, "cs");
            Console.WriteLine(" Reference events from both collections ");
            listSecond.Add_element(student);
            listSecond.Add_element(student);
       
            students.Add(student);
            students.Add(student);
            students.Add(student);

            listSecond.Add_Range(students);
            journalSecond.Print();
            Console.WriteLine("list First : ");
            if (listFirst.index != 0)
                foreach (Student std in listFirst.list)
                    Console.WriteLine(std.Id + " " + std.Name + " " + std.Age + " " + std.GenderMale + " " + std.Section);

            Console.WriteLine("list secound : ");
            if (listSecond.index != 0)
                foreach (Student std in listSecond.list)
                    Console.WriteLine(std.Id + " " + std.Name + " " + std.Age + " " + std.GenderMale + " " + std.Section);

            Console.WriteLine(" Change references for both collections :  ");
            listFirst.Change(student);
            listSecond.Change(student2);
            Console.WriteLine("Journal");
            journalSecond.Print();
            Console.WriteLine("list First : ");
            if (listFirst.index != 0)
                foreach (Student std in listFirst.list)
                    Console.WriteLine(std.Id + " " + std.Name + " " + std.Age + " " + std.GenderMale + " " + std.Section);

            Console.WriteLine("list Second : ");
            if (listSecond.index != 0)
                foreach (Student std in listSecond.list)
                    Console.WriteLine(std.Id + " " + std.Name + " " + std.Age + " " + std.GenderMale + " " + std.Section);

           
        }

        static void Main(string[] args)
        {
            MyNewCollection<Student> listFirst = new MyNewCollection<Student>("First");
            MyNewCollection<Student> listSecond = new MyNewCollection<Student>("Second");

            JournalResult<Student> journalFirst = new JournalResult<Student>();
            JournalResult<Student> journalSecond = new JournalResult<Student>();
             

            listFirst.OnCollectionCountChanged += journalFirst.Add;
            listSecond.OnCollectionCountChanged += journalSecond.Add;

            listFirst.OnCollectionReferenceChanged += journalFirst.Add;
            listSecond.OnCollectionReferenceChanged += journalSecond.Add;

            listFirst.OnCollectionReferenceChanged += journalSecond.Add;
           
          

            FirstPart(listFirst, journalFirst);
            Console.WriteLine("--------------------------------------");
            SecondPart(listFirst, listSecond, journalSecond);

            Console.ReadKey();

        }
    }
}
 