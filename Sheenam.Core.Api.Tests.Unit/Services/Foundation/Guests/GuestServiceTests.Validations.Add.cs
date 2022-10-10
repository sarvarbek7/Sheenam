// -------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------
using Sheenam.Core.Api.Models.Foundation.Guests;
using Sheenam.Core.Api.Services.Foundation.Guests.Exceptions;
using Xunit;

namespace Sheenam.Core.Api.Tests.Unit.Services.Foundation.Guests
{
    public partial class GuestServiceTests
    {
        [Fact]
        public async void ShouldThrowValidationExceptionOnRegisterWhenStudentIsNullAndLogItAsync()
        {
            // given
            Guest nullGuest = null;
            var nullGuestException = new NullGuestException();

            var expectedGuestValidationException =
                new GuestValidationException(nullGuestException);

            // when
            ValueTask<Guest> addGuestTask =
                this.guestService.AddGuestAsync(nullGuest);

            // then
            await Assert.ThrowsAsync<GuestValidationException>(() =>
            addGuestTask.AsTask());
        }
    }
}
