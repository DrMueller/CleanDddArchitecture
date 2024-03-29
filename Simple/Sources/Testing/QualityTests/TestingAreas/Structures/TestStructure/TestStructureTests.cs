﻿using Mmu.CleanDddSimple.DatabaseTests.TestingAreas.Application.UseCases.CreateMeeting;
using Mmu.CleanDddSimple.UnitTests.TestingAreas.Application.UseCases.LoadAgendaOverview;
using Xunit;

namespace Mmu.CleanDddSimple.QualityTests.TestingAreas.Structures.TestStructure
{
    public partial class TestStructureTests
    {
        [Fact]
        public void DatabaseTestNameSpaces_MatchServiceNameSpaces()
        {
            AssertTestStructure(
                "DbTests",
                typeof(CreateMeetingCommandHandlerDbTests).Assembly);
        }

        [Fact]
        public void UnitTestNameSpaces_MatchServiceNameSpaces()
        {
            AssertTestStructure(
                "UnitTests",
                typeof(AgendaOverviewSpecUnitTests).Assembly);
        }
    }
}