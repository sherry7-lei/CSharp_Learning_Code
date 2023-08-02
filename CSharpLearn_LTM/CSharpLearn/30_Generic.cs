using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearn
{
    /*---------------------------- 1.泛型 ----------------------------*/
    /*------------------ （1）基本介绍 ------------------*/

    /*------------------ （2）泛型类示例 ------------------*/
    /*
    class Program
    {
        static void Main(string[] args)
        {
            Apple apple = new Apple() { Color = "Red" };
            Book book = new Book() { Name = "Math" };
            Box<Apple> box1 = new Box<Apple> { Cargo = apple };
            Console.WriteLine(box1.Cargo.Color);
            Box<Book> box2 = new Box<Book>() { Cargo = book };
            Console.WriteLine(box2.Cargo.Name);
        }
    }
    class Apple
    {
        public string Color { get; set; }
    }
    class Book
    {
        public string Name { get; set; }
    }

    class Box<T>
    {
        public T Cargo { get; set; }
    }
    */

    /*------------------ （3）泛型接口示例 ------------------*/
    /*
    class Program
    {
        static void Main(string[] args)
        {
            var stu = new Student<int>();
            stu.Id = 101;
            stu.Name = "Timothy";

            var stu1 = new Student<ulong>();
            stu1.Id = 1000000000000001;
            stu1.Name = "Timothy";

            var stu2 = new Student();
            stu2.Id = 100000000001;
            stu2.Name = "Elizabeth";
        }
    }

    interface IUnique<T>
    {
        T Id { get; set; }
    }

    // 泛型类实现泛型接口
    class Student : IUnique<ulong>
    {
        public ulong Id { get; set; }

        public string Name { get; set; }
    }

    // 具体类实现特化化后的泛型接口
    class Student<T> : IUnique<T>
    {
        public T Id { get; set; }

        public string Name { get; set; }
    }
    */

    /*------------------ （4）泛型集合示例 ------------------*/
    /*
    class Program
    {
        static void Main(string[] args)
        {
            IList<int> list = new List<int>();
            for (var i = 0; i < 100; i++)
            {
                list.Add(i);
            }

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            IDictionary<int, string> dict = new Dictionary<int, string>();
            dict[1] = "Timothy";
            dict[2] = "Michael";
            Console.WriteLine($"Student #1 is {dict[1]}");
            Console.WriteLine($"Student #2 is {dict[2]}");
        }
    }
    */

    /*------------------ （5）泛型算法示例 ------------------*/
    /*
    class Program
    {
        static void Main(string[] args)
        {
            int[] a1 = { 1, 2, 3, 4, 5 };
            int[] a2 = { 1, 2, 3, 4, 5, 6 };
            double[] a3 = { 1.1, 2.2, 3.3, 4.4, 5.5 };
            double[] a4 = { 1.1, 2.2, 3.3, 4.4, 5.5, 6.6 };
            var result1 = Zip(a1, a2);
            Console.WriteLine(string.Join(",", result1));
            var result2 = Zip(a3, a4);
            Console.WriteLine(string.Join(",", result2));
        }

        static T[] Zip<T>(T[] a, T[] b)
        {
            T[] zipped = new T[a.Length + b.Length];
            int ai = 0, bi = 0, zi = 0;
            do
            {
                if (ai < a.Length) zipped[zi++] = a[ai++];
                if (bi < b.Length) zipped[zi++] = b[bi++];
            } while (ai < a.Length || bi < b.Length);

            return zipped;
        }
    }
    */

    /*------------------ （6）泛型委托示例 ------------------*/
    // 1）Action 泛型委托
    /*
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> a1 = Say;
            a1("Timothy");

            Action<int> a2 = Mul;
            a2(1);
        }

        static void Say(string str)
        {
            Console.WriteLine($"Hello, {str}!");
        }

        static void Mul(int x)
        {
            Console.WriteLine(x * 100);
        }
    }
    */

    // 2）Function 泛型委托
    /*
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> f1 = Add;
            Console.WriteLine(f1(1, 2));

            Func<double, double, double> f2 = Add;
            Console.WriteLine(f2(1.1, 2.2));

            // Lambda表达式
            //Func<int, int, int> f3 = (int a, int b) => { return a + b; };
            Func<int, int, int> f3 = (a, b) => { return a + b; };
            Console.WriteLine(f3(1, 2));
        }

        static int Add(int a, int b)
        {
            return a + b;
        }

        static double Add(double a, double b)
        {
            return a + b;
        }
    }
    */

    // 3）自定义泛型委托
    /*
    class Program
    {
        static void Main(string[] args)
        {
            MyDele<string> myDele = new MyDele<string>((new Program()).Report);
            myDele.Invoke("Sherry");

            MyDele<int> myDele2 = new MyDele<int>(Write);
        }

        void Report(string str)
        {
            Console.WriteLine(str);
        }

        static void Write(int x)
        {
            Console.WriteLine(x*100);
        }
    }

    delegate void MyDele<T> (T t);
    */

    /*---------------------------- 2.partial类 ----------------------------*/


    /*---------------------------- 3.枚举类型 ----------------------------*/
    /*------------------ （1）枚举示例 ------------------*/
    /*
    class Program
    {
        static void Main(string[] args)
        {
            var employee = new Person
            {
                Level = Level.Employee
            };

            var boss = new Person
            {
                Level = Level.Boss
            };

            Console.WriteLine(boss.Level > employee.Level);
            // True

            Console.WriteLine((int)Level.Employee);// 0
            Console.WriteLine((int)Level.Manager); // 100
            Console.WriteLine((int)Level.Boss);    // 200
            Console.WriteLine((int)Level.BigBoss); // 201
        }
    }
    enum Level
    {
        Employee,
        Manager = 100,
        Boss = 200,
        BigBoss,
    }

    class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Level Level { get; set; }
    }
    */

    /*------------------ （2）枚举的比特位用法 ------------------*/
    /*
    class Program
    {
        static void Main(string[] args)
        {
            var employee = new Person
            {
                Name = "Timothy",
                Skill = Skill.Drive | Skill.Cook | Skill.Program | Skill.Teach
            };

            Console.WriteLine(employee.Skill); // 15

            // 过时用法不推荐
            //Console.WriteLine((employee.Skill & Skill.Cook) == Skill.Cook); // True

            // .NET Framework 4.0 后推荐的用法
            Console.WriteLine((employee.Skill.HasFlag(Skill.Cook))); // True
        }
    }

    [Flags]
    enum Skill
    {
        Drive = 1,
        Cook = 2,
        Program = 4,
        Teach = 8,
    }

    class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Skill Skill { get; set; }
    }
    */

    /*---------------------------- 4.结构体类型 ----------------------------*/
    /*------------------ （1）结构体示例 ------------------*/
    /*
    class Program
    {
        static void Main(string[] args)
        {
            var stu = new Student { Id = 101, Name = "Timothy" };

            // 装箱：复制一份栈上的 stu ，放到堆上去，然后用 obj 引用堆上的 student 实例
            object obj = stu;

            // 拆箱
            Student stu2 = (Student)obj;
            Console.WriteLine($"#{stu2.Id} Name:{stu2.Name}");
        }
    }
    struct Student
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
    */

    /*------------------ （2）结构体实现接口 ------------------*/
    /*
    class Program
    {
        static void Main(string[] args)
        {
            var stu1 = new Student { Id = 101, Name = "Timothy" };
            stu1.Speak();
        }
    }

    interface ISpeak
    {
        void Speak();
    }

    struct Student : ISpeak
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public void Speak()
        {
            Console.WriteLine($"I'm #{Id} student {Name}");
        }
    }
    */
    /*------------------ （3）结构体不能有显示无参构造器 ------------------*/

}
