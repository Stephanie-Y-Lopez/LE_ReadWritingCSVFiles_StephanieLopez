using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LE_ReadWritingCSVFiles_StephanieLopez
{
    public class Student
    {
        //Fields
        public string _firstname { get; set; }
        public string _lastname { get; set; }
        public int _grade { get; set; }


        //Constructor
        public Student(string firstname, string lastname, int grade)
        {
            Firstname = firstname;
            Lastname = lastname;
            Grade = grade;
        }

        //Properties
        public string Firstname { get => _firstname; set => _firstname = value; }
        public string Lastname { get => _lastname; set => _lastname = value; }
        public int Grade { get => _grade; set => _grade = value; }


        //Display
        public virtual void StudentInfo()
        {
            Console.WriteLine("Student Information:");
            Console.WriteLine($"First Name: {_firstname}");
            Console.WriteLine($"Last Name: {_lastname}");
            Console.WriteLine($"Grade: {_grade}");
        }
    }
}
