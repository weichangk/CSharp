## 良构类型

### 重写object成员
#### 重写ToString()
<p>
在对象上调用Tostring()默认返回类的完全限定名称。例如在一个System.I0.Filestream对象上调用Tostring()会返回字符串"System.I0.Filestream"。但Tostring()对于某些类应返回更有意义的结果，以string类为例, Tostring()应返回字符串值本身。如需返回有用的，面向开发人员的诊断字符串，就要重写Tostring()。要使Tostring()返回的字符串简短。不要从ToString()返回空字符串来代表“空" (null)。避免Tostring()引发异常或造成可观察到的副作用(改变对象状态)。如果返回值与语言文化相关或要求格式化(例如DateTime)，就要重载Tostring(string format)或实现IFormattable。考虑从ToString()返回独一无二的字符串以标识对象实例。
</p>


### 对象的相等性和同一性
<p>
System.Object类型提供了名为Equals的虚方法。假如this和obj实参引用同一个对象，就返回true。似乎合理是因为Equals知道对象肯定包含和它自身一样的值。假如实参引用不同对象，Equals就不肯定对象是否包含相同的值，所以返回false。换言之,对于Object的Equals方法的默认实现，它实现的实际是同一性(identity)，而非相等性(equality)。
</p>

#### 什么时候需要重写Equals()方法？
- 对于引用类型需要按照对象内容而不是对象引用来进行比较时。引用类型一般不需要重写 == 操作符。
- 对于值类型，创建值类型的时候，总是应该针对这个类型重写ValueType.Equals()方法。因为值类型都继承自System.ValueType类，System.ValueType类默认通过反射来实现比较，效率不够高。值类型中默认的 == 运算符会默认通过反射进行比较，因此也应该重写 == 操作符。

#### 重写Equals()方法时的注意事项
- Equals()方法必须满足等同关系的3项数学性质：自反性(x.Equals(x)肯定返回true)、对称性(x.Equals(y)和y.Equals(x)返回相同的值)、可传递性(x.Equals(y)返回true, y.Equals(z)返回true，则x.Equals(z)肯定返回true)。
- Equals()方法决不应该抛出异常。
- 重写 Equals()方法时，只有在基类型的Equals(object)不是由System.Object或System.ValueType所提供的情况下，才需要调用基类型的版本。
- 重写 Equals()的时候，还应该让该类型实现 IEquatable\<T> 接口。
- 重写 Equals()方法后，通常应该同时重写 GetHashCode() 方法。
- 重写Equals()后可能出现不一致的情况。对两个对象执行Equals()可能返回true。但 == 操作符可能返回false，因为 == 默认也只是执行引用相等性检查。为解决该问题，有必要重载相等 == 和不相等 != 操作符。
- 如果以后要出于排序目的而比较类型的实例，类型还应实现System.IComparable的CompareTo方法和System.IComparable<T>的类型安全的CompareTo方法。如果实现了这些方法，还可考虑重载各种比较操作符方法(<, <=, >, >=)，在这些方法内部调用类型安全的CompareTo方法。


### 对象哈希码
<p>
FCL的设计者认为，如果能将任何对象的任何实例放到哈希表集合中，能带来很多好处。为此, System.Object提供了虚方法GetHashCode，它能获取任意对象的Int32哈希码。如果定义的类型重写了Equals方法，还应重写GetHashCode方法。如果类型重写Equals的同时没有重写GetHashCode, Microsoft C#编译器会生成一条警告。类型定义Equals之所以还要定义GetHashCode，是由于在System.Collections.Hashtable类型、System.Collections.Generic.Dictionary类型以及其他一些集合的实现中，要求两个对象必须具有相同哈希码才被视为相等。所以重写Equals就必须重写GetHashCode，确保相等性算法和对象哈希码算法一致。
</p>

