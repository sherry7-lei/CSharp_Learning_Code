using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*====================================================================================================*/
//                                              字段
// 字段类似C++中的成员变量，可以用（public/internal/protected/private）+ （static) + (readonly)修饰
// 字段由实例字段（修饰对象）和静态字段（修饰类）组成
// 实例字段在构造函数中赋值或者使用默认构造函数；静态字段在静态构造函数中赋值或直接在声明时赋值。
// 使用关键字readonly修饰成为只读字段

//                                              属性
// 属性是字段的包装器，通过属性向外暴露数据，字段则可以用protected/private保护
// 属性一般用 public + (static) + (readonly) 修饰
// 属性由实例属性（修饰对象）和静态属性（修饰类）组成
// 只有getter没有setter则成为只读属性
/*====================================================================================================*/

namespace CSharpLearn
{
    /*---------- 字段Field ----------*/
    /*
    public class Student
    {
        // 1.实例字段（修饰实例对象的字段）
        public int age;
        public double score;

        // 2.静态字段（修饰类的字段）
        public static double AverageAge;
        public static double AverageScore;

        // 3.只读字段只能在声明的时候进行初始化(实例构造函数)，后续只能读取字段，无法进行修改
        // （1）实例只读字段
        public readonly double id;
        // （2）静态只读字段
        public static readonly double ACount;

        // 4.实例字段和静态字段都可以在声明时赋值(静态构造函数)，或在 实例/静态 构造函数中进行赋值
        // （1）实例构造
        public Student()
        {
            age = 0;
            score = 0;
            id = 0;
        }
        // （2）静态构造
        static Student()
        {
            AverageAge = 0;
            AverageScore = 0;
            ACount = 0;
        }
    }
    */

    /*---------- 属性Property ----------*/
    /*
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // 属性
                var stu1 = new Student1();
                stu1.Age = 20;

                var stu2 = new Student1();
                stu2.Age = 20;

                var stu3 = new Student1();
                stu3.Age = 200;

                var avgAge = (stu1.Age + stu2.Age + stu3.Age) / 3;

                Console.WriteLine(avgAge);

                // 静态属性
                Student1.Amount = 100;
                Console.WriteLine(Student1.Amount);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public class Student1
    {
        // 字段
        private int age;
        // 属性
        public int Age
        {
            get
            {
                return Age;
            }
            set
            {
                if (value >= 0 && value <= 120)
                {
                    Age = value;
                }
                else
                {
                    throw new Exception("Age value has error.");
                }
            }
        }
        
        // 静态字段
        private static int amount;
        // 静态属性
        public static int Amount
        {
            get { return amount; }
            set
            {
                if (value >= 0)
                    Student1.amount = value;
                else
                    throw new Exception("value is error");
            }
        }
    }
    */

    // 只读属性表示属性只有getter，没有setter
    // 对于类使用静态只读属性，对于对象使用实例只读属性
}
