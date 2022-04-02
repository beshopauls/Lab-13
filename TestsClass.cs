using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Lab_13;
using Lab_10;
using lab12;
namespace Tests
{
    [TestClass]
    public class TestsClass
    {
        MyEnumerator<int> myEnumerator1;
        MyEnumerator<int> myEnumerator2;
        List<int> list;
        MyCollection<int> collection1;
        MyCollection<int> collection2;

        [TestMethod]
        public void Test_constructor_MyEnumerator_without_parameters()
        {
            myEnumerator1 = new MyEnumerator<int>();
            myEnumerator2 = new MyEnumerator<int>();
            CollectionAssert.AreEqual(myEnumerator1.list, myEnumerator2.list);
            Assert.AreEqual(myEnumerator1.index, myEnumerator2.index);
        }
        [TestMethod]
        public void Test_constructor_MyEnumerator_with_parameters_int()
        {
            int c = 3;
            myEnumerator1 = new MyEnumerator<int>(c);
            myEnumerator2 = new MyEnumerator<int>(c);
            CollectionAssert.AreEqual(myEnumerator1.list, myEnumerator2.list);
            Assert.AreEqual(myEnumerator1.list.Capacity, myEnumerator2.list.Capacity);
            Assert.AreEqual(myEnumerator1.index, myEnumerator2.index);
        }
        [TestMethod]
        public void Test_constructor_MyEnumerator_with_parameters_collection()
        {
            list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            myEnumerator1 = new MyEnumerator<int>(list);
            myEnumerator2 = new MyEnumerator<int>(list);
            CollectionAssert.AreEqual(myEnumerator1.list, myEnumerator2.list);
            Assert.AreEqual(myEnumerator1.index, myEnumerator2.index);
        }
        [TestMethod]
        public void Test_MoveNetx()
        {
            myEnumerator1 = new MyEnumerator<int>(2);
            myEnumerator2 = new MyEnumerator<int>(2);
            bool x = myEnumerator1.MoveNext();
            bool y = myEnumerator2.MoveNext();
            Assert.IsFalse(x);
            Assert.IsFalse(y);


        }
        [TestMethod]
        public void Test_Reset()
        {
            myEnumerator1 = new MyEnumerator<int>(2);
            myEnumerator2 = new MyEnumerator<int>(2);
            myEnumerator1.Reset();
            myEnumerator2.Reset();
            Assert.IsTrue(AssertObjectAreEqual(myEnumerator1.index, myEnumerator2.index));
            CollectionAssert.AreEqual(myEnumerator1.list, myEnumerator2.list);

        }
        [TestMethod]
        public void Test_empty_Constructor_mycollection()
        {
            collection1 = new MyCollection<int>();
        }
        [TestMethod]
        public void Test_Constructor_mycollection_with_capacity()
        {
            collection1 = new MyCollection<int>(3);
        }
        [TestMethod]
        public void Test_Constructor_mycollection_with_collection()
        {
            list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            collection1 = new MyCollection<int>(list);
        }
        [TestMethod]
        public void Test_collection_AddElement()
        {


            collection1 = new MyCollection<int>() { index = 0, list = new List<int>() };
            collection2 = new MyCollection<int>() { index = 0, list = new List<int>() };
            collection1.Add_element(1);
            collection1.Add_element(2);
            collection1.Add_element(3);
            collection2.Add_element(1);
            collection2.Add_element(2);
            collection2.Add_element(3);
            CollectionAssert.AreEqual(collection1.list, collection2.list);
        }
        [TestMethod]
        public void Test_AddRange()
        {
            list = new List<int>() { 1, 2, 3 };
            int c = 3;
            collection1 = new MyCollection<int>(c);
            collection2 = new MyCollection<int>(c);
            collection1.Add_Range(list);
            CollectionAssert.AreNotEqual(collection1.list, collection2.list);
        }
        [TestMethod]
        public void Test_DeleteElement()
        {
            collection1 = new MyCollection<int> { index = 3, list = new List<int>() { 1, 2, 3, 4 } };
            collection2 = new MyCollection<int> { index = 3, list = new List<int>() { 1, 2, 3, 4 } };
            collection1.Delete_element(1);
            CollectionAssert.AreNotEqual(collection1.list, collection2.list);
        }
        [TestMethod]
        public void Test_DeleteRange()
        {
            list = new List<int>() { 1, 2, 3 };

            int c = 3;
            collection1 = new MyCollection<int>(c);
            collection2 = new MyCollection<int>(c);
            collection1.Add_Range(list);
            collection2.Add_Range(list);
            collection1.Delete_Range(0, 3);
            CollectionAssert.AreNotEqual(collection1.list, collection2.list);
            collection1.GetEnumerator(list);

        }

