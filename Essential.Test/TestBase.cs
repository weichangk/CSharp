using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Essential.Test
{
    public class TestBase
    {
        protected readonly ITestOutputHelper Output;
        public TestBase(ITestOutputHelper output)
        {
            Output = output;
        }
    }
}
