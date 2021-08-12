using Xunit;
using Xunit.Abstractions;

namespace Essential.Test
{
    public class TupleTest : TestBase
    {
        public TupleTest(ITestOutputHelper output): base(output)
        {          
        }

        [Fact]
        public void T1_T9()
        {
            var test = new TupleCls();
            var result = test.T1();
            Output.WriteLine(result);
            result = test.T2();
            Output.WriteLine(result);
            result = test.T3();
            Output.WriteLine(result);
            result = test.T4();
            Output.WriteLine(result);
            result = test.T5();
            Output.WriteLine(result);
            result = test.T6();
            Output.WriteLine(result);
            result = test.T7();
            Output.WriteLine(result);
            result = test.T8();
            Output.WriteLine(result);
            result = test.T9();
            Output.WriteLine(result);
        }

        [Fact]
        public void T10()
        {
            var test = new TupleCls();
            var result = test.T10();
            Output.WriteLine(result);
        }

        [Fact]
        public void T11()
        {
            var test = new TupleCls();
            var result = test.T11();
            Output.WriteLine(result);
        }

        [Fact]
        public void T12()
        {
            var test = new TupleCls();
            var result = test.T12();
            Output.WriteLine(result);
        }

        [Fact]
        public void T13()
        {
            var test = new TupleCls();
            var result = test.T13();
            Output.WriteLine(result);
        }

        [Fact]
        public void T14()
        {
            var test = new TupleCls();
            var result = test.T14();
            Output.WriteLine(result);
        }

        [Fact]
        public void T15()
        {
            var test = new TupleCls();
            var result = test.T15();
            Output.WriteLine(result);
        }

        [Fact]
        public void T16()
        {
            var test = new TupleCls();
            var result = test.T16();
            Output.WriteLine(result);
        }
    }
}
