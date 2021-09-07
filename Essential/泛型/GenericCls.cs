using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essential
{
    public class GenericCls
    {
        public static void Test()
        {
            Performance.ValueTypePerfTest();
            Performance.ReferenceTypePerfTest();


        }
    }

    #region 泛型性能测试
    /*
        List<Int32> 耗时00:00:00.1656738 (垃圾回收次数GCs=  3)
        ArrayList of Int32 耗时00:00:01.4881267 (垃圾回收次数GCs= 40)
        List<String> 耗时00:00:00.2886788 (垃圾回收次数GCs=  3)
        ArrayList of String 耗时00:00:00.2886572 (垃圾回收次数GCs=  0)

        用引用类型来测试,差异就没那么明显了，但是泛型算法的优势还包括更清晰的代码和编译时的类型安全，虽然性能提升不是很明显，但泛型算法的其他优势也不容忽视。
     */
    internal static class Performance
    {
        /// <summary>
        /// 值类型测试
        /// </summary>
        public static void ValueTypePerfTest()
        {
            const Int32 count = 10000000;

            using (new OperationTimer("List<Int32>"))
            {
                List<Int32> l = new List<Int32>();
                for (Int32 n = 0; n < count; n++)
                {
                    l.Add(n);         // No boxing
                    Int32 x = l[n];  // No unboxing
                }
                l = null;  // 确保进行垃圾回收
            }

            using (new OperationTimer("ArrayList of Int32"))
            {
                ArrayList a = new ArrayList();
                for (Int32 n = 0; n < count; n++)
                {
                    a.Add(n);                // Boxing
                    Int32 x = (Int32)a[n];  // Unboxing
                }
                a = null;  // 确保进行垃圾回收
            }
        }

        /// <summary>
        /// 引用类型测试
        /// </summary>
        public static void ReferenceTypePerfTest()
        {
            const Int32 count = 10000000;

            using (new OperationTimer("List<String>"))
            {
                List<String> l = new List<String>();
                for (Int32 n = 0; n < count; n++)
                {
                    l.Add("X");           // 复制引用
                    String x = l[n];      // 复制引用
                }
                l = null;  // 确保进行垃圾回收
            }

            using (new OperationTimer("ArrayList of String"))
            {
                ArrayList a = new ArrayList();
                for (Int32 n = 0; n < count; n++)
                {
                    a.Add("X");                 // 复制引用
                    String x = (String)a[n];  // 检查强制类型转换 & 复制引用
                }
                a = null;  // 确保进行垃圾回收
            }
        }


        /// <summary>
        /// 这个类用于计算运行性能计时
        /// </summary>
        private sealed class OperationTimer : IDisposable
        {
            private Stopwatch m_stopwatch;
            private String m_text;
            private Int32 m_collectionCount;

            public OperationTimer(String text)
            {
                PrepareForOperation();

                m_text = text;
                m_collectionCount = GC.CollectionCount(0);// 返回已经对对象的指定代进行垃圾回收的次数

                //这应该是方法的最后一个语句，从而最大程度保证计时的准确性
                m_stopwatch = Stopwatch.StartNew();
            }

            public void Dispose()
            {
                Debug.WriteLine("{2} 耗时{0} (垃圾回收次数GCs={1,3})", (m_stopwatch.Elapsed), GC.CollectionCount(0) - m_collectionCount, m_text);
            }

            private static void PrepareForOperation()
            {
                GC.Collect();//强制对所有代进行及时垃圾回收
                GC.WaitForPendingFinalizers();//挂起当前线程，直到处理终结器队列的线程清空该队列为止
                GC.Collect();
            }
        }
    }
    #endregion

}
