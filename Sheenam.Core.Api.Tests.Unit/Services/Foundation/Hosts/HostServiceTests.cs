// -------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------

using System.Linq.Expressions;
using Moq;
using Sheenam.Core.Api.Brokers.Loggings;
using Sheenam.Core.Api.Brokers.Storages;
using Sheenam.Core.Api.Models.Hosts;
using Sheenam.Core.Api.Services.Foundation.Hosts;
using Tynamix.ObjectFiller;
using Xeptions;

namespace Sheenam.Core.Api.Tests.Unit.Services.Foundation.Hosts
{
    public partial class HostServiceTests
    {
        private readonly IHostService hostService;
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;

        public HostServiceTests()
        {
            this.storageBrokerMock = new Mock<IStorageBroker>();
            this.loggingBrokerMock= new Mock<ILoggingBroker>();

            this.hostService =
                new HostService(
                    storageBroker: this.storageBrokerMock.Object,
                    loggingBroker: this.loggingBrokerMock.Object
                    );
        }

        private Expression<Func<Xeption, bool>> SameExceptionAs(Xeption expectedHostValidationException)
        {
            return actualException => actualException.SameExceptionAs(expectedHostValidationException);
        }

        private static Host CreateRandomHost() =>
            CreateHostFiller(date: CreateRandomDate()).Create();

        private static DateTimeOffset CreateRandomDate() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();
        private static Filler<Host> CreateHostFiller(DateTimeOffset date)
        {
            var filler = new Filler<Host>();

            filler.Setup().OnType<DateTimeOffset>().Use(date);

            return filler;
        }
    }
}
