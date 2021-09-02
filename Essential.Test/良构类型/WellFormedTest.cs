using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Essential.Test
{
    public class WellFormedTest : TestBaseFixture
    {
        readonly WellFormedCls _wellFormedCls;

        public WellFormedTest(ITestOutputHelper output, LongTimeFixture fixture) : base(output, fixture)
        {
            _wellFormedCls = new WellFormedCls();
        }

        [Fact]
        public void ToStringTest()
        {
            var result = _wellFormedCls.ToString();
            Output.WriteLine(result);
        }

        [Fact]
        public void StringEqualsTest()
        {
            var result = _wellFormedCls.StringEqualsTest();
            Output.WriteLine(result);
        }

        [Fact]
        public void ValueTypeOverrideEqualsTest()
        {
            var result = _wellFormedCls.ValueTypeOverrideEqualsTest();
            Output.WriteLine(result);
        }

        [Fact]
        public void VirtualEqualsTest()
        {
            var result = _wellFormedCls.VirtualEqualsTest();
            Output.WriteLine(result);
        }
        [Fact]
        public void VirtualEqualsTest1()
        {
            var result = _wellFormedCls.VirtualEqualsTest1();
            Output.WriteLine(result);
        }
        [Fact]
        public void OverrideEqualsTest()
        {
            var result = _wellFormedCls.OverrideEqualsTest();
            Output.WriteLine(result);
        }
        [Fact]
        public void OverrideEqualsTest1()
        {
            var result = _wellFormedCls.OverrideEqualsTest1();
            Output.WriteLine(result);
        }

        [Fact]
        public void OperatorTest()
        {
            var result = _wellFormedCls.OperatorTest();
            Output.WriteLine(result);
        }
    }
}
