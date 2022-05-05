using System;
using JetBrains.Annotations;
using Mmu.CleanDddSimple.Testing.Common.Areas.DependencyInjection;

namespace Mmu.CleanDddSimple.IntegrationTests.TestingInfrastructure.Fixtures
{
    [UsedImplicitly]
    public class IntegrationTestFixture
    {
        public IntegrationTestFixture()
        {
            ServiceProvider = TestContainerFactory.Create();
        }

        internal IServiceProvider ServiceProvider { get; }
    }
}