using System;
using Xunit;
using Xunit.Abstractions;

namespace Essential.Test
{
    public class DynamicTest : TestBaseFixture
    {
        private readonly DynamicCls _dynamicCls;
        public DynamicTest(ITestOutputHelper output, LongTimeFixture fixture) : base(output, fixture)
        {
            _dynamicCls = new DynamicCls();
        }

        [Fact]
        public void T1()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => { _dynamicCls.T1(); });
            Output.WriteLine(ex.Message);
        }
    }
}
