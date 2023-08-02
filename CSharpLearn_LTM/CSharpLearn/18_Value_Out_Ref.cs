using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*====================================================================================================*/
// 值类型：结构体 + 枚举
// 引用类型：类 + 接口 + 委托

//                                      值参数
// 值参数传递过程类似于C++中传值传参
// 1）传值类型参数：形参变化不影响实参
// 2）传引用类型参数（创建新对象）：由于引用类型传递的是地址，但只是通过地址获取参数赋值给新创建的对象，形参变化不影响实参
// 3）传引用类型参数（不创建新对象）：由于引用类型传递的是地址，形参和实参不是一块地址空间，但是存储的地址是一样的，形参利用地址修改属性，也会影响实参（避免该情况）

//                                     引用参数
// 引用参数传递过程类似于C++中引用传参，形参和实参指向同一块地址空间，作为引用参数之前必须被赋值
// 1）传值类型参数：形参变化影响实参
// 2）传引用类型参数（创建新对象）：形参变化影响实参（实参和形参指向新的对象，hashcode变化）
// 3）传引用类型参数（不创建新对象）：形参变化影响实参

//                                     输出参数
// 输出参数传递过程类似于C++中传地址传参，形参和实参指向同一块地址空间，作为输出参数之前可以不被赋值
// 1）传值类型参数：形参变化影响实参
// 2）传引用类型参数：形参变化影响实参

//                                     数组参数
// 必需是形参列表中的最后一个，由 params 修饰

//                                    具名参数
// 具名参数使参数的位置不再受约束

//                                    可选参数
// 可选参数类似于C++中缺省参数
/*====================================================================================================*/

namespace CSharpLearn
{
    /*--------- 1.值参数 ----------*/
    // （1）传值参数——值类型 -> 形参变化不影响实参
    // （2）传值参数——引用类型，创建新对象 -> 形参变化不影响实参
    /*
    internal class Program
    {
        static void Main(string[] args)
        {
            var stu = new Student() { Name = "Tim" };
            SomeMethod(stu);
            Console.WriteLine(stu.Name);
            Console.WriteLine(stu.GetHashCode());
        }
        static void SomeMethod(Student stu)
        {
            stu = new Student { Name = "Tim" };
            Console.WriteLine(stu.Name);
            Console.WriteLine(stu.GetHashCode());
        }
        class Student
        {
            public string Name { get; set; }
        }
    }
     */

    // （3）传值参数——引用类型，只操作对象，不创建对象 -> 形参变化影响实参
    // 由于引用类型传递的是地址，形参利用地址修改属性，也会影响实参
    /*
    class Program
    {
        static void Main(string[] args)
        {
            var outterStu = new Student() { Name = "Tim" };
            Console.WriteLine(outterStu.Name);
            Console.WriteLine(outterStu.GetHashCode());
            Console.WriteLine("--------------");
            UpdateMethod(outterStu);
            Console.WriteLine("--------------");
            Console.WriteLine(outterStu.Name);
            Console.WriteLine(outterStu.GetHashCode());
        }
        static void UpdateMethod(Student stu)
        {
            // 副作用（side-effect）
            // 实际编程过程需要避免
            stu.Name = "Tom";
            Console.WriteLine(stu.Name);
            Console.WriteLine(stu.GetHashCode());
        }
        class Student
        {
            public string Name { get; set; }
        }
    }
    */

    /*--------- 2. 引用参数 ----------*/
    // （1）引用参数——值类型 -> 引用参数与实参指向同一块区域
    /*
    class Program
    {
        static void Main(string[] args)
        {
            int y = 1;
            IWantSideEffect(ref y);
            Console.WriteLine(y);
        }
        static void IWantSideEffect(ref int x)
        {
            x += 100;
        }
    }
    */

    // （2）引用参数——引用类型,创建新对象 -> 形参和实参都指向新创建的对象
    /*
    class Program
    {
        static void Main(string[] args)
        {
            var outterStu = new Student() { Name = "Tim" };
            Console.WriteLine("HashCode={0}, Name={1}", outterStu.GetHashCode(), outterStu.Name);
            Console.WriteLine("-----------------");
            IWantSideEffect(ref outterStu);
            Console.WriteLine("HashCode={0}, Name={1}", outterStu.GetHashCode(), outterStu.Name);
        }
        static void IWantSideEffect(ref Student stu)
        {
            stu = new Student() { Name = "Tom" };
            Console.WriteLine("HashCode={0}, Name={1}", stu.GetHashCode(), stu.Name);
        }
        class Student
        {
            public string Name { get; set; }
        }
    }
    */

