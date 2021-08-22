using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Essential.Test
{
    public class ClassTest: TestBaseFixture
    {
        private readonly ClassCls _classCls;
        public ClassTest(ITestOutputHelper output, LongTimeFixture fixture) : base(output, fixture)
        {
            _classCls = new ClassCls();
        }


        [Fact]
        public void DeconstructTest()
        {
            ClassCls _classCls1 = new ClassCls("foo", "bar");

            (string firstName, string lastName) = _classCls1;
            Output.WriteLine($"{firstName}{lastName}");

            _classCls1.FirstName = "foo1";
            (string firstName1, string lastName1, int age) = _classCls1;
            Output.WriteLine($"{firstName1}{lastName1} {age}");

            (int nextId, _, _, _) = _classCls1;
            Output.WriteLine($"{nextId}");
        }

    }
}