        [TestMethod]
        public void Test_Search()
        {
            collection1 = new MyCollection<int> { index = 3, list = new List<int>() { 1, 2, 3, 4 } };
            bool c = collection1.Search(1);
            Assert.IsTrue(c);
        }
        [TestMethod]
        public void Test_Copy()
        {
            collection1 = new MyCollection<int> { index = 3, list = new List<int>() { 1, 2, 3, 4 } };
            int[] arr = new int[collection1.list.Count];

            collection1.Copy(arr);
            CollectionAssert.AreEqual(collection1.list, arr);
            collection1.GetEnumerator();
        }
        [TestMethod]
        public void Test_Constructor_Person_withoutParameters()
        {
            Person person = new Person();
            Assert.AreEqual(0, person.Age);
            Assert.IsNull(person.Name);
            Assert.AreEqual(true, person.GenderMale);
        }
        [TestMethod]
        public void Test_Constructor_Person_withParameters()
        {
            Person person1 = new Person(26, "Bisho", true);
            Person person2 = new Person(26, "Bisho", true);
            Assert.IsTrue(AssertObjectAreEqual(person1, person2));
        }
        [TestMethod]
        public void Test_clone()
        {
            Person person1 = new Person(26, "Bisho", false);
            Person person2 = (Person)person1.Clone();
            Assert.AreEqual("Bisho", person2.Name);
        }
        [TestMethod]
        public void Test_counting_gender()
        {
            Student[] student = new Student[10];
            student[0] = new Student(101, 0, 26, "Bisho", true, "SW");
            student[1] = new Student(101, 0, 26, "Makarious", true, "SW");
            student[2] = new Student(101, 0, 26, "Verina", false, "SW");
            student[3] = new Student(101, 0, 26, "Marina", false, "SW");
            student[4] = new Student(101, 0, 26, "Marina", false, "SW");
            student[5] = new Student(101, 0, 26, "Marina", false, "SW");
            student[6] = new Student(101, 0, 26, "Marina", false, "SW");
            student[7] = new Student(101, 0, 26, "Marina", false, "SW");
            student[8] = new Student(101, 0, 26, "Marina", false, "SW");
            student[9] = new Student(101, 0, 26, "Marina", false, "SW");
            student[9] = new Student(101, 0, 26, "Marina", false, "SW");
            student[9] = new Student(101, 0, 26, "Marina", false, "SW");
            student[9] = new Student(101, 0, 26, "Marina", false, "SW");
            Assert.AreNotEqual(Student.countMale, Student.countFemale);
        }
        [TestMethod]
        public void Test_CompatTo()
        {
            Person person1 = new Person(26, "Bishoo", true);
            Person person2 = new Person(26, "Bisho", false);
            Assert.AreEqual(1, String.Compare(person1.Name, person2.Name));
        }
        [TestMethod]
        public void Test_Comparing()
        {
            Person person1 = new Person(26, "Bisho", true);
            Person person2 = new Person(26, "Bisho", false);
            Assert.AreEqual(1, person1.Compare(person1, person2));
        }
        [TestMethod]
        public void Test_Constructor_Employee_withoutParameters()
        {
            Employee employee = new Employee();
            Assert.AreEqual(0, employee.Id);
            Assert.AreEqual(0, employee.Age);
            Assert.IsNull(employee.Name);
            Assert.AreEqual(true, employee.GenderMale);
            Assert.AreEqual(0, employee.Salary);
        }
        [TestMethod]
        public void Test_Constructor_Employee_withParameters()
        {
            Employee employee1 = new Employee(1, 2000, 26, "Bisho", true);
            Employee employee2 = new Employee(1, 2000, 26, "Bisho", true);
            Assert.IsTrue(AssertObjectAreEqual(employee1, employee2));
        }
        [TestMethod]
        public void Test_Constructor_Student_withoutParameters()
        {
            Student student = new Student();
            Assert.AreEqual(0, student.Id);
            Assert.AreEqual(0, student.Age);
            Assert.IsNull(student.Name);
            Assert.AreEqual(true, student.GenderMale);
            Assert.AreEqual(0, student.Salary);
            Assert.IsNull(student.Name);
            Assert.IsNull(student.Section);
        }
        [TestMethod]
        public void Test_Constructor_Student_withParameters()
        {
            Student student1 = new Student(1, 2000, 26, "Bisho", true, "SW");
            Student student2 = new Student(1, 2000, 26, "Bisho", true, "CS");
            Assert.IsTrue(AssertObjectAreEqual(student1, student2));
        }
        [TestMethod]
        public void Test_counting_number_student_by_section()
        {
            Student[] student = new Student[10];
            student[0] = new Student(101, 0, 26, "Bisho", true, "SW");
            student[1] = new Student(101, 0, 26, "Makarious", false, "CS");
            student[2] = new Student(101, 0, 26, "Verina", true, "SW");
            student[3] = new Student(101, 0, 26, "Marina", false, "CS");
            student[4] = new Student(101, 0, 26, "Marina", true, "SW");
            student[5] = new Student(101, 0, 26, "Marina", false, "CS");
            student[6] = new Student(101, 0, 26, "Marina", true, "SW");
            student[7] = new Student(101, 0, 26, "Marina", false, "CS");
            student[8] = new Student(101, 0, 26, "Marina", true, "SW");
            student[9] = new Student(101, 0, 26, "Marina", false, "CS");
            Assert.AreEqual(5, student[0].Count_number_student_by_section(student, "SW"));
        }
        [TestMethod]
        public void Test_Constructor_Teacher_withoutParameters()
        {
            Teacher teacher = new Teacher();
            Assert.AreEqual(0, teacher.Id);
            Assert.AreEqual(0, teacher.Age);
            Assert.IsNull(teacher.Name);
            Assert.AreEqual(true, teacher.GenderMale);
            Assert.AreEqual(0, teacher.Salary);
            Assert.IsNull(teacher.Name);
            Assert.IsNull(teacher.Section);
            Assert.AreEqual(0, teacher.Experience);
        }
        [TestMethod]
        public void Test_Constructor_Teacher_withParameters()
        {
            Teacher teacher1 = new Teacher(1, 2000, 26, "Bisho", true, "SW", 3);
            Teacher teacher2 = new Teacher(1, 2000, 26, "Bisho", true, "CS", 3);
            Assert.IsTrue(AssertObjectAreEqual(teacher1, teacher2));
        }
        private static bool AssertObjectAreEqual(Person expected, Person actual)
        {
            return expected.Age == actual.Age && expected.Name == actual.Name && expected.GenderMale == actual.GenderMale;
        }
        [TestMethod]
        public void Test_Sort()
        {
            IExecutable[] prints = new IExecutable[4];
            Person person = new Person(26, "Bisho", true);
            Student student = new Student(102, 0, -22, "Makarious", true, "SW");
            Employee employee = new Employee(101, 2500, 27, "Marina", false);
            Teacher teacher = new Teacher(102, 3500, 24, "Verina", false, "CS", 4);
            prints[0] = teacher;
            prints[1] = student;
            prints[2] = employee;
            prints[3] = person;
            Person[] people = new Person[4];
            for (int i = 0; i < 4; i++)
                people[i] = (Person)prints[i];
            Array.Sort(people);
            Assert.AreEqual("Bisho", people[0].Name);
        }
        [TestMethod]
        public void SortICompare()
        {
            IExecutable[] prints = new IExecutable[4];
            Person person = new Person(26, "Bisho", true);
            Student student = new Student(102, 0, -22, "Makarious", true, "SW");
            Employee employee = new Employee(101, 2500, 27, "Marina", false);
            Teacher teacher = new Teacher(102, 3500, 24, "Verina", false, "CS", 4);
            prints[0] = teacher;
            prints[1] = student;
            prints[2] = employee;
            prints[3] = person;
            Person[] people = new Person[4];
            for (int i = 0; i < 4; i++)
                people[i] = (Person)prints[i];
            Array.Sort(people, new Sort_By_Name());
            Assert.AreEqual("Verina", people[1].Name);
        }
        private static bool AssertObjectAreEqual(int expected, int actual)
        {
            return expected == actual;
        }
        // -------------------------------------------------------------------------------------------------------


