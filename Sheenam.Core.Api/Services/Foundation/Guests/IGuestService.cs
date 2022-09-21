// -------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using Sheenam.Core.Api.Models.Foundation.Guests;

namespace Sheenam.Core.Api.Services.Foundation.Guests
{
    public interface IGuestService
    {
        public ValueTask<Guest> AddGuestAsync(Guest guest);

    }
}
