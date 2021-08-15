using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essential
{
    public class DynamicCls
    {
        dynamic dynamic;
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

        //动态类型可以返回匿名对象，不需要再定义一个类，减少代码编写。

        //在反射中要用到大量的类型判断和转换，dynamic可以避免这种性能的损失和书写上的麻烦。当然，如果不是这种应用场景还应该遵循强类型语言的一惯用户尽量不跳过编绎器检查有利于程序健状性。 
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
