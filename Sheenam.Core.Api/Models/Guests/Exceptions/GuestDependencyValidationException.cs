using Xeptions;

namespace Sheenam.Core.Api.Models.Guests.Exceptions
{
    public class GuestDependencyValidationException : Xeption
    {
        public GuestDependencyValidationException(Xeption innerException)
            :base(message: "Guest dependency validation error occurred, please try again",
                 innerException)
        {}
    }
}
