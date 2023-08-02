using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearn
{
    // （1）委托
    /*
    class Program
    {
        static void Main(string[] args)
        {
            MyDele myDele = new MyDele((new Program()).Report);
            myDele.Invoke(3);

            MyDele myDele2 = new MyDele(Write);
            myDele2.Invoke(3);
        }

        void Report(int str)
        {
            Console.WriteLine(str);
        }

        static void Write(int x)
        {
            Console.WriteLine(x * 100);
        }
    }
    delegate void MyDele(int t);
    */

    // （2）自定义泛型委托
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

    // （3）标准泛型委托 Action/Function + Lambda表达式（inline的匿名方法）
    /*
    internal class _31_Delegate_Lambda_LINQ
    {
        static void Main(string[] args)
        {
            // 常规委托
            Action action = new Action(Methods.M1);
            action.Invoke();
            // Lambda表达式 —— 给一个委托变量直接赋值Lambda表达式
            //action = new Action(() => { Console.WriteLine("M1 is called"); });
            action = () => { Console.WriteLine("M1 is called"); };
            action.Invoke();

            // Lambda表达式其他用法示例1
            //Action action1 = new Action(() => { Methods.M2(); });
            Action action1 = () => { Methods.M2(); };
            action1.Invoke();
            // Lambda表达式其他用法示例2
            //Action action2 = new Action(() => { Console.WriteLine("Lambda!"); });
            Action action2 = () => { Console.WriteLine("Lambda!"); };
            action2.Invoke();

            // 常规委托
            Func<int, int, int> func1 = new Func<int, int, int>(Methods.Add);
            Console.WriteLine(func1.Invoke(100, 200));
            // Lambda表达式 —— 直接将Add函数实现逻辑放在Lambda表达式中
            //Func<int, int, int> func2 = new Func<int, int, int>((int a, int b) => { return a + b; });
            Func<int, int, int> func2 = (int a, int b) => { return a + b; };
            Console.WriteLine(func2.Invoke(100, 200));

            // 常规委托
            Func<double, double, double> func3 = new Func<double, double, double> (Methods.Mul);
            Console.WriteLine(func3.Invoke(1.1, 2.2));
            // Lambda表达式 —— 在Lambda表达式中调用Mul函数
            //Func<double, double, double> func4 = new Func<double, double, double>((double a, double b) => { return a * b; });
            //化简为
            //Func<double, double, double> func4 = (double a, double b) => { return a * b; };
            //化简为
            //Func<double, double, double> func4 = ( a, b) => { return a * b; };
            //化简为
            Func<double, double, double> func4 = ( a, b) =>  a * b;
            Console.WriteLine(func4.Invoke(1.1, 2.2));
        }
    }

    class Methods
    {
        public static void M1()
        {
            Console.WriteLine("M1 is called");
        }

        public static void M2()
        {
            Console.WriteLine("M2 is called");
        }

        public static int Add(int x, int y)
        {
            return x + y;
        }

        public static double Mul(double x, double y)
        {
            return Math.Pow(x, y);
        }
    }
    */

    // （4）泛型委托+Lambda表达式的综合示例
    /*
    class Program
    {
        static void Main(string[] args)
        {
            //DoSomeCalc<int>((int a, int b) => { return a + b; }, 100, 200);
            // 通过传入的100/200, 可推导出T为int类型，因此可简化为：
            DoSomeCalc((a, b) => { return a + b; }, 100, 200);
        }

        static void DoSomeCalc<T>(Func<T , T, T> func, T x, T y)
        {
            T result = func(x, y);
            Console.WriteLine(result);
        }
    }
    */

    // （5）LINQ
    /*
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
    */
}
