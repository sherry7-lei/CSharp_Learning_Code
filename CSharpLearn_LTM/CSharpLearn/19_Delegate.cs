using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*====================================================================================================*/
//                                          委托
// 1）委托类似于C/C++中的函数指针
// 2）可以使用C#自带的Action(无返回值，可传参) 和 Func(有返回值，可传参)的委托
// 也可以自定义委托，通过delegate关键字（public delegate T Mydele<T>(T input1, T input2)）
// 3）委托可以通过+=实现多播委托
// 调用分同步调用（函数直接调用 / Invoke() / +=多播委托 ）和异步调用（BeginInvoke / Thread / Task）
// 4）可以使用接口替代委托
/*====================================================================================================*/

namespace CSharpLearn
{
    /*----------------------*/  /*1.委托是什么*/   /*----------------------*/
    /*
    class Program
    {
        static void Main(string[] args)
        {
            Function function = new Function();
            // 常规调用
            function.Report();
            function.Add(100, 200);
            function.Sub(100, 200);

            // 使用C#自带的委托
            Action act = new Action(function.Report);
            // act.Invoke();
            act();

            Func<double, double, double> func1 = new Func<double, double, double>(function.Add);
            double result1 = func1.Invoke(100, 200);
            Console.WriteLine(result1);

            Func<double, double, double> func2 = new Func<double, double, double> (function.Sub);
            double result2 = func2.Invoke(100, 200);
            Console.WriteLine(result2);
        }
    }
    class Function
    {
        public void Report()
        {
            Console.WriteLine("this class has three methods");
        }

        public double Add(double x, double y) 
        {
            return x + y;
        }

        public double Sub(double x, double y)
        {
            return x - y;
        }
    }
    */

    /*----------------------*/  /*2.自定义委托*/   /*----------------------*/
    /*
    public delegate double Calc(double x, double y);
    class Program
    {
        static void Main(string[] args)
        {
            Calculate calculate = new Calculate();
            Calc calc1 = new Calc(calculate.Add);
            Calc calc2 = new Calc(calculate.Sub);
            Calc calc3 = new Calc(calculate.Mul);
            Calc calc4 = new Calc(calculate.Div);

            double result = calc1.Invoke(100, 200);
            Console.WriteLine(result);

            result = calc2.Invoke(100, 200);
            Console.WriteLine(result);

            result = calc3.Invoke(100, 200);
            Console.WriteLine(result);

            result = calc4.Invoke(100, 200);
            Console.WriteLine(result);
        }
    }
    class Calculate
    {
        public double Add(double x, double y)
        {
            return x + y;
        }
        public double Sub(double x, double y)
        {
            return x - y;
        }
        public double Mul(double x, double y)
        {
            return x * y;
        }
        public double Div(double x, double y)
        {
            return x / y;
        }
    }
    */

    /*----------------------*/  /*3.委托的一般应用*/   /*----------------------*/
    /*
    class Program
    {
        static void Main(string[] args)
        {
            //（1） 模板方法，Func模板可以有输入参数，但最后一个为返回值，因此Product为返回值
            // 该模板接受返回值为Product的方法
            var productFactory = new ProductFactory();
            Func<Product> func1 = new Func<Product>(productFactory.MakePizza);
            Func<Product> func2 = new Func<Product>(productFactory.MakeToyCar);

            //（2） 回调方法，Action模板只有输入参数，没有返回值，因此Product为输入
            // 该模板接受输入值为Product的方法
            var logger = new Logger();
            Action<Product> log = new Action<Product>(logger.Log);

            var wrapFactory = new WrapFactory();
            Box box1 = wrapFactory.WrapProduct(func1, log);
            Box box2 = wrapFactory.WrapProduct(func2, log);

            Console.WriteLine(box1.Product.Name);
            Console.WriteLine(box2.Product.Name);
        }
    }

    // 产品类
    class Product
    {
        // 产品属性
        public string Name { get; set; }
        public double Price { get; set; }
    }

    // 盒子类
    class Box
    {
        // 盒子属性
        public Product Product { get; set; }
    }

    // 日志类
    class Logger
    {
        // 实例方法
        public void Log(Product product)
        {
            Console.WriteLine(" {0} is producted at {1}, price is {2}", product.Name, DateTime.UtcNow, product.Price);
        }
    }

    // 产品生产类
    class ProductFactory
    {
        // 实例方法
        public Product MakePizza()
        {
            var product = new Product();
            product.Name = "Pizza";
            product.Price = 30;
            return product;
        }
        public Product MakeToyCar()
        {
            var product = new Product();
            product.Name = "Toy Car";
            product.Price = 100;
            return product;
        }
    }

    // 包装产品类
    class WrapFactory
    {
        // 模板方法，提高复用性
        // 该模板方法需要两个实例方法（返回值为Product的方法 和 一个Product类型输入的方法）
        public Box WrapProduct(Func<Product> getProduct, Action<Product> Log)
        {
            var box = new Box();
            Product product = getProduct.Invoke();
            if(product.Price > 50)
                Log(product);

            box.Product = product;
            return box;
        }
    }
    */

