using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

/*====================================================================================================*/
//                                              类
// 可以通过 实例化 / 反射 / 动态 三种方式来创建对象
// 类一般用public / internal修饰
// 类内部的构造函数（默认构造、带参构造、静态构造），析构函数，字段，属性，成员方法等
/*====================================================================================================*/

namespace CSharpLearn
{
    /*
    internal class _23_Class
    {
        static void Main(string[] args)
        {
            // 正常用类实例化对象
            Student stu1 = new Student(1, "sherry");
            Console.WriteLine($"The {stu1.ID} number student's name is {stu1.Name}");

            Type t = typeof(Student);
            // 反射
            object o = Activator.CreateInstance( t, 2, "cherry" );
            Student stu2 = o as Student;
            Console.WriteLine($"The {stu2.ID} number student's name is {stu2.Name}");

            // 动态
            dynamic d = Activator.CreateInstance(t, 3, "zherry");
            Student stu3 = d as Student;
            Console.WriteLine($"The {stu3.ID} number student's name is {stu3.Name}");
        }
    }

    class Student
    {
        // 静态属性
        public static int Amount { get; set; }
        // 属性
        public int ID { get; set; }
        public string Name { get; set; }
        // 静态构造函数
        static Student()
        {
            Amount = 0;
        }
        // 带参构造函数
        public Student(int id, string name)
        {
            ID = id;
            Name = name;
        }
        // 成员方法
        public void Report()
        {
            Console.WriteLine($"I'm #{ID} student, my name is {Name}.");
        }
        // 析构函数
        ~Student()
        {
            Console.WriteLine("Bye bye! Release the system resources ...");
        }
    }
    */
}
