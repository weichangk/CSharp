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
    }
}
