// -------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using Moq;
using Sheenam.Core.Api.Models.Hosts;
using Sheenam.Core.Api.Models.Hosts.Exceptions;
using Xunit;

namespace Sheenam.Core.Api.Tests.Unit.Services.Foundation.Hosts
{
    public partial class HostServiceTests
    {
        [Fact]
        public async void ShouldThrowHostValidationExceptionOnAddWhenHostIsNullAndLogItAsync()
        {
            // given
            Host noHost = null;
            var nullHostException = new NullHostException();

            var expectedHostValidationException =
                new HostValidationException(nullHostException);

            // when
            ValueTask<Host> addHostTask = 
                this.hostService.AddHostAsync(noHost);

            // then
            await Assert.ThrowsAsync<HostValidationException>(() => 
                addHostTask.AsTask());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(expectedHostValidationException))),
                Times.Once);

            this.storageBrokerMock.Verify(broker => 
                broker.InsertHostAsync(It.IsAny<Host>()), Times.Never);

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();

        }
    }
}