[关于GetHashCode的使用准则](https://zhuanlan.zhihu.com/p/87291534)


#### 重写 GetHashCode() 方法时的注意事项
- 如果Equals()方法认定两个对象相等，那么这两个对象的HashCode也必须相同；
- 对任意对象来说，其HashCode必须在生命周期内保持不变；
- HashCode计算方法应该将其值均匀地映射到各个整数上，避免堆集。一种常用的HashCode算法是：对类型中的每个相互独立的不可变字段调用GetHashCode()方法，并对返回的HashCode进行异或(XOR)运算，将得到的最终结果作为对象本身的HashCode。


#### 用元组重写GetHashCode()和Equals()
<p>
Equals()和GetHashcode()的实现相当烦琐，实际代码又比较模板化。Equals()需要比较包含的所有标识(关键)数据结构，同时避免无限递归或空引用异常。GetHashCode()则需要通过XOR运算来合并所有非空标识(关键)数据结构的唯一哈希码。利用元组可以简化。如：(Longitude, Latitude).Equals((o.Longitude, o.Latitude)); GetHashCode()用元组来实现之后发生了翻天覆地的变化。不需要对标识(关·键)成员执行复杂的XOR运算，只需实例化所有这些成员的一个元组返回该元组的GetHashCode()。如：return (Longitude, Latitude).GetHashCode();
</p>


### 操作符重载
<p>
除了x.y，f(x)，new，typeof，default，checked，unchecked, delegate，is，as，=，=> 之外，其他所有操作符都支持。如：public static bool operator ==(ProductSerialNumber left, ProductSerialNumber right){}
</p>

### 弱引用
<p>
弱引用是为创建起来代价较高(开销很大)，而且维护开销特别大的对象而设计的。假定一个很大的对象列表要从一个数据库中加载并向用户显示，在这种情况下加载列表的代价是很高的，一旦列表被用户关闭，就应该可以进行垃圾回收。但假如用户多次请求这个列表，那么每次都要执行代价高昂的加载动作。解决方案是使用弱引用，这样就可使用代码检查列表是否清除，如尚未清除就重新引用同一个列表。这样弱引用就相当于对象的一个内存缓存。缓存中的对象可被快速获取。但假如垃圾回收器已回收了这些对象的内存，就还是要重新创建它们。（相比普通局部变量生命周期延长的局部单例对象）
</p>


### 终结器（析构函数）
<p>
终结器(finalizer)和使用new显式调用构造函数不同，终结器不能从代码中显式调用，只有垃圾回收器负责为对象实例调用终结器，编译器不能确定终结器的切确运行时间，终结器会在对象最后一次使用之后，并在应用程序正常关闭前的某个时间运行。如进程异常终止，终结器将不会运行。例如计算机断电或进程被强行终止，就会阻止终结器的运行。

对于包含非托管资源的类，可以将释放非托管资源的代码放在终结器（析构函数）中。

通常同时实现终结器和Dispose方式，通过终结器释放释放非托管资源或显示调用Dispose释放托管和非托管资源（提高垃圾回收的性能），即使忘记了显示调用Dispose方法，但也不至于使得非托管资源得不到释放。

注意，不能在析构函数中释放托管资源，因为析构函数是有垃圾回收器调用的，可能在析构函数调用之前，类包含的托管资源已经被回收了，从而导致无法预知的结果。

凡是继承了IDisposable接口的类，都可以使用using语句，从而在超出作用域后，让系统自动调用Dispose()方法。一个资源安全的类，都实现了IDisposable接口和析构函数。提供手动释放资源和系统自动释放资源的双保险。

注意有终结器的对象如果不显式dispose，其生存期会被延长，因为即使对它的所有显式引用都不存在了, 终结器队列f-reachable仍然包含对它的引用，使对象一直生存，直至终结器队列f-reachable处理完毕。
</p>

<p>
托管资源指的是.NET可以自动进行回收的资源，主要是指托管堆上分配的内存资源。托管资源的回收工作是不需要人工干预的，有.NET运行库在合适调用垃圾回收器进行回收。非托管资源指的是.NET不知道如何回收的资源，最常见的一类非托管资源是包装操作系统资源的对象，例如文件，窗口，网络连接，数据库连接，画刷，图标等。
</p>

#### 设计规范
- 要只为使用了稀缺或昂贵资源的对象实现终结器方法，即使终结会推迟垃圾回收。
- 要为有终结器的类实现IDisposable接口以支持确定性终结。
- 要为实现了IDisposable的类实现终结器方法，以防Dispose()没有被显式调用。
- 要重构终结器方法来调用与IDisposable相同的代码，可能就是调用一下Dispose()方法。
- 不要在终结器方法中抛出异常。
- 要从Dispose()中调用System.GC.SuppressFinalize(), 以使垃圾回收更快地发生，并避免重复性的资源清理。
- 要保证Dispose()可以重入(可被多次调用)。
- 要保持Dispose()的简单性，把重点放在终结所要求的资源清理上。
- 避免为自己拥有的、带终结器的对象调用Dispose()。相反，依赖终结队列清理实例。
- 避免在终结方法中引用未被终结的其他对象。
- 要在重写Dispose()时调用基类的实现。
- 考虑在调用Dispose()后将对象状态设为不可用。对象被dispose之后，调用除Dispose()之外的方法应引发objectDisposedException.异常。(Dispose()应该能多次调用。)
- 要为含有可dispose字段(或属性)的类型实现IDisposable接口，并dispose这些字段引用的对象。


### 推迟初始化
<p>
延迟加载，亦称延迟实例化，延迟初始化等，主要表达的思想是，把对象的创建将会延迟到使用时创建，而不是在对象实例化时创建对象，即用时才加载。这种方式有助于提高于应用程序的性能，避免浪费计算，节省内存的使用等。当创建一个对象的子对象开销比较大时，而且有可能在程序中用不到这个子对象，那么可以考虑用延迟加载的方式来创建子对象。另外一种情况就是当程序一启动时，需要创建多个对象，但仅有几个对象需要立即使用，这样就可以将一些不必要的初始化工作延迟到使用时，这样可以非常有效的提高程序的启动速度。结合泛型和Lambda表达式使用推迟加载。就是个委托。。。使用var x = new Lazy<T>(()=>{new T});实例化延迟加载委托。x.Value执行委托。。。
</p>