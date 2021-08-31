using Xunit;
using Xunit.Abstractions;

namespace Essential.Test
{

    public class EnumTest : TestBaseFixture
    {
        private readonly EnumCls _enumCls;
        public EnumTest(ITestOutputHelper output, LongTimeFixture fixture) : base(output, fixture)
        {
            _enumCls = new EnumCls();
        }

        [Fact]
        public void Test()
        {
            var result1 = _enumCls.T1();
            Output.WriteLine(result1);
            var result2 = _enumCls.T2();
            Output.WriteLine(result2.ToString());
            var result3 = _enumCls.T3();
            Output.WriteLine(result3.ToString());
        }

    } 


}