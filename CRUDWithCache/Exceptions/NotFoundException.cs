using System.Net;

namespace CRUDWithCache.Exceptions
{
    public class NotFoundException : HttpResponseException
    {
        public NotFoundException(string errorCode, string errorMessage)
        {
            this.StatusCode = (int)HttpStatusCode.NotFound;
            this.Value = new ErrorBody(
                    (int)HttpStatusCode.NotFound,
                    errorCode,
                    errorMessage
                );
        }
    }
}
