using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Essential.Test
{
    public class MethodsAndParametersTest : TestBaseFixture
    {
        private readonly MethodsAndParametersCls _methodsAndParametersCls;
        public MethodsAndParametersTest(ITestOutputHelper output, LongTimeFixture fixture) : base(output, fixture)
        {
            _methodsAndParametersCls = new MethodsAndParametersCls();
        }

        [Fact]
        public void UseTupleReturnMultiValue()
        {
            var result = _methodsAndParametersCls.UseTupleReturnMultiValue();
            Output.WriteLine($"My name is {result.FirstName}{result.LastName}. age is {result.Age}");
        }
    }
}
