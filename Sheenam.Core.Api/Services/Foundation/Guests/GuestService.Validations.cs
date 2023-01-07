// -------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using Sheenam.Core.Api.Models.Guests;
using Sheenam.Core.Api.Models.Guests.Exceptions;

namespace Sheenam.Core.Api.Services.Foundation.Guests
{
    public partial class GuestService
    {
        private void ValidateGuestOnAdd(Guest guest)
        {
            ValidateGuestNotNull(guest);

            Validate(
                (Rule: IsInvalid(guest.Id), Parameter: nameof(guest.Id)),
                (Rule: IsInvalid(guest.FirstName), Parameter: nameof(guest.FirstName)),
                (Rule: IsInvalid(guest.LastName), Parameter: nameof(guest.LastName)),
                (Rule: IsInvalid(guest.DateOfBirth), Parameter: nameof(guest.DateOfBirth)),
                (Rule: IsInvalid(guest.Address), Parameter: nameof(guest.Address)),
                (Rule: IsInvalid(guest.Email), Parameter: nameof(guest.Email)),
                (Rule: IsInvalid(guest.Gender), Parameter: nameof(guest.Gender))
                );
        }

        private void ValidateGuestNotNull(Guest guest)
        {
            if (guest is null)
            {
                throw new NullGuestException();
            }
        }

        static private dynamic IsInvalid(Guid id) => new
        {
            Condition = id == Guid.Empty,
            Message = "ID is required"
        };

        static private dynamic IsInvalid(string text) => new
        {
            Condition = string.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };

        static private dynamic IsInvalid(DateTimeOffset date) => new
        {
            Condition = date == default,
            Message = "Date is required"
        };

        static private dynamic IsInvalid(GenderType gender) => new
        {
            Condition = Enum.IsDefined(typeof(GenderType), gender) is false,
            Message = "Gender is invalid"
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidGuestException = new InvalidGuestException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidGuestException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidGuestException.ThrowIfContainsErrors();
        }
    }
}
