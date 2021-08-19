using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Essential.Test
{
    public class OperatorAndControlFlowTest : TestBaseFixture
    {
        private readonly OperatorAndControlFlowCls _operatorAndControlFlowCls;
        public OperatorAndControlFlowTest(ITestOutputHelper output, LongTimeFixture fixture) : base(output, fixture)
        {
            _operatorAndControlFlowCls = new OperatorAndControlFlowCls();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("11")]
        public void T1(string str)
        {
            var result = _operatorAndControlFlowCls.T1(str);
            Output.WriteLine(result);
        }

        #region 各进制之间的转换
        [Theory]
        [InlineData(0, 2)]
        [InlineData(3, 2)]
        [InlineData(255, 2)]
        public void ByteSysConvert(byte value, Int32 b)
        {
            var result = _operatorAndControlFlowCls.ByteSysConvert(value, b);
            Output.WriteLine(result);
        }
        [Theory]
        //[InlineData(-129, 2)]
        [InlineData(-1, 2)]
        [InlineData(-3, 2)]
        [InlineData(-128, 2)]
        [InlineData(127, 2)]
        public void SByteSysConvert(sbyte value, int b)
        {
            var result = _operatorAndControlFlowCls.SByteSysConvert(value, b);
            Output.WriteLine(result);
        }

        [Theory]
        [InlineData(-32768, 2)]
        [InlineData(32767, 2)]
        public void ShortSysConvert(short value, Int32 b)
        {
            var result = _operatorAndControlFlowCls.ShortSysConvert(value, b);
            Output.WriteLine(result);
        }

        [Theory]
        [InlineData(0, 2)]
        [InlineData(65535, 2)]
        public void UShortSysConvert(ushort value, Int32 b)
        {
            var result = _operatorAndControlFlowCls.UShortSysConvert(value, b);
            Output.WriteLine(result);
        }

        [Theory]
        [InlineData(-2147483648, 2)]
        [InlineData(2147483647, 2)]
        public void Int32SysConvert(int value, Int32 b)
        {
            var result = _operatorAndControlFlowCls.Int32SysConvert(value, b);
            Output.WriteLine(result);
        }

        [Theory]
        [InlineData(0, 2)]
        [InlineData(4294967295, 2)]
        public void UInt32SysConvert(uint value, Int32 b)
        {
            var result = _operatorAndControlFlowCls.UInt32SysConvert(value, b);
            Output.WriteLine(result);
        }
        [Theory]
        [InlineData("00000000", 2)]
        [InlineData("11111111", 2)]
        [InlineData("10000000", 2)]
        [InlineData("01111111", 2)]
        [InlineData("1111111", 2)]
        public void SysConvertToSByte(string value, int b)
        {
            var result = _operatorAndControlFlowCls.SysConvertToSByte(value, b);
            Output.WriteLine(result.ToString());
        }
        #endregion

        #region 位移操作符
        [Theory]
        [InlineData("0000000000000000", 2, true)]
        [InlineData("1111111111111111", 3, true)]
        [InlineData("1000000000000000", 4, true)]
        [InlineData("0111111111111111", 5, true)]
        [InlineData("0110000100001011", 7, true)]
        [InlineData("1110000100001011", 5, true)]
        [InlineData("0000000000000000", 2, false)]
        [InlineData("1111111111111111", 3, false)]
        [InlineData("1000000000000000", 4, false)]
        [InlineData("0111111111111111", 5, false)]
        [InlineData("0110000100001011", 7, false)]
        [InlineData("1110000100001011", 5, false)]
        public void ShortBinStrShiftOperation(string shortBinStr, byte bit, bool left)
        {
            var result = _operatorAndControlFlowCls.ShortBinStrShiftOperation(shortBinStr, bit, left);
            Output.WriteLine(result);
        }
        #endregion
    }
}
