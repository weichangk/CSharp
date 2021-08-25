using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Essential.Test
{
    public class InheritanceTest : TestBaseFixture
    {
        private readonly InheritanceCls _inheritanceCls;
        public InheritanceTest(ITestOutputHelper output, LongTimeFixture fixture) : base(output, fixture)
        {
            _inheritanceCls = new InheritanceCls();
        }

        [Fact]
        public void OverridePropertyTest()
        {
;           var result = _inheritanceCls.OverridePropertyTest();
            Output.WriteLine(result);
        }
        [Fact]
        public void OverridePropertyTest1()
        {
            var result = _inheritanceCls.OverridePropertyTest1();
            Output.WriteLine(result);
        }
        
        [Fact]
        public void OverrideFuncTest()
        {
            var result = _inheritanceCls.OverrideFuncTest();
            Output.WriteLine(result);
        }

        [Fact]
        public void NewKeyWordTest()
        {
            var result = _inheritanceCls.NewKeyWordTest();
            Output.WriteLine(result);
        }
        [Fact]
        public void NewKeyWordTest1()
        {
            var result = _inheritanceCls.NewKeyWordTest1();
            Output.WriteLine(result);
        }
    }
}
