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
    }
}
