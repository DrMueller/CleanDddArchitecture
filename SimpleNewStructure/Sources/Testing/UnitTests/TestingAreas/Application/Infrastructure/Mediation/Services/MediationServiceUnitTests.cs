using System.Threading;
using System.Threading.Tasks;
using AutoMoqCore;
using MediatR;
using Mmu.CleanDddSimple.Application.Areas.Mediation.Models;
using Mmu.CleanDddSimple.Application.Infrastructure.Mediation.Services.Implementation;
using Moq;
using Xunit;

namespace Mmu.CleanDddSimple.UnitTests.TestingAreas.Application.Infrastructure.Mediation.Services
{
    public class MediationServiceUnitTests
    {
        private readonly MediationService _sut;
        private readonly Mock<IMediator> _mediatorMock;

        public MediationServiceUnitTests()
        {
            var moqer = new AutoMoqer();
            _sut = moqer.Create<MediationService>();
            _mediatorMock = moqer.GetMock<IMediator>();

            _mediatorMock
                .Setup(f => f.Send(It.IsAny<IRequest<Unit>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Unit.Value);
        }

        [Fact]
        public async Task SendingCommand_SendsCommand()
        {
            // Arrange
            var command = Mock.Of<ICommand>();

            // Act
            await _sut.SendAsync(command);

            // Assert
            _mediatorMock.Verify(f => f.Send(command, It.IsAny<CancellationToken>()));
        }

        [Fact]
        public async Task SendingCommandWithResultSendsCommand()
        {
            // Arrange
            var command = Mock.Of<ICommand<object>>();

            // Act
            await _sut.SendAsync(command);

            // Assert
            _mediatorMock.Verify(f => f.Send(command, It.IsAny<CancellationToken>()));
        }

        [Fact]
        public async Task SendinQuery_SendsCommand()
        {
            // Arrange
            var query = Mock.Of<IQuery<object>>();

            // Act
            await _sut.SendAsync(query);

            // Assert
            _mediatorMock.Verify(f => f.Send(query, It.IsAny<CancellationToken>()));
        }
    }
}