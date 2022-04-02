using System;
namespace Lab_10
{
    public class Person : IComparable, ICloneable , IExecutable
    {
        int _age;
        string _name;
        bool _genderMale = true;
       public static int countMale=0;
       public static int countFemale=0;
        #region properties
        public int Age
        {
            get { return _age; }
            set 
            {
                if (value < 0)
                {
                    value = 0;
                    _age = value;
                }
                else
                    _age = value;
            }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public bool GenderMale
        {
            get { return _genderMale; } 
            set { _genderMale = value; }
        }
        #endregion
        #region constractors
        public Person()
        {
            this._age = 0;
            this._name = null;
            this._genderMale = true;
           
        }
        public Person(int age , string name , bool gender)
        {
            if(age < 0)
                age = 0;
            this._age = age;    
            this._name = name;
            this._genderMale = gender;
            if (this._genderMale == true)
                countMale++;
            else
                countFemale++;
        }
        #endregion
        #region Methods
        //Compare by name using Compare function
        public int CompareTo(object obj)
        {
            Person temp = obj as Person;
            if (String.Compare(this.Name, temp.Name) > 0) return 1;
            else return -1;

        }
        public int Compare(object x, object y)
        {
            Person person1 = x as Person;
            Person person2 = y as Person;
            if (person1 == null && person2 == null)
                return -1;
            return person1._age.CompareTo(person2._age)
                ^ person1._name.CompareTo(person2._name)
                ^ person1._genderMale.CompareTo(person2._genderMale);
        }
        public object Clone()
        {
            return new Person(this._age,this.Name ,this.GenderMale);
        }
        public virtual void Print()
        {
            Console.WriteLine(" Name : {0}  ",this.Name);
            Console.WriteLine(" Age : {0}", this.Age);
            if (_genderMale == true)
                Console.WriteLine(" Gender : Male");
            else
                Console.WriteLine(" Gender : Female");

        }
        public virtual void Print_Names_Males()
        {
            if (_genderMale == true)
                Console.WriteLine(" Name : {0}  ", this.Name);
        }
        public virtual void Print_Names_Females()
        {
            if (_genderMale == true)
                Console.WriteLine(" Name : {0}  ", this.Name);
        }
        #endregion
    }
}