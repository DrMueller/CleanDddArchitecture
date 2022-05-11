using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Mmu.CleanDddSimple.CrossCutting.LanguageExtensions.Types.Maybes;
using Mmu.CleanDddSimple.CrossCutting.LanguageExtensions.Types.Maybes.Implementation;
using Mmu.CleanDddSimple.DataAccess.DbContexts.Contexts;
using Mmu.CleanDddSimple.DataAccess.DbContexts.Factories;
using Mmu.CleanDddSimple.DataAccess.Repositories.Implementation.Base;
using Mmu.CleanDddSimple.Domain.Models;
using Mmu.CleanDddSimple.IntegrationTests.TestingInfrastructure.Fixtures;
using Xunit;

namespace Mmu.CleanDddSimple.IntegrationTests.TestingAreas.DataAccess.Repositories
{
    public class RepositoryBaseIntTests : IntegrationTestBase
    {
        private readonly IAppDbContext _appDbContext;
        private readonly RepositoryMock _sut;

        public RepositoryBaseIntTests(IntegrationTestFixture fixture) : base(fixture)
        {
            var appDbContextFactory = ServiceProvider.GetRequiredService<IAppDbContextFactory>();
            _appDbContext = appDbContextFactory.Create();

            _sut = new RepositoryMock();
            var baseRepo = (IRepositoryBase)_sut;
            baseRepo.Initialize(_appDbContext);
        }

        [Fact]
        public async Task Deleting_AggregateExisting_DeletesAggregate()
        {
            // Arrange
            var meeting = new Meeting("Tra", "Tra", MeetingType.Long);

            await _sut.InsertAsync(meeting);
            await _appDbContext.SaveChangesAsync();

            // Act
            await _sut.DeleteAsync(meeting.Id);
            await _appDbContext.SaveChangesAsync();

            // Assert
            var persistedMeeting = _appDbContext.DbSet<Meeting>().AsNoTracking().SingleOrDefault(f => f.Id == meeting.Id);
            persistedMeeting.Should().BeNull();
        }

        [Fact]
        public async Task Inserting_InsertsAggregate()
        {
            // Arrange
            var meeting = new Meeting("Tra", "Tra", MeetingType.Long);

            // Act
            await _sut.InsertAsync(meeting);
            await _appDbContext.SaveChangesAsync();

            // Assert
            var actualMeeting = _appDbContext.DbSet<Meeting>().AsQueryable().Single();
            actualMeeting.Should().Be(meeting);
        }

        [Fact]
        public async Task Loading_AddsIncludes()
        {
            // Act
            // Arrange
            var meeting = new Meeting("Tra", "Tra", MeetingType.Long);

            await _sut.InsertAsync(meeting);
            await _appDbContext.SaveChangesAsync();

            // Act
            await _sut.LoadSingleAsync(meeting.Id);

            // Assert
            _sut.IncludesWereInitialized.Should().BeTrue();
        }

        [Fact]
        public async Task LoadingSCollection_AppliesSpecFilter()
        {
            // Arrange
            var spec = new RepoSpecMock();

            // Act
            await _sut.LoadCollectionAsync(spec);

            // Assert
            spec.FilterWasApplied.Should().BeTrue();
        }

        [Fact]
        public async Task LoadingSingleById_AggregateExisting_Returnsggregate()
        {
            // Arrange
            var meeting = new Meeting("Tra", "Tra", MeetingType.Long);

            await _sut.InsertAsync(meeting);
            await _appDbContext.SaveChangesAsync();

            // Act
            var actualMeetingMaybe = await _sut.LoadSingleAsync(meeting.Id);

            // Assert
            actualMeetingMaybe.Should().BeOfType<Some<IMeeting>>();
            var actualMeeting = actualMeetingMaybe.ReduceThrow();
            actualMeeting.Should().Be(meeting);
        }

        [Fact]
        public async Task LoadingSingleById_AggregateNotExisting_ReturnsNone()
        {
            // Act
            var actualMeetingMaybe = await _sut.LoadSingleAsync(1234);

            // Assert
            actualMeetingMaybe.Should().BeOfType<None<IMeeting>>();
        }

        [Fact]
        public async Task LoadingSingleBySpecification_AppliesSpecFilter()
        {
            // Arrange
            var spec = new RepoSpecMock();

            // Act
            await _sut.LoadSingleAsync(spec);

            // Assert
            spec.FilterWasApplied.Should().BeTrue();
        }
    }
}