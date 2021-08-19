using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essential
{
    public class OperatorAndControlFlowCls
    {
        /// <summary>
        /// 空条件操作符(?.)测试
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string T1(string str)
        {
            if (str?.Length == 0)
            {
                return "Is Empty";
            }
            else if (str?.Length > 0)
            {
                return "Is Not Empty";
            }
            else
            {
                return "Null";
            }
        }

        #region 按位操作符

        #region 各进制之间的转换
        //Convert.ToString(value, base)：将具体数据类型的整数value值转换为base进制数的等效字符串。

        /// <summary>
        /// 将8位无符号整数的值转换为b进制数等效字符串
        /// </summary>
        /// <param name="value"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public string ByteSysConvert(byte value, int b)
        {
            return Convert.ToString(value, b);
        }

        /// <summary>
        /// 将8位带符号整数的值转换为b进制数等效字符串
        /// </summary>
        /// <param name="value"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public string SByteSysConvert(sbyte value, int b)
        {
            return Convert.ToString(value, b);
        }

        /// <summary>
        /// 将16位带符号整数的值转换为b进制数等效字符串
        /// </summary>
        /// <param name="value"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public string ShortSysConvert(short value, int b)
        {
            return Convert.ToString(value, b);
        }
        /// <summary>
        /// 将16位无符号整数的值转换为b进制数等效字符串
        /// </summary>
        /// <param name="value"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public string UShortSysConvert(ushort value, int b)
        {
            return Convert.ToString(value, b);
        }

        /// <summary>
        /// 将32位带符号整数的值转换为b进制数等效字符串
        /// </summary>
        /// <param name="value"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public string Int32SysConvert(int value, int b)
        {
            return Convert.ToString(value, b);
        }

        /// <summary>
        /// 将32位无符号整数的值转换为b进制数等效字符串
        /// </summary>
        /// <param name="value"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public string UInt32SysConvert(uint value, int b)
        {
            return Convert.ToString(value, b);
        }

        /// <summary>
        /// 将64位带符号整数的值转换为b进制数等效字符串
        /// </summary>
        /// <param name="value"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public string LongSysConvert(long value, int b)
        {
            return Convert.ToString(value, b);
        }

        //public string ULongSysConvert(ulong value, int b)
        //{
        //    return Convert.ToString(value, b);
        //}

        //Convert.ToInt32(value, base)：将具有b进制数的字符串转换为int32位数值
        /// <summary>
        /// 将具有b进制数的字符串value转换为有符号8位数值
        /// </summary>
        /// <param name="value"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int SysConvertToSByte(string value, int b)
        {
            return Convert.ToSByte(value, b);
        }
        #endregion

        #region 位移操作符
        /// <summary>
        /// 16位二进制字符串位移操作
        /// </summary>
        /// <param name="shortBinStr"></param>
        /// <param name="bit"></param>
        /// <param name="left"></param>
        /// <returns></returns>
        public string ShortBinStrShiftOperation(string shortBinStr, byte bit, bool left)
        {
            short tmp1, tmp2;
            tmp1 = Convert.ToInt16(shortBinStr, 2);
            if (left)
            {
               tmp2 = (short)(tmp1 << bit);
            }
            else
            {
                tmp2 = (short)(tmp1 >> bit);
            }
            return $"{shortBinStr} {tmp1} ==> {Convert.ToString(tmp2, 2)} {tmp2}";
        }
        #endregion

        #endregion
    }
}
