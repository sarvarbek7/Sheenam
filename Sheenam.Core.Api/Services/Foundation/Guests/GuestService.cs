// -------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using Sheenam.Core.Api.Brokers.Loggings;
using Sheenam.Core.Api.Brokers.Storages;
using Sheenam.Core.Api.Models.Foundation.Guests;
using Sheenam.Core.Api.Models.Foundation.Guests.Exceptions;

namespace Sheenam.Core.Api.Services.Foundation.Guests
{
    public class GuestService : IGuestService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public GuestService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker;
        }

        public GuestService(
            IStorageBroker storageBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public async ValueTask<Guest> AddGuestAsync(Guest guest)
        {
            try
            {
                if (guest is null)
                {
                    throw new NullGuestException();
                }

                return await this.storageBroker.InsertGuestAsync(guest);
            }
            catch(NullGuestException nullGuestException)
            {
                var guestValidationException = 
                    new GuestValidationException(nullGuestException);

                this.loggingBroker.LogError(guestValidationException);
                throw guestValidationException;
            }
        }
    }
}
