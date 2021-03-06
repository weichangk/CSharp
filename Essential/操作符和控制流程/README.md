## 操作符和控制流程

- 条件操作符(? ：) 如：var a = true ? 1 : 2

- 空合并操作符(??) 如：var a = b ?? c 如果b不为空则a=b 否则 a=c。

- 空条件操作符(?.) 用于链式调用，非空的前提下才会执行链式调用。

- 控制流

- 作用域

- 闭包

- 按位操作符
  <p>
  计算机的所有值都表示成1和0的二进制形式，这些1和0称为二进制位(bit)，8位一组称为字节(byte)。一个字节中每个连续的位都对应"2的乘幂”，最右边1的位对应2的0次方，最左边的对应2的7次方。
  </p>
  <p>
  二进制可以有三种编码方式表示一个数：原码（原码就是用第一位表示符号，其余位表示值），反码，补码。正数的原码，反码，补码均相等。负数的反码是原码的符号位不变其他位取反。负数的补码是原码的符号位不变其他位取反最后一位加1（反码+1）。 计算机中所有数都是以补码形式存储的。
  </p>
  <p>
  对于有符号的数，二进制转换则有很大的不同。负数通过最左侧的1来标识，要将含有0的位置加到一起，而不是将含有1的位置加到一起。每个位置都对应负的"2的乘幂”，此外结果还要减1。
  </p>
  <p>
  总结：高位（符号位）为0为正数，数值等于数值位上为1的"2的位数次方”之和；高位（符号位）为1为负数，数值等于数值位上为0的"2的位数次方”之和加1再取反。正数的二进制数高位所有的0可以省略，如8位 0111 1111 可以是 111 1111。负数的高位1不可以省略，如1111 0110不能表示为0110。
  </p>
  <p>
  C#可以使用Convert.ToString(value, base)的重载方法和Convert.Toxxx(value, base)方法实现各数据类型和各进制数之间的转换;Convert.ToString(value, base)：将具体数据类型的整数value值转换为base进制数的等效字符串。Convert.ToXXX(value, base)：将具有b进制数的字符串转换为XXX类型数值。
  </p>

  - 位移操作符(>>,<<,>>=,<<=)
    <p>
    有时要将一个数的二进制值向右或向左移位。正数左移时所有位都向左移动指定位数（左舍右补0），右移（右舍左补0）。但如果是负数时左移动指定位数（左舍右补0），右移（右舍左补1）。两个移位操作符是>>和<<分别称为右移位和左移位操作符。
    </p>  
    <p>
    复合位移和赋值操作符>>=,<<=。a >>= b相当于 a = a >> b。
    </p>

  - 按位操作符(&,|,^) 按位复合赋值操作符(&=,|=,^=)
    |运算符|用法|描述|
    |:----:|:----:|:----:|
    |按位与（ AND ）|a & b|对于每一个比特位，只有两个操作数相应的比特位都是 1 时，结果才为 1，否则为 0|
    |按位或（ OR ）|a \| b|对于每一个比特位，当两个操作数相应的比特位至少有一个 1 时，结果为 1，否则为 0|
    |按位异或（ XOR ）|a ^ b|对于每一个比特位，当两个操作数相应的比特位有且只有一个 1 时，结果为 1，否则为 0|
    |按位非（ NOT ）|~ a|反转操作数的比特位，即 0 变成 1，1 变成 0|



  - 补充8进制16进制！！！

- 预处理指令
  <p>
  C#预处理器在编译时调用。预处理器指令告诉C#编译器要编译哪些代码，并指出如何处理代码中的特定错误和警告。C#预处理器指令还可告诉C#编译器有关代码组织的信息。
  </p>
  
  |预处理器指令|	描述|
  |:----:|:----:|
  |#define	|它用于定义一系列成为符号的字符。|
  |#undef	|它用于取消定义符号。|
  |#if	|它用于测试符号是否为真。|
  |#else	|它用于创建复合条件指令，与 #if 一起使用。|
  |#elif	|它用于创建复合条件指令。|
  |#endif	|指定一个条件指令的结束。|
  |#line	|它可以让您修改编译器的行数以及（可选地）输出错误和警告的文件名。|
  |#error	|它允许从代码的指定位置生成一个错误。|
  |#warning	|它允许从代码的指定位置生成一级警告。|
  |#region	|它可以让您在使用 Visual Studio Code Editor 的大纲特性时，指定一个可展开或折叠的代码块。|
  |#endregion	|它标识着 #region 块的结束。|

