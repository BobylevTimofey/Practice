namespace Practice.Middleware.RequestCounter
{
    public class RequestCounter
    {
        private int currentCount = 0;
        private readonly int maxCount;

        public RequestCounter(int maxCount)
        {
            this.maxCount = maxCount;
        }

        public bool CanHandleRequest()
        {
            lock (this)
            {
                return currentCount < maxCount;
            }
        }

        public void Increment()
        {
            lock (this)
            {
                currentCount++;
            }
        }

        public void Decrement()
        {
            lock (this)
            {
                currentCount--;
            }
        }
    }
}
