using Xeptions;

namespace Sheenam.Core.Api.Models.Guests.Exceptions
{
    public class GuestServiceException : Xeption
    {
        public GuestServiceException(Xeption innerException)
            :base(message: "Guest service error occured. Please contact support",
                 innerException)
        { }
    }
}
