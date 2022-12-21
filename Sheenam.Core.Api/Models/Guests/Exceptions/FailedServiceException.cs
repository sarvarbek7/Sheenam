using Xeptions;

namespace Sheenam.Core.Api.Models.Guests.Exceptions
{
    public class FailedServiceException : Xeption
    {
        public FailedServiceException(Exception innerException)
            :base(message: "Service failed. Please contact support",
                 innerException)
        { }
    }
}
