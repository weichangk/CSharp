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
        public static void PerformanceTest()
        {
            Performance.ValueTypePerfTest();
            Performance.ReferenceTypePerfTest();
        }

        public static void BinarySearchTest()
        {
            ArrayBinarySearchCls.BinarySearchTest();
        }

        public static void OpenTypesTest()
        {
            OpenTypes.Test();
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


    #region Array.BinarySearch<T> 二分搜索算法
    class ArrayBinarySearchCls
    {
        public static void BinarySearchTest()
        {
            Byte[] byteArray = new Byte[] { 5, 1, 4, 2, 3 };

            Int32 i = Array.BinarySearch<Byte>(byteArray, 2);
            Debug.WriteLine(i);   // -1

            Array.Sort<Byte>(byteArray);

            // 调用 Byte[] 的二分搜索算法。BinarySearch是二进制搜索算法，复杂度为O(log n)，效率更高，但需要先排序。
            i = Array.BinarySearch<Byte>(byteArray, 2);
            Debug.WriteLine(i);   // 1
        }
    }


    #endregion


    #region 开放类型
    internal static class OpenTypes
    {
        public static void Test()
        {
            Object o = null;

            // Dictionary<,> is an open type having 2 type parameters
            Type t = typeof(Dictionary<,>);

            // Try to create an instance of this type (fails)
            o = CreateInstance(t);
            Debug.WriteLine("------");

            // DictionaryStringKey<> is an open type having 1 type parameter
            t = typeof(DictionaryStringKey<>);

            // Try to create an instance of this type (fails)
            o = CreateInstance(t);
            Debug.WriteLine("------");

            // DictionaryStringKey<Guid> is a closed type
            t = typeof(DictionaryStringKey<Guid>);

            // Try to create an instance of this type (succeeds) 
            o = CreateInstance(t);

            // Prove it actually worked
            Debug.WriteLine("Object type=" + o.GetType());
        }

        private static Object CreateInstance(Type t)
        {
            Object o = null;
            try
            {
                o = Activator.CreateInstance(t);
                Debug.WriteLine($"Created instance of {t}");
            }
            catch (ArgumentException e)
            {
                Debug.WriteLine(e.Message);
            }
            return o;
        }

        // 一部分指定的开放类型
        internal sealed class DictionaryStringKey<TValue> :
           Dictionary<String, TValue>
        {
        }
    }
    #endregion

    #region 泛型类型继承
    internal static class GenericInheritance
    {
        public static void Go()
        {
            SameDataLinkedList();
            DifferentDataLinkedList();
        }

        private static void SameDataLinkedList()
        {
            Node<Char> head = new Node<Char>('C');
            head = new Node<Char>('B', head);
            head = new Node<Char>('A', head);
            Console.WriteLine(head.ToString());
        }

        private static void DifferentDataLinkedList()
        {
            Node head = new TypedNode<Char>('.');
            head = new TypedNode<DateTime>(DateTime.Now, head);
            head = new TypedNode<String>("Today is ", head);
            Console.WriteLine(head.ToString());
        }

        private sealed class Node<T>
        {
            public T m_data;
            public Node<T> m_next;

            public Node(T data) : this(data, null)
            {
            }

            public Node(T data, Node<T> next)
            {
                m_data = data; m_next = next;
            }

            public override String ToString()
            {
                return m_data.ToString() + ((m_next != null) ? m_next.ToString() : null);
            }
        }

        private class Node
        {
            protected Node m_next;

            public Node(Node next)
            {
                m_next = next;
            }
        }

        private sealed class TypedNode<T> : Node
        {
            public T m_data;

            public TypedNode(T data): this(data, null)
            {
            }

            public TypedNode(T data, Node next): base(next)
            {
                m_data = data;
            }

            public override String ToString()
            {
                return m_data.ToString() + ((m_next != null) ? m_next.ToString() : null);
            }
        }

        private sealed class GenericTypeThatRequiresAnEnum<T>
        {
            static GenericTypeThatRequiresAnEnum()
            {
                if (!typeof(T).IsEnum)
                {
                    throw new ArgumentException("T must be an enumerated type");
                }
            }
        }
    }
    #endregion

}
