using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*====================================================================================================*/
//                                          继承
// 基类中存在的字段/属性/方法，派生类可以全部继承
// （除带参构造函数，基类具有带参构造函数时，需要在派生类中显示实现构造函数，并在初始化列表中给基类构造赋值）

// 基类中private的字段，派生类会继承但是无法进行操作
// （如果基类提供了private字段的接口，派生类中可以通过调用接口来获取/修改）

// 派生类实例化对象：先调用基类构造 -> 派生类构造 -> 派生类析构 -> 基类析构
/*====================================================================================================*/

namespace CSharpLearn
{
    /*
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student(1, "sherry");
            student.Do1();
            student.Do2();
        }
    }
    
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private double _money;

        public Person(int id, string name)
        {
            Id = id;
            Name = name;
        }

        protected void Work()
        {
            _money += 100;
        }

        public double GetMoney()
        {
            return _money;
        }

        public void Do1()
        {
            Work();
            Console.WriteLine($"I'm a Person:{this.GetMoney()}");
        }
    }

    public class Student : Person
    {
        // 带参构造函数无法继承
        public Student(int id, string name)
            :base(id, name)
        {
        }

        public void Do2()
        {
            Work();
            Work();
            Console.WriteLine($"I'm a Student:{this.GetMoney()}");
        }
    }
    */
}
