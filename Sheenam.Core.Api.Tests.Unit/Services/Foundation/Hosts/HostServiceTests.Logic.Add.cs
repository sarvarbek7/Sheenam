// -------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Sheenam.Core.Api.Models.Hosts;
using Xunit;

namespace Sheenam.Core.Api.Tests.Unit.Services.Foundation.Hosts
{
    public partial class HostServiceTests
    {
        [Fact]
        public async Task ShouldAddHostAsync()
        {
            // given
            Host randomHost = CreateRandomHost();
            Host inputHost = randomHost;
            Host returningHost = inputHost;
            Host expectedHost = returningHost.DeepClone();

            this.storageBrokerMock.Setup(broker =>
            broker.InsertHostAsync(randomHost))
                .ReturnsAsync(randomHost);
                
            // when
            Host actualHost = 
                await this.hostService.AddHostAsync(inputHost);

            // then
            actualHost.Should().BeEquivalentTo(expectedHost);

            this.storageBrokerMock.Verify(broker =>
            broker.InsertHostAsync(inputHost), Times.Once);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
