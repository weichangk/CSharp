using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essential
{
    public class TupleCls
    {
        #region 元组的基本声明和使用
        /// <summary>
        /// 将元组赋给单独声明的变量
        /// </summary>
        public string T1()
        {
            (string country, string capital, double gdp) = ("China", "BeiJing", 111);
            return $"{country} {capital} gdp {gdp}";
        }

        /// <summary>
        /// 将元组赋给预声明的变量
        /// </summary>
        public string T2()
        {
            string country;
            string capital;
            double gdp;
            (country, capital, gdp) = ("China", "BeiJing", 222);
            return $"{country} {capital} gdp {gdp}";
        }

        /// <summary>
        /// 将元组赋给单独声明和隐式类型的变量
        /// </summary>
        public string T3()
        {
            (var country, var capital, var gdp) = ("China", "BeiJing", 333);
            return $"{country} {capital} gdp {gdp}";
        }

        /// <summary>
        /// 将元组赋给单独声明和隐式类型的变量，只用一个var
        /// </summary>
        public string T4()
        {
            var (country, capital, gdp) = ("China", "BeiJing", 444);
            return $"{country} {capital} gdp {gdp}";
        }

        /// <summary>
        /// 声明具名元组，按元组名称访问元组项
        /// </summary>
        public string T5()
        {
            (string country, string capital, double gdp) zhongguo = ("China", "BeiJing", 555);
            return $"{zhongguo.country} {zhongguo.capital} gdp {zhongguo.gdp}";
        }

        /// <summary>
        /// 声明包含具名元组项的元组，按元组名称访问元组项
        /// </summary>
        public string T6()
        {
            var zhongguo = (country: "China", capital: "BeiJing", gdp: 666);
            return $"{zhongguo.country} {zhongguo.capital} gdp {zhongguo.gdp}";
        }

        /// <summary>
        /// 将元组项未具名的元组赋给隐式类型的变量，通过项编号属性访问单独的元素
        /// </summary>
        public string T7()
        {
            var zhongguo = ("China", "BeiJing", 777);
            return $"{zhongguo.Item1} {zhongguo.Item2} gdp {zhongguo.Item3}";
        }

        /// <summary>
        /// 赋值时用下划线丢弃元组的一部分(弃元)
        /// </summary>
        public string T8()
        {
            var (_, capital, gdp) = ("China", "BeiJing", 888);
            return $"{capital} gdp {gdp}";
        }

        /// <summary>
        /// 通过变量和属性名推断元组项名称
        /// </summary>
        public string T9()
        {
            string country = "China";
            string capital = "BeiJing";
            double gdp = 999;
            var zhongguo = (country, capital, gdp);
            return $"{zhongguo.country} {zhongguo.capital} gdp {zhongguo.gdp}";
        }
        #endregion

        #region 使用Tuple方法创建元组
        /// <summary>
        /// new Tuple创建元组
        /// </summary>
        public string T10()
        {
            //(int a1, int a2) tt = new Tuple<int, int>(1, 2); //不能创建具名项元组

            var t = new Tuple<string, string, double>("China", "BeiJing", 101010);
            //t.Item3 += 10;只读。。。
            return $"{t.Item1} {t.Item2} gdp {t.Item3}";
        }

        /// <summary>
        /// Tuple.Create创建元组
        /// </summary>
        public string T11()
        {
            //(int a1, int a2) tt = Tuple.Create<int, int>(1, 2); //不能创建具名项元组

            var t = Tuple.Create<string, string, double>("China", "BeiJing", 111111);
            //t.Item3 += 10;只读。。。
            return $"{t.Item1} {t.Item2} gdp {t.Item3}";
        }

        /// <summary>
        /// Tuple.Create创建嵌套元组
        /// </summary>
        public string T12()
        {
            var t = Tuple.Create<int, int, int, int, int, int, int, Tuple<string, string, double>> (1, 2, 3, 4, 5, 6, 7, Tuple.Create<string, string, double>("China", "BeiJing", 121212));
            return $"{t.Rest.Item1.Item1} {t.Rest.Item1.Item2} gdp {t.Rest.Item1.Item3}";
        }

        #endregion

        #region 使用ValueTuple方法创建元组

        /// <summary>
        /// new ValueTuple创建元组
        /// </summary>
        public string T13()
        {
            (int a1, int a2) tt = new ValueTuple<int, int>(1, 2);//可以创建具名项元组

            var t = new ValueTuple<string, string, double>("China", "BeiJing", 131313);
            t.Item3 += 13;
            return $"{t.Item1} {t.Item2} gdp {t.Item3}";
        }

        /// <summary>
        /// ValueTuple.Create创建元组
        /// </summary>
        public string T14()
        {
            (int a1, int a2) tt = ValueTuple.Create<int, int>(1, 2);//可以创建具名项元组

            var t = ValueTuple.Create<string, string, double>("China", "BeiJing", 141414);
            t.Item3 += 14;
            return $"{t.Item1} {t.Item2} gdp {t.Item3}";
        }

        /// <summary>
        /// ValueTuple.Create创建嵌套元组
        /// </summary>
        public string T15()
        {
            var t = ValueTuple.Create<int, int, int, int, int, int, int, ValueTuple<string, string, double>>(1, 2, 3, 4, 5, 6, 7, ValueTuple.Create<string, string, double>("China", "BeiJing", 151515));
            t.Item8.Item3 += 15;
            return $"{t.Item8.Item1} {t.Item8.Item2} gdp {t.Item8.Item3}";
        }

        /// <summary>
        /// ValueTuple.Create创建具名项元组
        /// 嵌套内元组无法具名？？
        /// </summary>
        public string T16()
        {
            //(int a1, int a2, int a3, int a4, int a5, int a6, int a7, ValueTuple<string, string, double> a8) t
            //     = ValueTuple.Create<int, int, int, int, int, int, int, ValueTuple<string, string, double>>(1, 2, 3, 4, 5, 6, 7, ValueTuple.Create<string, string, double>("China", "BeiJing", 121212));

            (string country, string capital, double gdp) zhongguo = (country: "China", capital: "BeiJing", gdp: 161616);
            (int a1, int a2, int a3, int a4, int a5, int a6, int a7, ValueTuple<string, string, double> a8) t
                   = ValueTuple.Create<int, int, int, int, int, int, int, ValueTuple<string, string, double>>(1, 2, 3, 4, 5, 6, 7, zhongguo);

            t.a8.Item3 += 16;

            return $"{t.Item8.Item1} {t.Item8.Item2} gdp {t.Item8.Item3}";
        }
        #endregion
    }
}