        [TestMethod]
        public void MyNewCollectionConstructor()
        {
            // Arrange
            string expected = "First";
            // Act
            MyNewCollection<Student> list = new MyNewCollection<Student>("First");
            string result = list.Name;
            // Assert
            Assert.AreEqual(result, expected);

        }

        [TestMethod]
        public void MyNewCollectionChangeEvent()
        {
            // Arrange
            bool expected = true;
            // Act
            Student student = new Student(101, 0, 27, "Bisho", true, "SW");
            MyNewCollection<Student> list = new MyNewCollection<Student>("First");
            JournalResult<Student> journal = new JournalResult<Student>();
            list.OnCollectionReferenceChanged += journal.Add;
            list.Add_element(new Student(101,0,27,"Bisho",true,"SW"));

            list.Change(student);

            bool result = list.list[0].Name.ToString() == "Bisho" && journal.Journal[0].EventName == "changed";

            // Assert
            Assert.AreEqual(result, expected);

        }

        [TestMethod]
        public void MyNewCollectionAddObjEvent()
        {
            // Arrange
            bool expected = true;
            // Act

            Student student = new Student(101, 0, 27, "Bisho", true, "SW");
            MyNewCollection<Student> list = new MyNewCollection<Student>("First");
            JournalResult<Student> journal = new JournalResult<Student>();
            list.OnCollectionCountChanged += journal.Add;
            list.Add_element(student);
            bool result = journal.Journal[0].EventName.ToString() == " Add(T obj) ";
            // Assert
            Assert.AreEqual(result, expected);

        }

