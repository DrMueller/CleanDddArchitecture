using System.Linq;
using FluentAssertions;
using Mmu.CleanDddSimple.Areas.Domain.Models;
using Mmu.CleanDddSimple.UnitTests.TestingInfrastructure.ConstructorTesting.Services;
using Xunit;

namespace Mmu.CleanDddSimple.UnitTests.TestingAreas.Areas.Domain.Models
{
    public class MeetingUnitTests
    {
        [Fact]
        public void AddingParticipant_AddsParticipant()
        {
            // Arrange
            var sut = new Meeting("Tra", "Tra", MeetingType.Long);
            const string ParticipantName = "Name1";

            // Act
            sut.AddParticipant(ParticipantName);

            // Assert
            sut.Participants.Count.Should().Be(1);
            sut.Participants.Single().Name.Should().Be(ParticipantName);
        }

        [Fact]
        public void Constructor_MapsProperties()
        {
            const string Name = "Name1234";
            const string Description = "Description4321";
            const MeetingType MeetingType = MeetingType.Long;

            ConstructorTestBuilderFactory.Constructing<Meeting>()
                .UsingDefaultConstructor()
                .WithArgumentValues(Name, Description, MeetingType)
                .Maps()
                .ToProperty(f => f.Description).WithValue(Description)
                .ToProperty(f => f.Name).WithValue(Name)
                .ToProperty(f => f.MeetingType).WithValue(MeetingType)
                .BuildMaps()
                .Assert();
        }

        [Fact]
        public void Constructor_ValuesNotSet_Fails()
        {
            ConstructorTestBuilderFactory.Constructing<Meeting>()
                .UsingDefaultConstructor()
                .WithArgumentValues("name", null, MeetingType.Long)
                .Fails()
                .WithArgumentValues(null, "Desc", MeetingType.Long)
                .Fails()
                .Assert();
        }
    }
}