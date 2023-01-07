// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using Sheenam.Core.Api.Models.Hosts.Exceptions;
using sheenam = Sheenam.Core.Api.Models.Hosts;

namespace Sheenam.Core.Api.Services.Foundation.Hosts
{
    public partial class HostService
    {
        private void ValidateHostOnAdd(sheenam.Host host)
        {
            ValidateHostNotNull(host);
        }

        private void ValidateHostNotNull(sheenam.Host host) 
        {
            if (host is null)
            {
                throw new NullHostException();
            }
        }
    }
}
