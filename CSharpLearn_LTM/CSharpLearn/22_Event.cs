using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*====================================================================================================*/
//（1）事件声明的完整格式
// 从事件的五个组成部分入手，一步一步编写

//（2）事件声明的简要格式
// 直接使用public event EventHandler Order声明事件

//（3）委托能否替代事件
// 不能用委托替代事件，如果使用委托替代事件，容易导致某个对象在事件处理器中传入其他对象，造成给他人点菜的情况

//（4）事件的本质
// 事件的本质就是委托的包装器

//（5）命名约定
// 事件一般以***EventHandler命名，传入事件的对象为object sender，传入事件的参数为***EventArgs，并继承EventArgs，EventArgs e
/*====================================================================================================*/

namespace CSharpLearn
{
    /*---------------------*/ /*----3.事件的声明----*/ /*---------------------*/
    //（1）事件声明的完整格式
    /*
    class Program
    {
        static void Main(string[] args)
        {
            // 1. 事件的拥有者
            Customer customer = new Customer();
            // 3.事件的订阅者
            Waiter waiter = new Waiter();
            // 2. 事件参数  5. 事件订阅
            customer.Order += waiter.Action;

            // 触发事件
            customer.WaitCustomer();
            customer.Action();
            customer.PayTheBill();
        }
    }
    // 该类是事件参数 —— 用于传递点的菜单（一般用**EventArgs格式，且继承EventArgs）
    public class OrderEventArgs : EventArgs
    {
        public string DishName { get; set; }
        public string Size{ get; set; }
    }

    // 声明一个委托类型（类型无返回值，输入参数有两个） —— 用作事件处理器（一般用**EventHandler格式）
    public delegate void OrderEventHandler(object sender, EventArgs e);

    public class Customer
    {
        // 声明委托字段
        public OrderEventHandler orderEventHandler;

        // 声明事件
        public event OrderEventHandler Order
        {
            add { orderEventHandler += value; } 
            remove { orderEventHandler -= value; }
        }

        // 字段 —— 金额
        public double Bill{ get; set; }

        // 方法 —— 支付金额
        public void PayTheBill()
        {
            Console.WriteLine("Customer: I will pay bill ${0}", this.Bill);
        }

        // 方法 —— 顾客前置行为（可有可无）
        public void WaitCustomer()
        {
            Console.WriteLine("Customer walk into resturant!");
            for (int i = 0; i < 5; ++i)
            {
                Console.WriteLine("Customer: Let me Think...");
                Thread.Sleep(1000);
            }
        }

        // 方法 —— 触发器（事件五要素集齐，需要外部触发事件）
        public void Action()
        {
            if(this.orderEventHandler != null)
            {
                OrderEventArgs e = new OrderEventArgs();
                e.DishName = "Chicken";
                e.Size = "large";
                orderEventHandler.Invoke(this,e);
            }
        }
    }

    public class Waiter
    {
        // 4. 事件处理器
        internal void Action(object sender, EventArgs e)
        {
            Customer customer = sender as Customer;
            OrderEventArgs orderEventArgs = e as OrderEventArgs;
            Console.WriteLine("Waiter: I will service {0} for you！", orderEventArgs.DishName);
            double price = 10;
            switch (orderEventArgs.Size)
            {
                case "small":
                    price = price * 0.5;
                    break;
                case "large":
                    price = price * 1.5;
                    break;
                default:
                    break;
            }
            customer.Bill += price;
        }
    }
    */

    //（2）事件声明的简要格式
    /*
    class Program
    {
        static void Main(string[] args)
        {
            // 1.事件的拥有者
            Customer customer = new Customer();
            // 3.事件的订阅者
            Waiter waiter = new Waiter();
            // 2.事件参数   5.事件订阅
            customer.Order += waiter.Action;

            // 触发事件
            customer.WaitCustomer();
            customer.Action();
            customer.PayTheBill();
        }
    }
    // 该类是事件参数 —— 用于传递点的菜单（一般用**EventArgs格式，且继承EventArgs）
    public class OrderEventArgs : EventArgs
    {
        public string DishName { get; set; }
        public string Size { get; set; }
    }

    public class Customer
    {
        // 声明事件
        // public delegate void EventHandler(object sender, EventArgs e);
        public event EventHandler Order;

        // 字段 —— 金额
        public double Bill { get; set; }

        // 方法 —— 支付金额
        public void PayTheBill()
        {
            Console.WriteLine("Customer: I will pay bill ${0}", this.Bill);
        }

        // 方法 —— 顾客前置行为（可有可无）
        public void WaitCustomer()
        {
            Console.WriteLine("Customer walk into resturant!");
            for (int i = 0; i < 5; ++i)
            {
                Console.WriteLine("Customer: Let me Think...");
                Thread.Sleep(1000);
            }
        }

        // 方法 —— 触发器（事件五要素集齐，需要外部触发事件）
        public void Action()
        {
            if (this.Order != null)
            {
                OrderEventArgs e = new OrderEventArgs();
                e.DishName = "Chicken";
                e.Size = "large";
                this.Order.Invoke(this, e);
            }
        }
    }

    public class Waiter
    {
        // 4. 事件处理器
        internal void Action(object sender, EventArgs e)
        {
            Customer customer = sender as Customer;
            OrderEventArgs orderEventArgs = e as OrderEventArgs; 
            Console.WriteLine("Waiter: I will service {0} for you！", orderEventArgs.DishName);
            double price = 10;
            switch (orderEventArgs.Size)
            {
                case "small":
                    price = price * 0.5;
                    break;
                case "large":
                    price = price * 1.5;
                    break;
                default:
                    break;
            }
            customer.Bill += price;
        }
    }
    */

