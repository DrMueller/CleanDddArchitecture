using System.Threading;
using System.Threading.Tasks;
using AutoMoqCore;
using FluentAssertions;
using Mmu.CleanDddSimple.Application.UseCases.AddParticipant;
using Mmu.CleanDddSimple.CrossCutting.Errors;
using Mmu.CleanDddSimple.CrossCutting.LanguageExtensions.Types.Maybes;
using Mmu.CleanDddSimple.CrossCutting.LanguageExtensions.Types.Maybes.Implementation;
using Mmu.CleanDddSimple.Domain.Data.Repositories;
using Mmu.CleanDddSimple.Domain.Errors;
using Mmu.CleanDddSimple.Domain.Models;
using Mmu.CleanDddSimple.UnitTests.TestingInfrastructure.Mocks;
using Moq;
using Xunit;

namespace Mmu.CleanDddSimple.UnitTests.TestingAreas.Application.UseCases.AddParticipant
{
    public class AddParticipantCommandHandlerUnitTests
    {
        private readonly AddParticipantCommandHandler _sut;
        private readonly UnitOfWorkFactoryMock _uowFactoryMock;
        private readonly Mock<IMeetingRepository> _meetingRepoMock;

        public AddParticipantCommandHandlerUnitTests()
        {
            var moqer = new AutoMoqer();
            _uowFactoryMock = new UnitOfWorkFactoryMock();
            moqer.SetInstance(_uowFactoryMock.Object);
            _meetingRepoMock = _uowFactoryMock.RegisterRepositoryMock<IMeetingRepository>();
            _meetingRepoMock.Setup(
                    f => f.LoadSingleAsync(
                        It.IsAny<long>()))
                .ReturnsAsync(Maybe.CreateNone<IMeeting>());

            _sut = moqer.Create<AddParticipantCommandHandler>();
        }

        [Fact]
        public async Task Handling_AppendingNotWorking_ReturnsError()
        {
            // Arrange
            var meetingMock = new Mock<IMeeting>();
            var error = new GenericServerError("Test1234");

            _meetingRepoMock.Setup(
                    f => f.LoadSingleAsync(
                        It.IsAny<long>()))
                .ReturnsAsync(Maybe.CreateSome(meetingMock.Object));

            meetingMock
                .Setup(f => f.AddParticipant(It.IsAny<string>()))
                .Returns(error);

            // Act
            var actualResult = await _sut.Handle(new AddParticipantCommand(5, "Tra"), CancellationToken.None);

            // Assert
            actualResult.Should().BeOfType<Some<ServerError>>();
            var actualError = (GenericServerError)actualResult.ReduceThrow();
            actualError.ErrorMessage.Should().Be(error.ErrorMessage);
            _uowFactoryMock.UnitOfWorkMock.Verify(f => f.SaveAsync(), Times.Never);
        }

        [Fact]
        public async Task Handling_EverythingWorking_ReturnsSuccess()
        {
            // Arrange
            var meetingMock = new Mock<IMeeting>();

            _meetingRepoMock.Setup(
                    f => f.LoadSingleAsync(
                        It.IsAny<long>()))
                .ReturnsAsync(Maybe.CreateSome(meetingMock.Object));

            meetingMock
                .Setup(f => f.AddParticipant(It.IsAny<string>()))
                .Returns(new Participant("Tra"));

            // Act
            var actualResult = await _sut.Handle(new AddParticipantCommand(5, "Tra"), CancellationToken.None);

            // Assert
            actualResult.Should().BeOfType<None<ServerError>>();
        }

        [Fact]
        public async Task Handling_EverythingWorking_Saves()
        {
            // Arrange
            var meetingMock = new Mock<IMeeting>();

            _meetingRepoMock.Setup(
                    f => f.LoadSingleAsync(
                        It.IsAny<long>()))
                .ReturnsAsync(Maybe.CreateSome(meetingMock.Object));

            meetingMock
                .Setup(f => f.AddParticipant(It.IsAny<string>()))
                .Returns(new Participant("Tra"));

            // Act
            await _sut.Handle(new AddParticipantCommand(5, "Tra"), CancellationToken.None);

            // Assert
            _uowFactoryMock.UnitOfWorkMock.Verify(f => f.SaveAsync(), Times.Once);
        }

        [Fact]
        public async Task Handling_MeetingNotExisting_ReturnsError()
        {
            // Act
            var actualResult = await _sut.Handle(new AddParticipantCommand(5, "Tra"), CancellationToken.None);

            // Assert
            actualResult.Should().BeOfType<Some<ServerError>>();
            var actualError = actualResult.ReduceThrow();
            actualError.Should().BeOfType<AggregateNotExistingError<IMeeting>>();
            _uowFactoryMock.UnitOfWorkMock.Verify(f => f.SaveAsync(), Times.Never);
        }
    }
}