using System;

namespace Essential.Test
{
    public class LongTimeFixture : IDisposable
    {
        public LongTimeTask Task { get; }
        public LongTimeFixture()
        {
            Task = new LongTimeTask();
        }
        public void Dispose()
        {
        }
    }
}
