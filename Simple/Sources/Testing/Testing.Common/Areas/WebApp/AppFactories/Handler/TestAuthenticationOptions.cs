using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace Mmu.CleanDddSimple.Testing.Common.Areas.WebApp.AppFactories.Handler
{
    public class TestAuthenticationOptions : AuthenticationSchemeOptions
    {
        public ClaimsIdentity Identity { get; } = new(
            new[]
            {
                new Claim("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", Guid.NewGuid().ToString()),
            },
            "test");
    }
}