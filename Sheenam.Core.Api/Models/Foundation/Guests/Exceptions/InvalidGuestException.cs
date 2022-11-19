using Xeptions;

namespace Sheenam.Core.Api.Models.Foundation.Guests.Exceptions
{
    public class InvalidGuestException :Xeption
    {
        public InvalidGuestException()
            :base("Guest is invalid")
        { }
    }
}
