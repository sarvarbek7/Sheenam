// -------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------


using Sheenam.Core.Api.Models.Foundation.Guests;
using Sheenam.Core.Api.Models.Foundation.Guests.Exceptions;
using Xeptions;

namespace Sheenam.Core.Api.Services.Foundation.Guests
{
    public partial class GuestService
    {
        private delegate ValueTask<Guest> ReturningGuestFunction();
        private async ValueTask<Guest> TryCatch(ReturningGuestFunction returningGuestFunction)
        {
            try
            {
                return await returningGuestFunction();
            }
            
            catch (NullGuestException nullGuestException)
            {
                
                throw CreateAndLogValidationException(nullGuestException);
            }
        }

        private GuestValidationException CreateAndLogValidationException(Xeption exception)
        {
            var guestValidationException =
                    new GuestValidationException(exception);

            this.loggingBroker.LogError(guestValidationException);
            
            return guestValidationException;
        }
    }
}
