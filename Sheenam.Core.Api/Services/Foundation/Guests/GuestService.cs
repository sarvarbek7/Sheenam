// -------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using Sheenam.Core.Api.Brokers.Storages;
using Sheenam.Core.Api.Models.Foundation.Guests;

namespace Sheenam.Core.Api.Services.Foundation.Guests
{
    public class GuestService : IGuestService
    {
        private readonly IStorageBroker storageBroker;

        public GuestService(IStorageBroker storageBroker) =>
            this.storageBroker = storageBroker;

        public async ValueTask<Guest> AddGuestAsync(Guest guest) =>
            await this.storageBroker.InsertGuestAsync(guest);
    }
}
