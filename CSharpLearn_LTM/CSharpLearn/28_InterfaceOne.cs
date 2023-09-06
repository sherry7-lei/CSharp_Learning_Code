using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearn
{
    /*---------------------------- 1.接口 ----------------------------*/
    /*------------------ （1）接口契约实例 ------------------*/
    // 常规用法
    /*
    internal class _28_InterfaceOne
    {
        static void Main(string[] args)
        {
            int[] nums1 = new int[] { 1, 2, 3, 4, 5 };
            ArrayList nums2 = new ArrayList { 1, 2, 3, 4, 5 };

            Console.WriteLine(Sub(nums1));
            Console.WriteLine(Avg(nums1));

            Console.WriteLine(Sub(nums2));
            Console.WriteLine(Avg(nums2));
        }

        static int Sub(int[] nums)
        {
            int sum = 0;
            foreach(var n in nums)
            {
                sum += n;
            }
            return sum;
        }

        static double Avg(int[] nums)
        {
            int sum = 0;
            int count = 0;
            foreach (var n in nums)
            {
                sum += n;
                count++;
            }
            return (double)(sum / count);
        }

        static int Sub(ArrayList nums)
        {
            int sum = 0;
            foreach (var n in nums)
            {
                sum += (int)n;
            }
            return sum;
        }

        static double Avg(ArrayList nums)
        {
            int sum = 0;
            int count = 0;
            foreach (var n in nums)
            {
                sum += (int)n;
                count++;
            }
            return (double)(sum / count);
        }
    }
    */

    // 接口 
    // 数组的基类是Array, Array和ArrayList都继承了IEnumerable接口，
    // 通过Array与ArrayList对象传给基类IEnumerable，实现Sub函数和Avg函数的复用
    /*
    internal class _28_InterfaceOne
    {
        static void Main(string[] args)
        {
            int[] nums1 = new int[] { 1, 2, 3, 4, 5 };
            ArrayList nums2 = new ArrayList { 1, 2, 3, 4, 5 };

            Console.WriteLine(Sub(nums1));
            Console.WriteLine(Avg(nums1));

            Console.WriteLine(Sub(nums2));
            Console.WriteLine(Avg(nums2));
        }
        static int Sub(IEnumerable nums)
        {
            int sum = 0;
            foreach (var n in nums)
            {
                sum += (int)n;
            }
            return sum;
        }
        static double Avg(IEnumerable nums)
        {
            int sum = 0;
            int count = 0;
            foreach (var n in nums)
            {
                sum += (int)n;
                count++;
            }
            return (double)(sum / count);
        }
    }
    */

    /*------------------ （2）依赖与耦合 ------------------*/
    /*
    internal class Pargram
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            Car car = new Car(engine);
            car.Run(3);
            Console.WriteLine(car.Speed);
        }
    }

    class Engine
    {
        public int Rpm { get; private set; }

        public void Work(int gas)
        {
            this.Rpm = gas * 1000;
        }
    }

    class Car
    {
        private Engine _engine;
        public int Speed { get; private set; }
        public Car(Engine engine)
        {
            this._engine = engine;
        }
        public void Run(int gas)
        {
            this._engine.Work(gas);
            this.Speed =  this._engine.Rpm / 100;
        }
    }
    */

    /*------------------ （3）接口与解耦 ------------------*/
    // 解耦之前：Car类有属性Engine类，如果Engine类逻辑出现问题，Car类也会出现问题
    // 解耦之后：如果Engine类出现问题，只需要换一个Engine又可以继续使用
    /*
    internal class Pargram
    {
        static void Main(string[] args)
        {
            Car car1 = new Car(new Car_Engine());
            car1.Run(3);
            Console.WriteLine(car1.Speed);

            Car car2 = new Car(new RaceCar_Engine());
            car2.Run(3);
            Console.WriteLine(car2.Speed);
        }
    }
    interface Engine
    {
        void Work(int gas, out int rpm);
    }

    public class Car_Engine : Engine
    {
        public void Work(int gas, out int rpm)
        {
            rpm = gas * 1000;
        }
    }

    public class RaceCar_Engine : Engine
    {
        public void Work(int gas, out int rpm)
        {
            rpm = gas * 3000;
        }
    }

    class Car
    {
        private Engine _engine;
        public int Speed { get; private set; }
        public Car(Engine engine)
        {
            this._engine = engine;
        }
        public void Run(int gas)
        {
            int rpm = 0;
            this._engine.Work(gas, out rpm);
            this.Speed = rpm / 100;
        }
    }
    */

    /*---------------------------- 2.依赖反转原则 ----------------------------*/


    /*---------------------------- 3.单元测试 ----------------------------*/
    /*------------------ （1）紧耦合 ------------------*/
    /*
    class Program
    {
        static void Main(string[] args)
        {
            var fan = new DeskFan(new PowerSupply());
            Console.WriteLine(fan.Work());
        }
    }

    // 背景：电扇有个电源，电源输出电流越大电扇转得越快
    // 电源输出有报警上限
    class PowerSupply
    {
        public int GetPower()
        {
            //return 100;
            return 210;
        }
    }
    class DeskFan
    {
        private PowerSupply _powerSupply;

        public DeskFan(PowerSupply powerSupply)
        {
            _powerSupply = powerSupply;
        }

        public string Work()
        {
            int power = _powerSupply.GetPower();
            if (power <= 0)
            {
                return "Won't work.";
            }
            else if (power < 100)
            {
                return "Slow";
            }
            else if (power < 200)
            {
                return "Work fine";
            }
            else
            {
                return "Warning";
            }
        }
    }
    */

    /*------------------ （2）解耦 ------------------*/
    /*
    public class Program
    {
        static void Main(string[] args)
        {
            DeskFan deskFan1 = new DeskFan(new PowerSupplyOK());
            Console.WriteLine(deskFan1.Work());

            DeskFan deskFan2 = new DeskFan(new PowerSupplyOFF());
            Console.WriteLine(deskFan2.Work());
        }
    }

    public interface IPowerSupply
    {
        int GetPower();
    }

    public class PowerSupplyOK : IPowerSupply
    {
        public int GetPower()
        {
            return 100;
        }
    }

    public class PowerSupplyOFF : IPowerSupply
    {
        public int GetPower()
        {
            return 0;
        }
    }

    public class DeskFan
    {
        private IPowerSupply _powerSupply;

        public DeskFan(IPowerSupply powerSupply)
        {
            _powerSupply = powerSupply;
        }

        public string Work()
        {
            int power = _powerSupply.GetPower();
            if (power <= 0)
            {
                return "Won't work.";
            }
            else if (power < 100)
            {
                return "Slow";
            }
            else if (power < 200)
            {
                return "Work fine";
            }
            else
            {
                return "Warning";
            }
        }
    }
    */

    /*------------------ （3）测试 ------------------*/
    // 见CSharpLearn.Test
}
