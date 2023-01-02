// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using sheenam = Sheenam.Core.Api.Models.Hosts;

namespace Sheenam.Core.Api.Brokers.Storages
{
    public partial class StorageBroker
    {
        DbSet<sheenam.Host> Hosts { get; set; }

        public async ValueTask<sheenam.Host> InsertHostAsync(sheenam.Host host)
        {
            using var broker = new StorageBroker(this.configuration);

            EntityEntry<sheenam.Host> hostEntity =
                await broker.AddAsync(host);

            await broker.SaveChangesAsync();

            return hostEntity.Entity;
        }
    }
}
