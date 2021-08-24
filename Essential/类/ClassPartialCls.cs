using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essential
{
    public partial class ClassCls
    {
        public void Show()
        {
            PartialFunc();
        }

        //声明分部方法
        partial void PartialFunc();
    }
}
