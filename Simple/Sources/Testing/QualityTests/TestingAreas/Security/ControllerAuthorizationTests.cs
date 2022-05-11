using System;
using System.Linq;
using FluentAssertions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Mmu.CleanDddSimple.QualityTests.Infrastructure.Fixtures;
using Xunit;

namespace Mmu.CleanDddSimple.QualityTests.TestingAreas.Security
{
    public class ControllerAuthorizationTests : QualityTestBase
    {
        public ControllerAuthorizationTests(QualityTestFixture fixture)
            : base(fixture)
        {
        }

        [Fact]
        public void Actions_AreAuthorized()
        {
            var authorizedAttrType = typeof(AuthorizeAttribute);

            var actionDescriptorsProvider = AppFactory.Services.GetRequiredService<IActionDescriptorCollectionProvider>();

            var controllerDescriptors = actionDescriptorsProvider.ActionDescriptors.Items.OfType<ControllerActionDescriptor>();

            foreach (var actDesc in controllerDescriptors)
            {
                var endpointAttributes = actDesc.EndpointMetadata.OfType<Attribute>().ToList();

                endpointAttributes.Should().ContainSingle(attr => attr.GetType() == authorizedAttrType, $"Endpoint {actDesc.ControllerTypeInfo.Name} does not contain AuthorizeAttribute");
            }
        }
    }
}