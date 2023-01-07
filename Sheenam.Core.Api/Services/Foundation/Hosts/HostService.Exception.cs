// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------


using Sheenam.Core.Api.Models.Hosts.Exceptions;
using Xeptions;
using sheenam = Sheenam.Core.Api.Models.Hosts;

namespace Sheenam.Core.Api.Services.Foundation.Hosts
{
    public partial class HostService
    {
        private delegate ValueTask<sheenam.Host> ReturningHostFunction();

        private async ValueTask<sheenam.Host> TryCatch(ReturningHostFunction returningHostFunction)
        {
            try
            {
                return await returningHostFunction();
            }
            catch (NullHostException nullHostException)
            {
                throw CreateAndLogValidationException(nullHostException);
            }
        }

        private HostValidationException CreateAndLogValidationException(Xeption exception)
        {
            var hostValidationException = new HostValidationException(exception);
            this.loggingBroker.LogError(hostValidationException);

            return hostValidationException;
        }
    }
}
