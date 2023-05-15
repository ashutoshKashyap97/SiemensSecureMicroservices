using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;

namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "siemensWorksClient",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = {"siemensWorksAPI"}
                },
                new Client
                {
                    ClientId = "siemensWorks_mvc_client",
                    ClientName = "Work MVC web app",
                    AllowedGrantTypes= GrantTypes.Code,
                    AllowRememberConsent = false,
                    RedirectUris = new List<string>()
                    {
                        "https://localhost:5002/signin-oidc"
                    },
                    PostLogoutRedirectUris = new List<string>()
                    {
                        "https://localhost:5002/signout-callback-oidc"
                    },
                    ClientSecrets = new List<Secret>()
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = new List<string>()
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                }
            };
        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("siemensWorksAPI", "SiemensWorks API")
            };
        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
            };
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        public static List<TestUser> TestUsers =>
            new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "5BE86359-073C-434B-AD2D-A3932222DABE",
                    Username = "ashu",
                    Password = "1234",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.GivenName, "Ashu"),
                        new Claim(JwtClaimTypes.FamilyName, "Kashyap")
                    }
                },
                new TestUser
                {
                    SubjectId = "5BE86359-073C-434B-AD2D-A3932222DABA",
                    Username = "Rohan",
                    Password = "1234",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.GivenName, "Rohan"),
                        new Claim(JwtClaimTypes.FamilyName, "Shetti")
                    }
                }
            };

    }
}
