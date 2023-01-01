using Xeptions;

namespace Sheenam.Core.Api.Models.Guests.Exceptions
{
    public class FailedGuestStorageException : Xeption
    {
        public FailedGuestStorageException(Exception innerException)
            :base(message: "Failed guest error occured, contact support")
        { }
    }
}
