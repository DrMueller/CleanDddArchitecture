using System;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Mmu.CleanDdd.QualityTests.Infrastructure.Fixtures.WebAppTests.WebApp
{
    internal class TestAuthenticationHandler : AuthenticationHandler<TestAuthenticationOptions>
    {
        public const string TestSchemeName = "Test Scheme";

        public TestAuthenticationHandler(
            IOptionsMonitor<TestAuthenticationOptions> options, ILoggerFactory logger,
            UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var authenticationTicket = new AuthenticationTicket(
                new ClaimsPrincipal(Options.Identity),
                new AuthenticationProperties(),
                "Test Scheme");

            return Task.FromResult(AuthenticateResult.Success(authenticationTicket));
        }
    }

    public static class TestAuthenticationExtensions
    {
        public static void AddTestAuth(this AuthenticationBuilder builder, Action<TestAuthenticationOptions> configureOptions)
        {
            builder.AddScheme<TestAuthenticationOptions, TestAuthenticationHandler>(TestAuthenticationHandler.TestSchemeName, "Test Auth", configureOptions);
            builder.AddScheme<TestAuthenticationOptions, TestAuthenticationHandler>("BasicAuthentication", configureOptions);
            builder.AddScheme<TestAuthenticationOptions, TestAuthenticationHandler>("Bearer", configureOptions);
        }
    }

    public class TestAuthenticationOptions : AuthenticationSchemeOptions
    {
        public ClaimsIdentity Identity { get; } = new ClaimsIdentity(
            new[]
            {
                new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", Guid.NewGuid().ToString()),
            },
            "test");
    }
}
