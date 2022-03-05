using System;
using System.Net;
using System.Net.Http;

namespace Sample.SecondService.HttpApiConnector.Exceptions
{
    public class SecondApiServiceException : HttpRequestException
    {
        public SecondApiServiceException(string message)
            : base(message)
        {
        }

        public SecondApiServiceException(string message,
            Exception inner,
            HttpStatusCode? statusCode)
            : base(message, inner, statusCode)
        {
        }
    }
}
