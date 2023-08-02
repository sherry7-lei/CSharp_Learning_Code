using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

/*====================================================================================================*/
// 重写 和 重定义
// 重定义（隐藏）：基类和派生类中具有相同函数名的方法，又无override修饰，即构成隐藏，什么类型的变量调用什么类型的方法
// 重写（多态）：函数成员(函数成员才能继承) +
//               可见（public/protected） +
//               签名一致（方法名称 + 类型形参的个数 + 每个形参的类型和种类）
/*====================================================================================================*/

namespace CSharpLearn
{
    /*
    // 隐藏
    public class Program
    {
        static void Main(string[] args)
        {
            // 实例化对象调用
            Person person = new Person();
            Student student = new Student();
            person.Report();
            student.Report();

            // p为Person类型的变量，将Student类型的对象赋值，再调用Report方法
            // 由于Student类并没有对Report方法重写，无法形成多态，因此p调用Person类中的Report方法
            Person p = new Student();
            p.Report();

        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Report()
        {
            Console.WriteLine("I'm a Person");
        }
    }
    class Student : Person
    {
        public string Address { get; set; }
        public void Report()
        {
            Console.WriteLine("I'm a Student");
        }
    }
    */

    // 多态
    /*
    public class Program
    {
        static void Main(string[] args)
        {
            // 实例化对象调用
            Person person = new Person();
            Person student = new Student();
            person.Report();
            student.Report();

            // 多态
            person.Work();
            student.Work();
        }
    }
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private double _rmb;

        public virtual double Money
        {
            get { return _rmb; }
            set { _rmb = value; }
        }


        public void Report()
        {
            Console.WriteLine("I'm a Person");
        }

        public virtual void Work()
        {
            _rmb = 100;
            Console.WriteLine($"Person work hard, my money is {_rmb}");
        }
    }

    class Student : Person
    {
        public string Address { get; set; }

        // 属性重写
        private double _dollar;
        public override double Money
        {
            get { return _dollar; }
            set { _dollar = value; }
        }

        // 隐藏
        public void Report()
        {
            Console.WriteLine("I'm a Student");
        }

        // 方法重写
        public override void Work()
        {
            _dollar = 1000;
            Console.WriteLine($"Student work hard, my money is {_dollar}");
        }
    }
    */
}