        [TestMethod]
        public void MyNewCollectionAddRangeEvent()
        {
            // Arrange
            bool expected = true;
            // Act
            Student student = new Student(101, 0, 27, "Bisho", true, "SW");
            List<Student> Range = new List<Student>();
            Range.Add(student);
            Range.Add(student);
            Range.Add(student);
            MyNewCollection <Student> list = new MyNewCollection<Student>("First");
            JournalResult<Student> journal = new JournalResult<Student>();
            list.OnCollectionCountChanged += journal.Add;
            list.Add_Range(Range);
            bool result = journal.Journal[0].EventName.ToString() == " Add Range(List<T> list) ";
            // Assert
            Assert.AreEqual(result, expected);
        }


        [TestMethod]
        public void MyNewCollectionDeleteEvent()
        {
            // Arrange
            bool expected = true;
            // Act
            Student student = new Student(101, 0, 27, "Bisho", true, "SW");
            MyNewCollection<Student> list = new MyNewCollection<Student>("First");
            JournalResult<Student> journal = new JournalResult<Student>();
            list.OnCollectionCountChanged += journal.Add;
            list.Delete_element(student);
            bool result = journal.Journal[0].EventName.ToString() == " Delete(T obj) ";
            // Assert
            Assert.AreEqual(result, expected);

        }


        [TestMethod]
        public void MyNewCollectionDeleteRangeEvent()
        {
            // Arrange
            bool expected = true;
            // Act
            Student student = new Student(101, 0, 27, "Bisho", true, "SW");
            List<Student> Range = new List<Student>();
            Range.Add(student);
            Range.Add(student);
            Range.Add(student);
            MyNewCollection<Student> list = new MyNewCollection<Student>("First");
            JournalResult<Student> journal = new JournalResult<Student>();
            list.Add_element(student);
            list.Add_element(student);
            list.Add_element(student);
            list.OnCollectionCountChanged += journal.Add;
            list.DeleteRange(0, 3, Range);

            bool result = journal.Journal[0].EventName.ToString() == " Delete Range(List<T>) ";
        
            Assert.AreEqual(result, expected);

        }
        [TestMethod]
        public void TestConstructor()
        {
            // Arrange
            bool expected = true;
            // Act
            CollectionHandlerEventArgs<Student> args = new CollectionHandlerEventArgs<Student>("Collection", "Add", new Student[] { new Student(101,0,23,"Bisho",true,"SW") });
            bool result = args.Name == "Collection" && args.EventName == "Add" && args.EventParticipants[0].Name == "Bisho";


            // Assert
            Assert.AreEqual(result, expected);

        }
        [TestMethod]
        public void TestParts()
        {
            MyNewCollection<Student> listFirst = new MyNewCollection<Student>("First");
            MyNewCollection<Student> listSecond = new MyNewCollection<Student>("Second");
            JournalResult< Student > journalFirst= new JournalResult<Student>();
            Program.FirstPart(listFirst,journalFirst);
            Program.SecondPart(listFirst, listSecond, journalFirst);
        }
    }
}
