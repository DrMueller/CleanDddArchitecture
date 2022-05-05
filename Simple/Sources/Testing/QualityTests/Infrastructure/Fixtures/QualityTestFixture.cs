using JetBrains.Annotations;
using Mmu.CleanDddSimple.QualityTests.Infrastructure.Startups;

namespace Mmu.CleanDddSimple.QualityTests.Infrastructure.Fixtures
{
    [UsedImplicitly]
    public class QualityTestFixture
    {
        public QualityTestFixture()
        {
            AppFactory = new QualityTestAppFactory();
        }

        internal QualityTestAppFactory AppFactory { get; }
    }
}