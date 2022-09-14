// -------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using Sheenam.Core.Api.Models.Foundation.Guests;
namespace Sheenam.Core.Api.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Guest> InsertGuestAsync(Guest guest);

    }
}