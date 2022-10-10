// -------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------
using Xeptions;
namespace Sheenam.Core.Api.Services.Foundation.Guests.Exceptions
{
    public class NullGuestException : Xeption
    {
        public NullGuestException()
            : base(message: "Guest is null")
        {}
    }
}
