using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Essential.Test
{
    public class GenericTest : TestBase
    {
        public GenericTest(ITestOutputHelper output) : base(output)
        {
            
        }

        [Fact]
        public void GenericClsTest()
        {
            GenericCls.Test();
        }
    }
}
