// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using Sheenam.Core.Api.Brokers.Loggings;
using Sheenam.Core.Api.Brokers.Storages;
using sheenam = Sheenam.Core.Api.Models.Hosts;

namespace Sheenam.Core.Api.Services.Foundation.Hosts
{
    public class HostService : IHostService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public HostService(IStorageBroker storageBroker, ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public async ValueTask<sheenam.Host> AddHostAsync(sheenam.Host host)
        {
            sheenam.Host returninghost = await this.storageBroker.InsertHostAsync(host);
            return returninghost;
        }
    }
}
