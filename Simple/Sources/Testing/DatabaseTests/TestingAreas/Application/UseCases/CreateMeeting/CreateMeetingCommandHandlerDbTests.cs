using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Mmu.CleanDddSimple.Application.UseCases.CreateMeeting;
using Mmu.CleanDddSimple.CrossCutting.LanguageExtensions.Types.Eithers;
using Mmu.CleanDddSimple.Domain.Models;
using Xunit;

namespace Mmu.CleanDddSimple.DatabaseTests.TestingAreas.Application.UseCases.CreateMeeting
{
    public partial class CreateMeetingCommandHandlerDbTests
    {
        [Fact]
        public async Task CreatingMeeting_CreatesMeeting()
        {
            // Arrange
            var command = new Fixture().Create<CreateMeetingCommand>();

            // Act
            var result = await _sut.Handle(command, CancellationToken.None);

            // Assert
            var actualMeetingDto = result.ReduceRightThrow();
            var actualMeeting = await AggregateLoader.LoadAsync<IMeeting>(actualMeetingDto.MeetingId);

            actualMeeting.Agenda.Should().NotBeNull();
            actualMeeting.Description.Should().Be(command.Description);
            actualMeeting.Id.Should().Be(actualMeetingDto.MeetingId);
            actualMeeting.Name.Should().Be(command.Name);
            actualMeeting.Participants.Should().BeEmpty();
        }
    }
}