    // （3）引用参数——引用类型,不创建新对象，只改变对象值 -> 与传值参数——引用类型效果一致，但原理不同
    // 传值参数——引用类型:实参stu和形参stu是两个对象，分别在不同地址空间，存放的都是Student对象的地址
    // 引用参数——引用类型:实参outterStu和形参stu是一个对象，共用一块地址空间
    /*
    class Program
    {
        static void Main(string[] args)
        {
            var outterStu = new Student() { Name = "Tim" };
            Console.WriteLine("HashCode={0}, Name={1}", outterStu.GetHashCode(), outterStu.Name);
            Console.WriteLine("-----------------");
            SomeSideEffect(ref outterStu);
            Console.WriteLine("HashCode={0}, Name={1}", outterStu.GetHashCode(), outterStu.Name);
        }
        static void SomeSideEffect(ref Student stu)
        {
            stu.Name = "Tom";
            Console.WriteLine("HashCode={0}, Name={1}", stu.GetHashCode(), stu.Name);
        }
         class Student
        {
            public string Name { get; set; }
        }
    }
    */

    /*--------- 3.输出参数 ----------*/
    // （1）输出参数——值类型
    /*
    class Program
    {
        static void Main(string[] args)
        {
            double x = 0;
            if (DoubleParser.TryParse("aa", out x))
            {
                Console.WriteLine(x);
            }
        }
    }
    class DoubleParser
    {
        public static bool TryParse(string input, out double result)
        {
            try
            {
                result = double.Parse(input);
                return true;
            }
            catch
            {
                result = 0;
                return false;
            }
        }
    }
    */

    // （2）输出参数——引用类型
    /*
    class Program
    {
        static void Main(string[] args)
        {
            Student1 stu = null;
            if (StudentFactory.Create("Tim", 34, out stu))
            {
                Console.WriteLine("Student {0}, age is {1}", stu.Name, stu.Age);
            }
        }
    }
    class Student1
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
    class StudentFactory
    {
        public static bool Create(string stuName, int stuAge, out Student1 result)
        {
            result = null;
            if (string.IsNullOrEmpty(stuName))
            {
                return false;
            }

            if (stuAge < 20 || stuAge > 80)
            {
                return false;
            }

            result = new Student1() { Name = stuName, Age = stuAge };
            return true;
        }
    }
    */

    /*--------- 4.数组参数 ----------*/
    // 数组参数只能有一个，且只能为参数列表最后一个。
    // 因为数组参数可以接收任意个输入，多个数组参数无法区分参数的输入指向。
    /*
    class Program
    {
        static void Main(string[] args)
        {
            // 通过数组参数，可以在调用时使用数字，而不是强制使用数组
            //int[] array = new int[] {1, 2, 3};
            //int result = CalculateSum(array);
            int result = CalculateSum(1, 2, 3);
            Console.WriteLine(result);
        }
        static int CalculateSum(params int[] intArray)
        {
            int sum = 0;
            foreach (var item in intArray)
            {
                sum += item;
            }
            return sum;
        }
    }
    */

    /*--------- 5.具名参数 ----------*/
    /*
    class Program
    {
        static void Main(string[] args)
        {
            // 不具名调用（形参顺序确定）
            PrintInfo("Tim", 34);

            // 具名调用（参数顺序可以任意，且可读性更高）
            PrintInfo(age: 24, name: "Wonder");
        }

        static void PrintInfo(string name, int age)
        {
            Console.WriteLine("Helllo {0}, you are {1}.", name, age);
        }
    }
    */

    /*---------  6.可选参数 ----------*/
    // 与C++中的缺省参数类似
    /*
    class Program
    {
        static void Main(string[] args)
        {
            PrintInfo();
            PrintInfo("Tom", 34);
        }

        static void PrintInfo(string name = "Tim", int age = 24)
        {
            Console.WriteLine("Helllo {0}, you are {1}.", name, age);
        }
    }
    */

    /*--------- 7.扩展方法 ----------*/
    // 要求：（1）必须在静态类中（2）必须由public static修饰（3）必须作用于参数列表第一个，由this修饰
    /*
    class Program
    {
        static void Main(string[] args)
        {
            double x = Math.PI;
            // 未用扩展方法，进行double类型变量处理
            double y = Math.Round(x, 4);
            Console.WriteLine(y);
            // 使用扩展方法
            double z = x.Rand(4);
            Console.WriteLine(z);
        }
    }
    // Double的扩展方法
    static class DoubleExtension
    {
        public static double Rand(this double input, int digst)
        {
            double ret = Math.Round(input, digst);
            return ret;
        }
    }
    */
}
