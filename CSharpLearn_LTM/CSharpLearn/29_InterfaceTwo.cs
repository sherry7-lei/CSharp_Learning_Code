using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;

namespace CSharpLearn
{
    /*---------------------------- 1.接口隔离 ----------------------------*/
    /*------------------ （1）胖接口及其产生原因 ------------------*/
    // 1）设计失误

    // 原本设计
    /*
    internal class _29_InterfaceTwo
    {
        static void Main(string[] args)
        {
            Driver driver = new Driver(new Truck());
            driver.Drive();

            // 如果driver想要开坦克，必须在Driver类中，将IVehicle改为ITank;
            // 修改后出现胖接口问题：driver只想Run，并不会Fire，因此接口设计出现问题
            // 需要将Fire和Run两种接口分隔到两种接口中：修改如line_104
        }
    }

    class Driver
    {
        private IVehicle _vehicle;
        public Driver(IVehicle vehicle)
        {
            this._vehicle = vehicle;
        }

        public void Drive()
        {
            this._vehicle.Run();
        }
    }

    interface IVehicle
    {
        void Run();
    }
    class Car : IVehicle
    {
        public void Run()
        {
            Console.WriteLine("Car is running!");
        }
    }
    class Truck : IVehicle
    {
        public void Run()
        {
            Console.WriteLine("Truck is running!");
        }
    }

    interface ITank 
    {
        void Fire();
        void Run();
    }
    class LightTank : ITank
    {
        public void Fire()
        {
            Console.WriteLine("Boom!");
        }

        public void Run()
        {
            Console.WriteLine("Ka ...");
        }
    }
    class MediumTank : ITank
    {
        public void Fire()
        {
            Console.WriteLine("Boom!!");
        }

        public void Run()
        {
            Console.WriteLine("Ka ka ...");
        }
    }
    class HeavyTank : ITank
    {
        public void Fire()
        {
            Console.WriteLine("Boom!!!");
        }

        public void Run()
        {
            Console.WriteLine("Ka ka ka ...");
        }
    }
    */

    // 修改后设计
    /*
    internal class _29_InterfaceTwo
    {
        static void Main(string[] args)
        {
            Driver driver = new Driver(new Truck());
            driver.Drive();

            driver = new Driver(new LightTank());
            driver.Drive();
        }
    }

    class Driver
    {
        private IVehicle _vehicle;
        public Driver(IVehicle vehicle)
        {
            this._vehicle = vehicle;
        }

        public void Drive()
        {
            this._vehicle.Run();
        }
    }

    interface IVehicle
    {
        void Run();
    }
    class Car : IVehicle
    {
        public void Run()
        {
            Console.WriteLine("Car is running!");
        }
    }
    class Truck : IVehicle
    {
        public void Run()
        {
            Console.WriteLine("Truck is running!");
        }
    }

    interface IWeapon
    {
        void Fire();
    }

    interface ITank : IVehicle, IWeapon
    {
    }

    class LightTank : ITank
    {
        public void Fire()
        {
            Console.WriteLine("Boom!");
        }

        public void Run()
        {
            Console.WriteLine("Ka ...");
        }
    }

    class MediumTank : ITank
    {
        public void Fire()
        {
            Console.WriteLine("Boom!!");
        }

        public void Run()
        {
            Console.WriteLine("Ka ka ...");
        }
    }

    class HeavyTank : ITank
    {
        public void Fire()
        {
            Console.WriteLine("Boom!!!");
        }

        public void Run()
        {
            Console.WriteLine("Ka ka ka ...");
        }
    }
    */

