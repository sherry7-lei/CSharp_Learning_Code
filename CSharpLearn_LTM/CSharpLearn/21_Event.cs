using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows.Forms;

/*====================================================================================================*/
//                                             事件
// 事件分为五部分：事件拥有者 + 事件参数 + 事件响应者 + 事件处理器 + 订阅
// 事件订阅方式：
// 1）！事件拥有者和事件响应者在两个完全不同的对象中（一个类有事件，另一个类中有这个类字段）
// 2）！！事件拥有者和事件响应者在同一的对象中（自定义Form，在自定义类类型中实现事件处理器）
// 3）！！！事件拥有者是事件响应者的字段（事件响应者的类类型中的字段拥有事件）

/*====================================================================================================*/

namespace CSharpLearn
{
    /*---------------------*/ /*----1.事件的概念----*/ /*---------------------*/
    // 事件分为五个部分
    // （1）事件的拥有者
    // （2）事件参数
    // （3）事件的订阅者
    // （4）事件处理器（回调函数）
    // （5）事件订阅关系

    /*---------------------*/ /*----2.事件的应用----*/ /*---------------------*/
    // （1）事件示例 —— （！一个事件参数 可以通知 多个事件处理器！）
    /*
    class Program
    {
        static void Main(string[] args)
        {
            // 事件的拥有者 timer
            var timer = new Timer();
            timer.Interval = 1000;
            // 事件参数Elapsed  /  订阅关系  / 事件的订阅者 boy/girl的匿名对象
            timer.Elapsed += new Boy().Evented;
            timer.Elapsed += new Girl().Evented;
            timer.Start();

            Console.ReadLine();
        }
    }

    class Boy
    {
        // 事件处理器
        internal void Evented(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Boy Event handle");
        }
    }

    class Girl
    {
        // 事件处理器
        internal void Evented(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Girl Event handle");
        }
    }
    */

    //（2）事件订阅方式
    // （2.1）事件拥有者和事件响应者在两个完全不同的对象
    /*
    class Program
    {
        static void Main(string[] args)
        {
            // 1.事件的拥有者form
            Form form = new Form();

            // 3.事件的响应者controller
            Controller controller = new Controller(form);
            form.ShowDialog(); 
        }
    }

    class Controller
    {
        private Form form;
        public Controller(Form form)
        {
            this.form = form;
            // 2. 事件参数Click   5.事件订阅+=
            this.form.Click += this.FormClicked;
        }

        // 4. 事件处理器FormClicked
        private void FormClicked(object sender, EventArgs e)
        {
            this.form.Text = DateTime.Now.ToString();
        }
    }
    */

    // （2.2）事件拥有者和事件响应者在同一个对象
    /*
    class Program
    {
        static void Main(string[] args)
        {
            // 1.事件的拥有者myForm  3.事件的响应者myForm
            myForm myform = new myForm();
            // 2.事件参数Click  5.事件订阅+=
            myform.Click += myform.FormClicked;
            myform.ShowDialog();
        }
    }
    class myForm : Form
    {
        // 4.事件处理器FormClicked
        internal void FormClicked(object sender, EventArgs e)
        {
            this.Text = DateTime.Now.ToString();
        }
    }
    */

    // （2.3）事件拥有者是事件响应者所在对象的一个字段
    // 通过button1 和 button2 可知 ——（！多个事件参数同时通知一个事件处理器！）
    /*
    class Program
    {
        static void Main(string[] args)
        {
            // 3.事件响应者
            myForm myform  = new myForm();
            myform.ShowDialog();
        }
    }
    class myForm : Form
    {
        private TextBox textbox;
        // 1.事件拥有者
        private Button button1;
        private Button button2;
        private Button button3;
        public myForm()
        {
            this.textbox = new TextBox();
            this.button1 = new Button() { Text = "button1"};
            this.button2 = new Button() { Text = "button2" };
            this.button3 = new Button() { Text = "button3" };
            // 将部件添加到Form界面
            this.Controls.Add(textbox);
            this.Controls.Add(button1);
            this.Controls.Add(button2);
            this.Controls.Add(button3);

            this.button1.Top = 50;
            this.button2.Top = 100;
            this.button3.Top = 150;
            // 2.事件参数Click   5.事件订阅+=
            this.button1.Click += this.ButtonClicked;
            this.button2.Click += this.ButtonClicked;
            // 事件订阅方式
            // (1) 常规用法
            //this.button3.Click += this.ButtonClick2ed;

            // (2) 
            //this.button3.Click += new EventHandler(this.ButtonClick2ed);

            // (3) Lambda表达式
            //this.button3.Click += (Object sender, EventArgs e) => {
            //    this.textbox.Text = "clear!";
            //};

            //（4）委托的方式 （已废弃）
            this.button3.Click += delegate (object sender, EventArgs e) { 
                this.textbox.Text = "clear!";
            };
        }

        private void ButtonClick2ed(object sender, EventArgs e)
        {
            this.textbox.Text = "clear!";
        }

        // 4.事件处理器
        private void ButtonClicked(object sender, EventArgs e)
        {
            this.textbox.Text = DateTime.Now.ToString();
        }
    }
    */
}
