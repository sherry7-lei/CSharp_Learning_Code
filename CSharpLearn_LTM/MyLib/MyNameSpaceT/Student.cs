using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.MyNameSpaceT
{
    public class Teacher
    {
        public void Report()
        {
            Console.WriteLine("I'm a teacher!");
        }
    }

    internal class Student
    {
        public void Report()
        {
            Console.WriteLine("I'm a teacher!");
        }
    }
}