    // 2）传了个大接口
    /*
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums1 = { 1, 2, 3, 4, 5 };
            ArrayList nums2 = new ArrayList { 1, 2, 3, 4, 5 };

            Console.WriteLine(Sum(nums1));
            Console.WriteLine(Sum(nums2));

            // 可以迭代
            var num3 = new ReadOnlyCollection(nums1);
            foreach (var n in num3)
            {
                Console.WriteLine(n);
            }

            Console.WriteLine(Sum(num3));
        }

        // 调用者绝不多要
        // static int Sum(ICollection nums)
        static int Sum(IEnumerable nums)
        {
            int sums = 0;
            foreach (var n in nums)
            {
                sums += (int)n;
            }
            return sums;
        }
    }

    class ReadOnlyCollection : IEnumerable
    {
        private int[] _array;

        public ReadOnlyCollection(int[] array)
        {
            _array = array;
        }

        public IEnumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        // 为了避免污染整个名称空间，所以用了成员类
        public class Enumerator : IEnumerator
        {
            private ReadOnlyCollection _collection;

            private int _head;

            public Enumerator(ReadOnlyCollection collection)
            {
                _collection = collection;
                _head = -1;
            }

            public object Current
            {
                get
                {
                    // 因为 Enumerator 就在 ReadOnlyCollection 内部
                    // 所以能访问 private 的 _array 成员
                    object o = _collection._array[_head];
                    return o;
                }
            }

            public bool MoveNext()
            {
                return ++_head < _collection._array.Length;
            }

            public void Reset()
            {
                _head = -1;
            }
        }
    }
    */

    /*------------------ （2）显示接口实现 ------------------*/
    // 1）正常调用
    /*
    class Program
    {
        static void Main(string[] args)
        {
            var wk = new WarmKiller();
            wk.Love();
            wk.Kill();
        }
    }

    interface IGentleman
    {
        void Love();
    }

    interface IKiller
    {
        void Kill();
    }

    class WarmKiller : IGentleman, IKiller
    {
        public void Love()
        {
            Console.WriteLine("I will love you forever ...");
        }

        public void Kill()
        {
            Console.WriteLine("Let me kill the enemy ...");
        }
    }
    */

    // 2）显示接口
    // C#能把隔离出来的接口隐藏起来，直到你显式的使用这种接口类型的变量去引用实现了该接口的实例，
    // 该接口内的方法才能被你看见被你使用。
    /*
    class Program
    {
        static void Main(string[] args)
        {
            // 使用IKiller接口类型的变量引用WarmKiller的实例，显示调用接口内的方法
            IKiller killer = new WarmKiller();
            killer.Kill();

            // 调用其他的方法
            var wk = killer as WarmKiller;
            wk.Love();
        }
    }

    interface IGentleman
    {
        void Love();
    }

    interface IKiller
    {
        void Kill();
    }

    class WarmKiller : IGentleman, IKiller
    {
        public void Love()
        {
            Console.WriteLine("I will love you forever ...");
        }

        // 处理
        void IKiller.Kill()
        {
            Console.WriteLine("Let me kill the enemy ...");
        }
    }
    */

    /*---------------------------- 2.反射 ----------------------------*/
    /*------------------ （1）依赖注入 ------------------*/
    /*
    internal class _29_InterfaceTwo
    {
        static void Main(string[] args)
        {
            // ITank、HeavyTank 这些都算静态类型
            ITank tank = new HeavyTank();

            // ======华丽的分割线======
            // 分割线以下不再使用静态类型
            var t = tank.GetType();
            object o = Activator.CreateInstance(t);
            MethodInfo fireMi = t.GetMethod("Fire");
            MethodInfo runMi = t.GetMethod("Run");
            fireMi.Invoke(o, null);
            runMi.Invoke(o, null);
        }
    }

    class Driver
    {
        private IVehicle _vehicle;
        public Driver(IVehicle vehicle)
        {
            this._vehicle = vehicle;
        }

        public void Drive()
        {
            this._vehicle.Run();
        }
    }

    interface IVehicle
    {
        void Run();
    }
    class Car : IVehicle
    {
        public void Run()
        {
            Console.WriteLine("Car is running!");
        }
    }
    class Truck : IVehicle
    {
        public void Run()
        {
            Console.WriteLine("Truck is running!");
        }
    }

    interface IWeapon
    {
        void Fire();
    }

    interface ITank : IVehicle, IWeapon
    {
    }

    class LightTank : ITank
    {
        public void Fire()
        {
            Console.WriteLine("Boom!");
        }

        public void Run()
        {
            Console.WriteLine("Ka ...");
        }
    }

    class MediumTank : ITank
    {
        public void Fire()
        {
            Console.WriteLine("Boom!!");
        }

        public void Run()
        {
            Console.WriteLine("Ka ka ...");
        }
    }

    class HeavyTank : ITank
    {
        public void Fire()
        {
            Console.WriteLine("Boom!!!");
        }

        public void Run()
        {
            Console.WriteLine("Ka ka ka ...");
        }
    }
    */

    /*------------------ （2）依赖注入框架 ------------------*/
}
