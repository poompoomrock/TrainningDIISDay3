using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace PersonApp.Client.Helpers
{
    public class DummyAuthenticationStateProvider : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("key1", "value1"));
            claims.Add(new Claim("StaffID", "002541"));
            claims.Add(new Claim(ClaimTypes.Name, "Panuwat"));
            claims.Add(new Claim(ClaimTypes.Role, "Admin"));

            var identity = new ClaimsIdentity(claims, "test");
            //var identity = new ClaimsIdentity();

            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity)));
        }
    }
}
