using Xeptions;

namespace Sheenam.Core.Api.Models.Guests.Exceptions
{
    public class AlreadyExistGuestException : Xeption
    {
        public AlreadyExistGuestException(Exception innerException)
            : base(message: "Guest with same id already exists", innerException)
        {}
    }
}
