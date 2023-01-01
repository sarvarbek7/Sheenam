using Xeptions;

namespace Sheenam.Core.Api.Models.Guests.Exceptions
{
    public class FailedGuestServiceException : Xeption
    {
        public FailedGuestServiceException(Exception innerException)
            :base(message: "Service failed. Please contact support",
                 innerException)
        { }
    }
}