    /*----------------------*/  /*4.委托的高级应用*/   /*----------------------*/
    /*
    class Program
    {
        static void Main(string[] args)
        {
            Student stu1 = new Student() {ID = 1, Color = ConsoleColor.Yellow };
            Student stu2 = new Student() {ID = 2, Color = ConsoleColor.Green };
            Student stu3 = new Student() {ID = 3, Color = ConsoleColor.Blue };

            // （1）多播委托
            //Action act1 = new Action(stu1.DoHomework);
            //Action act2 = new Action(stu2.DoHomework);
            //Action act3 = new Action(stu3.DoHomework); 
            //act1 += act2;
            //act1 += act3;
            //act1.Invoke();

            // （2）同步调用 —— 单个线程进行调用
            // 第一种：直接同步调用
            //stu1.DoHomework();
            //stu2.DoHomework();
            //stu3.DoHomework();

            // 第二种：间接同步调用
            //Action act1 = new Action(stu1.DoHomework);
            //Action act2 = new Action(stu2.DoHomework);
            //Action act3 = new Action(stu3.DoHomework);
            //act1.Invoke();
            //act2.Invoke();
            //act3.Invoke();

            // 第三种：多播委托同步调用
            //Action act1 = new Action(stu1.DoHomework);
            //Action act2 = new Action(stu2.DoHomework);
            //Action act3 = new Action(stu3.DoHomework);
            //act1 += act2;
            //act1 += act3;
            //act1.Invoke();

            // （3）异步调用 —— 多个线程同时调用
            // 异步调用时多线程可能会同时访问一块内存空间，造成线程间争夺资源，发生冲突
            // （3.1）使用委托实现异步调用
            //Action act1 = new Action(stu1.DoHomework);
            //Action act2 = new Action(stu2.DoHomework);
            //Action act3 = new Action(stu3.DoHomework);
            //act1.BeginInvoke(null, null); // 第一个参数是在异步调用时需要进入到哪一个回调函数；第二个参数为输入参数（一般为null)
            //act2.BeginInvoke(null, null);
            //act3.BeginInvoke(null, null);

            // （3.2）使用thread实现异步调用
            //Thread th1 = new Thread(new ThreadStart(stu1.DoHomework));
            //Thread th2 = new Thread(new ThreadStart(stu2.DoHomework));
            //Thread th3 = new Thread(new ThreadStart(stu3.DoHomework));
            //th1.Start();
            //th2.Start();
            //th3.Start();

            // （3.3）使用task实现异步调用
            //Task t1 = new Task(new Action(stu1.DoHomework));
            //Task t2 = new Task(new Action(stu2.DoHomework));
            //Task t3 = new Task(new Action(stu3.DoHomework));
            //t1.Start();
            //t2.Start();
            //t3.Start();

            // 主线程模拟在做某些事情。
            for (var i = 0; i < 10; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Main thread {0}", i);
                Thread.Sleep(200);
            }
        }
    }
    class Student
    {
        public int ID;
        public ConsoleColor Color;

        public void DoHomework()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.ForegroundColor = Color;
                Console.WriteLine("{0}'s student do {2}'s homework use {1} ", ID, Color, i);
                Thread.Sleep(100);
            }
        }
    }
    */

    /*----------------------*/  /*5.利用接口替代委托*/   /*----------------------*/
    /*
    class Program
    {
        static void Main(string[] args)
        {
            IProductFactory pizzaFactory = new PizzaFactory();
            IProductFactory toyCarFactory = new ToyCarFactory();

            var wrapFactory = new WrapFactory();
            Box box1 = wrapFactory.WrapProduct(pizzaFactory);
            Box box2 = wrapFactory.WrapProduct(toyCarFactory);

            Console.WriteLine(box1.Product.Name);
            Console.WriteLine(box2.Product.Name);
        }
    }

    interface IProductFactory
    {
        Product Make();
    }

    class PizzaFactory : IProductFactory
    {
        public Product Make()
        {
            var product = new Product();
            product.Name = "Pizza";
            return product;
        }
    }

    class ToyCarFactory : IProductFactory
    {
        public Product Make()
        {
            var product = new Product();
            product.Name = "Toy Car";
            return product;
        }
    }

    class Product
    {
        public string Name { get; set; }
    }

    class Box
    {
        public Product Product { get; set; }
    }

    class WrapFactory
    {
        // 模板方法，提高复用性
        public Box WrapProduct(IProductFactory productFactory)
        {
            var box = new Box();
            Product product = productFactory.Make();
            box.Product = product;
            return box;
        }
    }
    */
}
