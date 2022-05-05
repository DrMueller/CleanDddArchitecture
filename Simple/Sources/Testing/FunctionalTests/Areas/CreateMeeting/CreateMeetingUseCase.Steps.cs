using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Mmu.CleanDddSimple.Areas.Application.Dtos;
using Mmu.CleanDddSimple.Areas.Application.UseCases.CreateMeeting;
using Mmu.CleanDddSimple.Areas.Domain.Models;
using Mmu.CleanDddSimple.Areas.Web.Dtos;
using Mmu.CleanDddSimple.FunctionalTests.Infrastructure.ApiCommunication.Models;
using Mmu.CleanDddSimple.FunctionalTests.Infrastructure.Fixtures;

namespace Mmu.CleanDddSimple.FunctionalTests.Areas.CreateMeeting
{
    public partial class CreateMeetingUseCase : WebApiTestBase
    {
        private readonly CreateMeetingRequestDto _requestDto;
        private ApiResult _apiResult = null!;

        public CreateMeetingUseCase(WebApiTestFixture fixture)
            : base(fixture)
        {
            _requestDto = new CreateMeetingRequestDto
            {
                Description = "Description4321",
                MeetingType = MeetingTypeDto.Long,
                Name = "Name1234"
            };
        }

        private Task Then_the_creation_succeeded()
        {
            _apiResult.Response.EnsureSuccessStatusCode();

            return Task.CompletedTask;
        }

        private async Task Then_the_meeting_is_created()
        {
            var dto = await _apiResult.ReadContentAsync<MeetingCreatedResultDto>();

            var actualMeeting = await AggregateLoader.LoadAsync<IMeeting>(dto.MeetingId);

            actualMeeting.MeetingType.Should().Be((MeetingType)_requestDto.MeetingType);
            actualMeeting.Name.Should().Be(_requestDto.Name);
            actualMeeting.Description.Should().Be(_requestDto.Description);
            actualMeeting.Agenda.Should().NotBeNull();
            actualMeeting.Participants.Should().BeEmpty();
        }

        private async Task Then_the_response_contains_the_meeting_id()
        {
            var dto = await _apiResult.ReadContentAsync<MeetingCreatedResultDto>();
            dto.Should().NotBeNull();
            dto.MeetingId.Should().NotBe(0);
        }

        private async Task When_a_meeting_is_created()
        {
            _apiResult = await SendAsync(HttpMethod.Post, "api/meetings", _requestDto);
        }
    }
}