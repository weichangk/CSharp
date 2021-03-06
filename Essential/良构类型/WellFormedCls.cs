using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essential
{
    public class WellFormedCls
    {

        public override string ToString()
        {
            return nameof(WellFormedCls);
        }

        /// <summary>
        /// String Equals Test
        /// </summary>
        /// <returns></returns>
        public string StringEqualsTest()
        {
            string str1 = "str1";
            string str2 = "str2";
            string str3 = "str1";

            string ret = "";
            if (str1.Equals(str2))
            {
                ret = $"{ret}str1:{str1} equals str2:{str2}{Environment.NewLine}";
            }
            else
            {
                ret = $"{ret}str1:{str1} not equals str2:{str2}{Environment.NewLine}";
            }
            if (str1.Equals(str3))
            {
                ret = $"{ret}str1:{str1} equals str3:{str3}{Environment.NewLine}";
            }
            else
            {
                ret = $"{ret}str1:{str1} not equals str3:{str3}{Environment.NewLine}";
            }
            return ret;
        }

        /// <summary>
        /// ValueType Override Equals Test
        /// </summary>
        /// <returns></returns>
        public string ValueTypeOverrideEqualsTest()
        {
            Coordinate v1 = new Coordinate("foo", 10);
            Coordinate v2 = new Coordinate("foo", 10);
            string ret = "";
            if (v1.Equals(v2))
            {
                ret = $"{ret}v1 equals v2{Environment.NewLine}";
            }
            else
            {
                ret = $"{ret}v1 not equals v2{Environment.NewLine}";
            }
            if (v1 == v2)
            {
                ret = $"{ret}v1 == v2{Environment.NewLine}";
            }
            else
            {
                ret = $"{ret}v1 != v2{Environment.NewLine}";
            }
            return ret;
        }


        public string VirtualEqualsTest()
        {
            ProductSerialNumberBase serialNumber1 = new ProductSerialNumberBase("PV", 1000, 9187234);
            ProductSerialNumberBase serialNumber2 = serialNumber1;
            ProductSerialNumberBase serialNumber3 = new ProductSerialNumberBase("PV", 1000, 9187234);

            string ret="";
            if (ProductSerialNumberBase.ReferenceEquals(serialNumber1, serialNumber2))//true
            {
                ret = $"{ret}serialNumber1 reference equals serialNumber2{Environment.NewLine}";
            }
            else
            {
                ret = $"{ret}serialNumber1 reference not equals serialNumber2{Environment.NewLine}";
            }
            if (serialNumber1.Equals(serialNumber2))//true
            {
                ret = $"{ret}serialNumber1 equals serialNumber2{Environment.NewLine}";
            }
            else
            {
                ret = $"{ret}serialNumber1 not equals serialNumber2{Environment.NewLine}";
            }

            //
            if (ProductSerialNumberBase.ReferenceEquals(serialNumber1, serialNumber3))//false
            {
                ret = $"{ret}serialNumber1 reference equals serialNumber3{Environment.NewLine}";
            }
            else
            {
                ret = $"{ret}serialNumber1 reference not equals serialNumber3{Environment.NewLine}";
            }
            if (serialNumber1.Equals(serialNumber3))//false
            {
                ret = $"{ret}serialNumber1 equals serialNumber3{Environment.NewLine}";
            }
            else
            {
                ret = $"{ret}serialNumber1 not equals serialNumber3{Environment.NewLine}";
            }
            if (serialNumber1 == serialNumber3)//false
            {
                ret = $"{ret}serialNumber1 == serialNumber3{Environment.NewLine}";
            }
            else
            {
                ret = $"{ret}serialNumber1 != serialNumber3{Environment.NewLine}";
            }
            return ret;
        }
        public string VirtualEqualsTest1()
        {

            string ret = "";
            if (ReferenceEquals(new ProductSerialNumberBase("PV", 1000, 9187234), new ProductSerialNumberBase("PV", 1000, 9187234)))//false
            {
                ret = $"{ret}serialNumber1 reference equals serialNumber2{Environment.NewLine}";
            }
            else
            {
                ret = $"{ret}serialNumber1 reference not equals serialNumber2{Environment.NewLine}";
            }
            if (new ProductSerialNumberBase("PV", 1000, 9187234).Equals(new ProductSerialNumberBase("PV", 1000, 9187234)))//false
            {
                ret = $"{ret}serialNumber1 equals serialNumber2{Environment.NewLine}";
            }
            else
            {
                ret = $"{ret}serialNumber1 not equals serialNumber2{Environment.NewLine}";
            }

            if (new ProductSerialNumberBase("PV", 1000, 9187234) == new ProductSerialNumberBase("PV", 1000, 9187234))//false
            {
                ret = $"{ret}serialNumber1 == serialNumber3{Environment.NewLine}";
            }
            else
            {
                ret = $"{ret}serialNumber1 != serialNumber3{Environment.NewLine}";
            }
            return ret;
        }
        /// <summary>
        /// object Override Equals Test
        /// </summary>
        /// <returns></returns>
        public string OverrideEqualsTest()
        {
            ProductSerialNumber serialNumber1 = new ProductSerialNumber("PV", 1000, 9187234);
            ProductSerialNumber serialNumber3 = new ProductSerialNumber("PV", 1000, 9187234);

            string ret = "";

            if (serialNumber1.Equals(serialNumber3))//true
            {
                ret = $"{ret}serialNumber1 equals serialNumber3{Environment.NewLine}";
            }
            else
            {
                ret = $"{ret}serialNumber1 not equals serialNumber3{Environment.NewLine}";
            }
            return ret;
        }
        public string OverrideEqualsTest1()
        {

            string ret = "";
            if (new ProductSerialNumber("PV", 1000, 9187234).Equals(new ProductSerialNumber("PV", 1000, 9187234)))//true
            {
                ret = $"{ret}serialNumber1 equals serialNumber2{Environment.NewLine}";
            }
            else
            {
                ret = $"{ret}serialNumber1 not equals serialNumber2{Environment.NewLine}";
            }
            return ret;
        }
        public string OperatorTest()
        {
            ProductSerialNumber serialNumber1 = new ProductSerialNumber("PV", 1000, 9187234);
            ProductSerialNumber serialNumber3 = new ProductSerialNumber("PV", 1000, 9187234);

            string ret = "";

            if (serialNumber1 == serialNumber3)//true
            {
                ret = $"{ret}serialNumber1 == serialNumber3{Environment.NewLine}";
            }
            else
            {
                ret = $"{ret}serialNumber1 != serialNumber3{Environment.NewLine}";
            }
            return ret;
        }



        /// <summary>
        /// 弱引用使用
        /// </summary>
        /// <returns></returns>
        public string WeakReferencesTest()
        {
            string ret = "";
            ProductSerialNumber p = new ProductSerialNumber("foo", 10, 20);
            WeakReference wk = new WeakReference(p);

            for (int i = 0; i < 10; i++)
            {
                p = GetData(wk);
                ret = $"{ret}{p.GetHashCode()}{Environment.NewLine}";
            }
            return ret;
        }
        public ProductSerialNumber GetData(WeakReference wk)
        {
            ProductSerialNumber data;

            if (wk.IsAlive)
            {
                data = wk.Target as ProductSerialNumber;
            }
            else 
            {
                data = new ProductSerialNumber("foo", 10, 20);
            }

            return data;
        }



        public void LazyLoadTest()
        {
            BlogUser blogUser = new BlogUser(1);
            Debug.WriteLine("blogUser has been initialized");
            foreach (var article in blogUser.Articles)
            {
                Debug.WriteLine(article.Title);
            }
        }

    }





    #region 重写Equals() GetHashCode()
    public struct Coordinate : IEquatable<ValueType>
    {
        public Coordinate(string longitude, int latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }

        public string Longitude { get; }
        public int Latitude { get; }

        public override bool Equals(object obj)
        {
            if (obj is Coordinate other)
            {
                return this.Equals(other);
            }
            return false;
        }

        public bool Equals(ValueType other)
        {
            if (other is Coordinate o)
            {
                //return (Longitude == o.Longitude) && (Latitude == o.Latitude);
                return (Longitude, Latitude).Equals((o.Longitude, o.Latitude));
            }

            return false;
        }

        public static bool operator ==(Coordinate left, Coordinate right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Coordinate left, Coordinate right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            //int hashCode = Longitude.GetHashCode();
            //// As long as the hash codes are not equal
            //if (Longitude.GetHashCode() != Latitude.GetHashCode())
            //{
            //    hashCode ^= Latitude.GetHashCode();  // Xor (eXclusive OR)
            //}
            //return hashCode;

            return (Longitude, Latitude).GetHashCode();
        }

    }


    public class ProductSerialNumberBase
    {
        public ProductSerialNumberBase(string productSeries, int model, long id)
        {
            ProductSeries = productSeries;
            Model = model;
            Id = id;
        }

        public string ProductSeries { get; }
        public int Model { get; }
        public long Id { get; }
    }

    public class ProductSerialNumber : ProductSerialNumberBase, IEquatable<ProductSerialNumber>
    {
        public ProductSerialNumber(string productSeries, int model, long id) : base(productSeries, model, id)
        {
        }
        public bool ValueEquals(ProductSerialNumber obj)
        {
            //return ((obj != null) && (ProductSeries == obj.ProductSeries) && (Model == obj.Model) && (Id == obj.Id));
            return (ProductSeries, Model, Id).Equals((obj.ProductSeries, obj.Model, obj.Id));
        }

        public bool Equals(ProductSerialNumber other)
        {
            if (other == null)
            {
                return false;
            }
            if (ReferenceEquals(this, other))//如果引用相同则相等
            {
                return true;
            }
            if (this.GetType() != other.GetType())//如果类型不相同则不相等
            {
                return false;
            }
            return ValueEquals(other);//如果所有字段值相等则相等（重载就是为了加这个值相等判断）
        }

        public override int GetHashCode()
        {
            //int hashCode = ProductSeries.GetHashCode();
            //hashCode ^= Model;  // Xor (eXclusive OR)
            //hashCode ^= Id.GetHashCode();  // Xor (eXclusive OR)
            //return hashCode;
            return (ProductSeries, Model, Id).GetHashCode();
        }

        public static bool operator ==(ProductSerialNumber left, ProductSerialNumber right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }
            return left.ValueEquals(right);
        }
        public static bool operator !=(ProductSerialNumber left, ProductSerialNumber right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ProductSerialNumber);
        }
    }

    #endregion



    #region 终结器
    public class FinalizerTest : IDisposable
    {
        /// <summary>
        /// 是否已释放资源的标志
        /// </summary>
        bool isDisposed = false;

        ~FinalizerTest()//由垃圾回收器调用，释放非托管资源
        {
            Dispose(false);// 释放非托管资源
        }

        #region IDisposable Members
        /// <summary>
        /// 由类的使用者在外部显示调用，释放类资源
        /// </summary>
        public void Dispose()
        {
            Dispose(true);// 释放托管和非托管资源

            //阻止GC把该对象放入终结器队列
            //将对象从垃圾回收器链表中移除，
            //从而在垃圾回收器工作时，只释放托管资源，而不执行此对象的析构函数
            //避免了一定要等待终结队列处理完毕才能清理资源的限制。
            GC.SuppressFinalize(this);
        }
        #endregion


        //参数为true表示释放所有资源，只能由使用者调用
        //参数为false表示释放非托管资源，只能由垃圾回收器自动调用
        //如果子类有自己的非托管资源，可以重载这个函数，添加自己的非托管资源的释放
        //但是要记住，重载此函数必须保证调用基类的版本，以保证基类的资源正常释放
        protected virtual void Dispose(bool isDisposing)
        {
            if (!isDisposed)// 如果资源未释放 这个判断主要用了防止对象被多次释放
            {
                if (isDisposing)
                {

                    //释放托管资源

                }


                //释放非托管资源
            }
            isDisposed = true;
        }
    }
    #endregion



    #region 延迟加载

    public class BlogUser
    {
        Lazy<List<Article>> _articles;
        public int Id { get; private set; }
        public List<Article> Articles 
        {
            get
            {
                return _articles.Value;
            }
        }
        public BlogUser(int id)
        {
            this.Id = id;
            _articles = new Lazy<List<Article>>(() => new List<Article> {
                                                            new Article{Id=1,Title="Lazy Load",PublishDate=DateTime.Parse("2011-4-20")},
                                                            new Article{Id=2,Title="Delegate",PublishDate=DateTime.Parse("2011-4-21")},
                                                            new Article{Id=3,Title="Event",PublishDate=DateTime.Parse("2011-4-22")},
                                                            new Article{Id=4,Title="Thread",PublishDate=DateTime.Parse("2011-4-23")}
                                                            });
            Debug.WriteLine("BlogUser Initializer");
        }
    }
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }

        public Article()
        {
            Debug.WriteLine($"Article {Id} Initalizer");
        }
    }
    #endregion
}
