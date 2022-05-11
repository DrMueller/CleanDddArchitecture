using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Mmu.CleanDddSimple.Areas.Application.Dtos;
using Mmu.CleanDddSimple.Areas.Application.UseCases.CreateMeeting;
using Mmu.CleanDddSimple.Areas.Domain.Models;
using Mmu.CleanDddSimple.Infrastructure.CrossCutting.LanguageExtensions.Types.Eithers;
using Xunit;

namespace Mmu.CleanDddSimple.DatabaseTests.TestingAreas.Areas.Application.UseCases.CreateMeeting
{
    public partial class CreateMeetingCommandHandlerDbTests
    {
        [Fact]
        public async Task CreatingMeeting_CreatesMeeting()
        {
            // Arrange
            var command = new CreateMeetingCommand(
                "Name",
                "Desc",
                MeetingTypeDto.Long);

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