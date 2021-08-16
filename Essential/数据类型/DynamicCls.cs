using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Essential
{
    public class DynamicCls
    {
        dynamic dynamic;
        /// <summary>
        /// 编译器在编译的时候不再对类型进行检查，编译期默认dynamic对象支持你想要的任何特性
        /// </summary>
        public void T1()
        {
            var p1 = new DynamicCls_Person();
            //p1.GetFullName("", "");//提示报错。没有该方法

            dynamic = p1;
            try
            {
                dynamic.GetFullName("", "");//编译正常，运行报错
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }

        }

        /// <summary>
        /// 动态类型可以返回匿名对象，不需要再定义一个类，减少代码编写。
        /// </summary>
        /// <returns></returns>
        public string T2()
        {
            var xxx = new { Foo = "Foo", Bar = "Bar" };
            System.Diagnostics.Debug.WriteLine(xxx.Foo);
            //xxx.Foo = "";//匿名类型限制属性为只读，提示报错

            dynamic = new { Foo = "Foo", Bar = "Bar"};
            //dynamic.Foo = "FooFoo";//匿名类型限制属性为只读，运行报错

            return $"{dynamic.Foo} {dynamic.Bar}";
        }


        //在反射中要用到大量的类型判断和转换，dynamic可以避免这种性能的损失和书写上的麻烦。
        //当然，如果不是这种应用场景还应该遵循强类型语言的一惯用户尽量不跳过编绎器检查有利于程序健状性。

        private static readonly string DllName = "Essential";
        private static readonly string ClassName = "Essential.TupleCls";
        /// <summary>
        /// 放射类型转换耗时
        /// </summary>
        /// <returns></returns>
        public void T3()
        {
            for (int i = 0; i < 100000; i++)
            {
                Assembly assembly = Assembly.Load(DllName);
                Type type = assembly.GetType(ClassName);
                Object oObject = Activator.CreateInstance(type);
                ((TupleCls)oObject).T1();
            }
        }
        /// <summary>
        /// dynamic结合放射耗时
        /// </summary>
        public void T4()
        {
            for (int i = 0; i < 100000; i++)
            {
                Assembly assembly = Assembly.Load(DllName);
                Type type = assembly.GetType(ClassName);
                dynamic oObject = Activator.CreateInstance(type);
                oObject.T1();
            }
        }

    }

    class DynamicCls_Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
