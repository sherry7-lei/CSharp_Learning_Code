using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearn
{
    internal class _27_Abstract_Interface
    {
        /*
        static void Main(string[] args)
        {
            Vehicle v1 = new Car();
            v1.Run();
            Vehicle v2 = new Truck();
            v2.Run();
            Vehicle v3 = new RaceCar();
            v3.Run();
        }
        */
    }

    /*---------------------*/ /*----抽象类与开闭原则----*/ /*---------------------*/
    /*------ （1）创建Car和Truck类并声明成员方法，两个类中的Stop方法重复，违反了SOLID设计原则，对其进行修改。------*/
    // 
    /*
    class Car
    {
        public void Run()
        {
            Console.WriteLine("Car is running ...");
        }

        public void Stop()
        {
            Console.WriteLine("Stopped!");
        }
    }
    class Truck
    {
        public void Run()
        {
            Console.WriteLine("Truck is running ...");
        }

        public void Stop()
        {
            Console.WriteLine("Stopped!");
        }
    }
    */

    /*------ 
            （2）将Car和Truck中重复的成员方法放到基类中，通过继承来解决问题
                 但此时任存在问题 —— 无法通过Vehicle基类调用Run方法，通过多态来解决
    ------*/
    /*
    class Vehicle
    {
        public void Stop()
        {
            Console.WriteLine("Stopped!");
        }
    }
    class Car : Vehicle
    {
        public void Run()
        {
            Console.WriteLine("Car is running ...");
        }
    }
    class Truck : Vehicle
    {
        public void Run()
        {
            Console.WriteLine("Truck is running ...");
        }
    }
    */

    /*------ 
            （3）Vehicle作为基类，其中的Run方法中存在逻辑，提高了测试负担
                 因此通过删除Run方法的函数体，将其作为抽象类（纯虚方法）解决问题
    ------*/
    /*
    class Vehicle
    {
        public void Stop()
        {
            Console.WriteLine("Stopped!");
        }

        public virtual void Run()
        {
            Console.WriteLine("Vehicle is running ...");
        }
    }
    class Car : Vehicle
    {
        public override void Run()
        {
            Console.WriteLine("Car is running ...");
        }
    }
    class Truck : Vehicle
    {
        public override void Run()
        {
            Console.WriteLine("Truck is running ...");
        }
    }
    */

    /*------ （4）Vehicle成为抽象类之后，添加新的派生类更为简易，有了抽象类，就有纯抽象类 ------*/
    /*
    abstract class Vehicle
    {
        public void Stop()
        {
            Console.WriteLine("Stopped!");
        }

        public abstract void Run();
    }
    class Car : Vehicle
    {
        public override void Run()
        {
            Console.WriteLine("Car is running ...");
        }
    }
    class Truck : Vehicle
    {
        public override void Run()
        {
            Console.WriteLine("Truck is running ...");
        }
    }
    class RaceCar : Vehicle
    {
        public override void Run()
        {
            Console.WriteLine("Race car is running...");
        }
    }
    */

    /*------ （5）纯抽象类VehicleBase ------*/
    /*
    abstract class VehicleBase
    {
        public abstract void Stop();
        public abstract void Fill();
        public abstract void Run();
    }
    // Vehicle类用abstract修饰的原因是：继承的Run方法并没有重写
    // 而一个类一旦有了abstract对象，那么这个类就是抽象类，必须用abstract修饰
    abstract class Vehicle : VehicleBase
    {
        public override void Stop()
        {
            Console.WriteLine("Stopped!");
        }

        public override void Fill()
        {
            Console.WriteLine("Pay and fill...");
        }
    }
    class Car : Vehicle
    {
        public override void Run()
        {
            Console.WriteLine("Car is running ...");
        }
    }
    class Truck : Vehicle
    {
        public override void Run()
        {
            Console.WriteLine("Truck is running ...");
        }
    }
    class RaceCar : Vehicle
    {
        public override void Run()
        {
            Console.WriteLine("Race car is running...");
        }
    }
    */

    /*------ （6）纯抽象类是C++中使用的，在C#中用接口来代替 ------*/
    /*
    interface IVehicle
    {
        void Stop();
        void Fill();
        void Run();
    }
    abstract class Vehicle : IVehicle
    {
        public void Stop()
        {
            Console.WriteLine("Stopped!");
        }

        public void Fill()
        {
            Console.WriteLine("Pay and fill...");
        }

        // Run方法未实现，依然是抽象方法
        public abstract void Run();
    }
    class Car : Vehicle
    {
        public override void Run()
        {
            Console.WriteLine("Car is running ...");
        }
    }
    class Truck : Vehicle
    {
        public override void Run()
        {
            Console.WriteLine("Truck is running ...");
        }
    }
    class RaceCar : Vehicle
    {
        public override void Run()
        {
            Console.WriteLine("Race car is running...");
        }
    }
    */
}
