// -------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------


using Microsoft.Data.SqlClient;
using Sheenam.Core.Api.Models.Guests;
using Sheenam.Core.Api.Models.Guests.Exceptions;
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
            catch (InvalidGuestException invalidGuestException)
            {
                throw CreateAndLogValidationException(invalidGuestException);
            }
            catch (SqlException sqlException)
            {
                var failedGuestStorageException =
                    new FailedGuestStorageException(sqlException);

                throw CreateAndLogDependencyException(failedGuestStorageException);
            }
        }
        
        private GuestValidationException CreateAndLogValidationException(Xeption exception)
        {
            var guestValidationException = new GuestValidationException(exception);
            this.loggingBroker.LogError(guestValidationException);
            
            return guestValidationException;
        }

        private GuestDependencyException CreateAndLogDependencyException(Xeption exception) 
        {
            var guestDependencyException = new GuestDependencyException(exception);
            this.loggingBroker.LogCritical(guestDependencyException);

            return guestDependencyException;
        }
    }
}
