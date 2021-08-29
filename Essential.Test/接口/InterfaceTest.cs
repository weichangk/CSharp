using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Essential.Test
{
    public class InterfaceTest : TestBaseFixture
    {
        private readonly InterfaceCls _InterfaceCls;
        public InterfaceTest(ITestOutputHelper output, LongTimeFixture fixture) : base(output, fixture)
        {
            _InterfaceCls = new InterfaceCls();
        }

        [Fact]
        public void InterfaceClsTest()
        {
            var result = _InterfaceCls.InterfaceClsTest();
            Output.WriteLine(result);
        }
    }


}