    //（3）委托能否替代事件
    /*
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();

            var customer = new Customer();
            var waiter = new Waiter();
            customer.Order += waiter.Action;
            //customer.Action();

            // badGuy 借刀杀人，给 customer 强制点菜
            OrderEventArgs e = new OrderEventArgs();
            e.DishName = "Manhanquanxi";
            e.Size = "large";

            OrderEventArgs e2 = new OrderEventArgs();
            e2.DishName = "Beer";
            e2.Size = "large";

            var badGuy = new Customer();
            badGuy.Order += waiter.Action;
            badGuy.Order.Invoke(customer, e);
            badGuy.Order.Invoke(customer, e2);

            customer.PayTheBill();
        }
    }

    public class OrderEventArgs : EventArgs
    {
        public string DishName { get; set; }

        public string Size { get; set; }
    }

    public delegate void OrderEventHandler(Customer customer, OrderEventArgs e);

    public class Customer
    {
        // 去掉 Event，把事件声明改成委托字段声明
        public OrderEventHandler Order;

        public double Bill { get; set; }

        public void PayTheBill()
        {
            Console.WriteLine("I will pay ${0}.", this.Bill);
        }

        public void WalkIn()
        {
            Console.WriteLine("Walk into the restaurant");
        }

        public void SitDown()
        {
            Console.WriteLine("Sit down.");
        }

        public void Think()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Let me think ...");
                Thread.Sleep(1000);
            }

            if (this.Order != null)
            {
                var e = new OrderEventArgs();
                e.DishName = "Kongpao Chicken";
                e.Size = "large";

                this.Order.Invoke(this, e);
            }
        }

        public void Action()
        {
            Console.ReadLine();
            this.WalkIn();
            this.SitDown();
            this.Think();
        }
    }

    public class Waiter
    {
        public void Action(Customer customer, OrderEventArgs e)
        {
            Console.WriteLine("I will serve you the dish - {0}.", e.DishName);

            double price = 10;
            switch (e.Size)
            {
                case "small":
                    price *= 0.5;
                    break;
                case "large":
                    price *= 1.5;
                    break;
                default:
                    break;
            }
            customer.Bill += price;
        }
    }
    */

    //（4）事件的本质
    // 事件本质是一个包装器 —— 包装着委托，对委托字段的访问进行限制

    //（5）命名约定
    /*
    class Program
    {
        static void Main(string[] args)
        {
            // 1. 事件的拥有者
            Customer customer = new Customer();
            // 3.事件的订阅者
            Waiter waiter = new Waiter();
            // 2. 事件参数  5. 事件订阅
            customer.Order += waiter.Action;

            // 触发事件
            customer.Action();
            customer.PayTheBill();
        }
    }
    // 该类是事件参数 —— 用于传递点的菜单（一般用**EventArgs格式，且继承EventArgs）
    public class OrderEventArgs : EventArgs
    {
        public string DishName { get; set; }
        public string Size { get; set; }
    }

    // 声明一个委托类型（类型无返回值，输入参数有两个） —— 用作事件处理器（一般用**EventHandler格式）
    public delegate void OrderEventHandler(object sender, EventArgs e);

    public class Customer
    {
        // 声明委托字段
        public OrderEventHandler orderEventHandler;

        // 声明事件
        public event OrderEventHandler Order
        {
            add { orderEventHandler += value; }
            remove { orderEventHandler -= value; }
        }

        // 字段 —— 金额
        public double Bill { get; set; }

        // 方法 —— 支付金额
        public void PayTheBill()
        {
            Console.WriteLine("Customer: I will pay bill ${0} for you", this.Bill);
        }

        // 方法 —— 顾客前置行为（可有可无）
        public void Action()
        {
            Console.WriteLine("Customer walk into resturant!");
            for (int i = 0; i < 5; ++i)
            {
                Console.WriteLine("Customer: Let me Think...");
                Thread.Sleep(1000);
            }
            this.OnOrder("Kongpao Chicken", "large");
        }

        // 方法 —— 触发器（事件五要素集齐，需要外部触发事件）
        // 设置为protected，只允许自己的对象和派生类可以调用，防止外部接口调用
        protected void OnOrder(string dishName, string size)
        {
            if (this.orderEventHandler != null)
            {
                OrderEventArgs e = new OrderEventArgs();
                e.DishName = dishName;
                e.Size = size;
                orderEventHandler.Invoke(this, e);
            }
        }
    }
    public class Waiter
    {
        // 4. 事件处理器
        internal void Action(object sender, EventArgs e)
        {
            Customer customer = sender as Customer;
            OrderEventArgs orderEventArgs = e as OrderEventArgs;
            Console.WriteLine("Waiter: I will service {0} for you！", orderEventArgs.DishName);
            double price = 10;
            switch (orderEventArgs.Size)
            {
                case "small":
                    price = price * 0.5;
                    break;
                case "large":
                    price = price * 1.5;
                    break;
                default:
                    break;
            }
            customer.Bill += price;
        }
    }
    */

    /*---------------------*/ /*----4.事件与委托的关系----*/ /*---------------------*/
    /* 
    ● 为什么要使用委托类型来声明事件？
        ○ 站在 source 的角度来看，是为了表明 source 能对外传递哪些消息
        ○ 站在 subscriber 的角度来看，它是一种约定，是为了约束能够使用什么样签名的方法来处理（响应）事件
        ○ 委托类型的实例将用于存储（引用）事件处理器
    ● 对比事件与属性
        ○ 属性不是字段 —— 很多时候属性是字段的包装器，这个包装器用来保护字段不被滥用
        ○ 事件不是委托字段 —— 它是委托字段的包装器，这个包装器用来保护委托字段不被滥用
    总结：事件不是委托类型字段（无论看起来多像），它是委托类型字段的包装器，限制器，从外界只能访问 += -= 操作。
    */
}
