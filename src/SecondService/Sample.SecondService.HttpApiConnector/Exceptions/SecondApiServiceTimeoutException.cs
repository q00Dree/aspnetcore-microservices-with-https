namespace Sample.SecondService.HttpApiConnector.Exceptions
{
    public class SecondApiServiceTimeoutException : SecondApiServiceException
    {
        public SecondApiServiceTimeoutException(string message)
            : base(message)
        {
        }
    }
}
