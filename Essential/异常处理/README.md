## 异常处理

### 多异常类型
.NET Framework 类库中的所有异常都派生于 Exception 类，异常包括系统异常和应用异常。默认所有系统异常派生于 System.SystemException，所有的应用程序异常派生于 System.ApplicationException。系统异常包括 OutOfMemoryException、IOException、NullReferenceException。

- SystemException   其他用户可处理的异常的基本类 
- InteropException   目标在或发生在CLR外面环境中的异常的基类。
- ArgumentException   方法的参数是非法的 
- ArgumentNullException   一个空参数传递给方法，该方法不能接受该参数 
- ArgumentOutOfRangeException   参数值超出范围 
- ArithmeticException   出现算术上溢或者下溢 
- ArrayTypeMismatchException   试图在数组中存储错误类型的对象 
- BadImageFormatException   图形的格式错误 
- DivideByZeroException   除零异常 
- DllNotFoundException   找不到引用的DLL 
- FormatException   参数格式错误 
- IndexOutOfRangeException   数组索引超出范围 
- InvalidCastException  使用无效的类 
- InvalidOperationException   方法的调用时间错误 
- MethodAccessException   试图访问私有或者受保护的方法 
- MissingMemberException   访问一个无效版本的DLL 
- NotFiniteNumberException   对象不是一个有效的成员 
- NotSupportedException   调用的方法在类中没有实现 
- NullReferenceException   试图使用一个未分配的引用 
- OutOfMemoryException   内存空间不够 
- PlatformNotSupportedException   平台不支持某个特定属性时抛出该错误 
- StackOverflowException   堆栈溢出
- ComException   包含COM类的HRESULT信息的异常。
- SEHException   封装Win32结构异常处理信息的异常。
- SqlException   封装了SQL操作异常。

### 捕捉异常
可通过捕捉特定的异常类型来识别并解决问题。 C#允许使用多个catch块，每个块都面向一个具体的异常类型。越具体的异常优先级应该越高（写在更前面），最后一个catch类型参数可以不要(常规catch块，catch{})。
在catch块中使用throw; 如选择抛出具体异常，会更新所有栈信息来匹配新的抛出位置，这会导致指示异常最初发生位置的所有栈信息丢失，使问题变得更难诊断。C#支持不指定具体异常，但只能在catch块中使用的throw语句。这使代码可以检查异常，判断是否能完整处理该异常，不能就重新抛出异常。结果是异常似乎从未捕捉，也没有任何栈信息被替换。

### 异常处理规范
- 只捕捉能处理的异常。
- 不要隐藏不能完全处理的异常。
- 尽量少用System.Exception和常规catch块。
- 避免在调用栈较低的位置报告或记录异常。
- 在catch块中使用throw; 而不是throw <异常对象>语句。防止栈追踪重置为重新抛出的位置而不是原始抛出位置。如果不做异常处理只写throw;就没必要写了。
- 想好异常条件来避免在catch块中重新抛出异常。
- 避免在异常条件表达式中抛出异常。

### 自定义异常
必须抛出异常时，应首选框架内建的异常，因其得到构建良好，能被很好地理解。在实际编程中可以使用自定义异常来处理一些框架内建未涉及的一些异常处理。
- 如果异常不以有别于现有CLR异常的方式处理，就不要创建新异常。相反应抛出现有的框架异常。
- 要创建新异常类型来描述特别的程序错误，这种错误无法用现有的CLR异常来描述，而且需要采取有别于现有CLR异常的方式以程序化的方式处理。
- 没有具体框架内建相对应，不希望在Catch块中处理，希望能明确标志错误种类的异常就可以使用自定义异常。
- 要为所有自定义异常类型提供无参构造函数，还要提供获取消息和内部异常的构造函数。
- 要为异常类的名称附加"Exception"后缀。
- 要使异常能由“运行时”序列化。
- 考虑提供异常属性，以便通过程序访问关于异常的额外信息。
- 避免异常继承层次结构过深。



