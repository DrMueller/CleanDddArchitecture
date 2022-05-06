using System;
using Microsoft.AspNetCore.Authentication;

namespace Mmu.CleanDddSimple.Testing.Common.Areas.WebApp.AppFactories.Handler
{
    public static class TestAuthenticationExtensions
    {
        public static void AddTestAuth(this AuthenticationBuilder builder, Action<TestAuthenticationOptions> configureOptions)
        {
            builder.AddScheme<TestAuthenticationOptions, TestAuthenticationHandler>(TestAuthenticationHandler.TestSchemeName, "Test Auth", configureOptions);
            builder.AddScheme<TestAuthenticationOptions, TestAuthenticationHandler>("BasicAuthentication", configureOptions);
            builder.AddScheme<TestAuthenticationOptions, TestAuthenticationHandler>("Bearer", configureOptions);
        }
    }
}
