namespace Essential.Test
{
    public class LongTimeTask
    {
        public LongTimeTask()
        {
            System.Threading.Thread.Sleep(2000);
        }
    }
}
