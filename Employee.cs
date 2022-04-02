using System;
namespace Lab_10
{
    public class Employee:Person, IComparable
    {
        public int Id { get; set; }
        public virtual int Salary { get; set; } 
  
        public Employee():base(0,null,true)
        {
            this.Id = 0;
            this.Salary = 0;    
        }
        public Employee(int id , int salary, int age, string name, bool gender_male) : base(age, name, gender_male)
        {
            this.Id = id;
            this.Salary = salary;
        }
        public override void Print_Names_Females()
        {
            base.Print_Names_Females();
        }
        public override void Print_Names_Males()
        {
            base.Print_Names_Males();
        }

    }
}