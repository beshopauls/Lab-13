using System;
namespace Lab_10
{
    public class Teacher:Student
    {
        int _experience;
        public int Experience
        {
            get { return _experience; }
            set 
            {
                if (value < 0)
                    _experience = 0;
                else
                _experience = value;
            }
        }
        public Teacher():base(0,0,0,null,true,null)
        {
            _experience=0;
        }
        public Teacher(int id, int salary, int age, string name, bool gender, string section ,int experience) : base(id, salary, age, name, gender,section)
        {
            this.Experience = experience;
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine(" Salary : {0}", this.Salary);
            Console.WriteLine(" Experience : {0}", this.Experience);
        }
        
        public override void Print_Names_Males()
        {
            base.Print_Names_Males();
        }
        public override void Print_Names_Females()
        {
            base.Print_Names_Females();
        }
    }
}