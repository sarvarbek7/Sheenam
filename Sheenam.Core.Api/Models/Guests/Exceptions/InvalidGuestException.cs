using Xeptions;

namespace Sheenam.Core.Api.Models.Guests.Exceptions
{
    public class InvalidGuestException : Xeption
    {
        public InvalidGuestException()
            : base("Guest is invalid") { }
    }
}
