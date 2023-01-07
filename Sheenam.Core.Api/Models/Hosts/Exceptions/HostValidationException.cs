// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using Xeptions;

namespace Sheenam.Core.Api.Models.Hosts.Exceptions
{
    public class HostValidationException : Xeption
    {
        public HostValidationException(Xeption innerException)
            : base(message: "Host validation exception occured. Fix it and try again",
                  innerException) { }
    }
}
