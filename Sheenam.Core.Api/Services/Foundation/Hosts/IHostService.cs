﻿// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using sheenam = Sheenam.Core.Api.Models.Hosts;

namespace Sheenam.Core.Api.Services.Foundation.Hosts
{
    public interface IHostService
    {
        ValueTask<sheenam.Host> AddHostAsync(sheenam.Host host);
    }
}
