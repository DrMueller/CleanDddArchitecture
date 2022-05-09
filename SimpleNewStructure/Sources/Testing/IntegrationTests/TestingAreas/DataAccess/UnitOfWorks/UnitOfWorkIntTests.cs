using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Mmu.CleanDddSimple.CrossCutting.LanguageExtensions.Types.Maybes;
using Mmu.CleanDddSimple.Domain.Data.Repositories;
using Mmu.CleanDddSimple.Domain.Data.UnitOfWorks;
using Mmu.CleanDddSimple.Domain.Models;
using Mmu.CleanDddSimple.IntegrationTests.TestingInfrastructure.Fixtures;
using Xunit;

namespace Mmu.CleanDddSimple.IntegrationTests.TestingAreas.DataAccess.UnitOfWorks
{
    public class UnitOfWorkIntTests : IntegrationTestBase
    {
        private readonly IUnitOfWork _sut;

        public UnitOfWorkIntTests(IntegrationTestFixture fixture) : base(fixture)
        {
            _sut = fixture.ServiceProvider.GetRequiredService<IUnitOfWorkFactory>().Create();
        }

        [Fact]
        public async Task Saving_SetsInsertAndUpdateFields()
        {
            // Arrange
            var meeting = new Meeting("Tra", "Tra", MeetingType.Long);
            var meetingRepo = _sut.GetRepository<IMeetingRepository>();
            await meetingRepo.InsertAsync(meeting);

            // Act
            await _sut.SaveAsync();

            // Assert
            var maybeMeeting = await meetingRepo.LoadSingleAsync(meeting.Id);
            var actualMeeting = (Meeting)maybeMeeting.ReduceThrow();

            actualMeeting.UpdatedDate.Should().NotBe(default);
            actualMeeting.CreatedDate.Should().NotBe(default);
        }
    }
}