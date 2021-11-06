using System.Reflection;
using Mmu.CleanDdd.QualityTests.Infrastructure;
using Mmu.CleanDdd.QualityTests.Infrastructure.Fixtures.AssemblyTests;
using Mmu.CleanDdd.WebApi;
using Xunit;

namespace Mmu.CleanDdd.QualityTests.Areas.AssemblyDependencies
{
    public class WebApiDependenciesTests : AssemblyTestBase
    {
        private static readonly Assembly _sutAssembly = typeof(Startup).Assembly;

        public WebApiDependenciesTests(AssemblyTestFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public void WebApi_DoesHaveDependencies_ToModuleApplications()
        {
            AssemblyReferenceAsserter.AssertAssemblyContainsReferences(
                _sutAssembly,
                Constants.Namespaces.Modules.Individuals.Application,
                Constants.Namespaces.Modules.Meetings.Application);
        }

        [Fact]
        public void WebApi_DoesHaveDependency_ToDependencies()
        {
            AssemblyReferenceAsserter.AssertAssemblyContainsReferences(_sutAssembly, Constants.Namespaces.Dependencies);
        }

        [Fact]
        public void WebApi_DoesNotHaveDependencies_ToInternalModuleAssemblies()
        {
            AssemblyReferenceAsserter.AssertAssemblyDoesNotContainsReferences(
                _sutAssembly,
                Constants.Namespaces.Modules.Individuals.Domain,
                Constants.Namespaces.Modules.Individuals.DomainShell,
                Constants.Namespaces.Modules.Individuals.IntegrationEvents,
                Constants.Namespaces.Modules.Individuals.ApplicationShell,
                Constants.Namespaces.Modules.Meetings.Domain,
                Constants.Namespaces.Modules.Meetings.Domain,
                Constants.Namespaces.Modules.Meetings.DomainShell,
                Constants.Namespaces.Modules.Meetings.IntegrationEvents,
                Constants.Namespaces.Modules.Meetings.ApplicationShell,
                Constants.Namespaces.Modules.Meetings.Domain);
        }

        [Fact]
        public void WebApi_DoesNotHaveDependencies_ToSharedKernel()
        {
            AssemblyReferenceAsserter.AssertAssemblyDoesNotContainsReferences(
                _sutAssembly,
                Constants.Namespaces.SharedKernel.All);
        }
    }
}