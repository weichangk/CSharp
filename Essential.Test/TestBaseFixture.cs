using System;
using Xunit;
using Xunit.Abstractions;

namespace Essential.Test
{
    public class TestBaseFixture : TestBase, IClassFixture<LongTimeFixture>, IDisposable
    {
        private readonly LongTimeTask _task;
        public TestBaseFixture(ITestOutputHelper output, LongTimeFixture fixture) : base(output)
        {
            _task = fixture.Task;//共享资源，只创建一次，防止运行每个测试方法调用构造函数重复创建资源。
        }
        public void Dispose()
        {
            Output.WriteLine("Dispose...");
        }
    }
}
