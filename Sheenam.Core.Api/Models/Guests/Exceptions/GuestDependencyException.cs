using Xeptions;

namespace Sheenam.Core.Api.Models.Guests.Exceptions
{
    public class GuestDependencyException : Xeption
    {
        public GuestDependencyException(Xeption innerException)
            :base(message: "Guest dependency error occured, contact support")
        { }
    }
}
