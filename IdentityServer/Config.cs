using Duende.IdentityServer.Models;

namespace IdentityServer;

public static class Config
{
  public static IEnumerable<IdentityResource> IdentityResources =>
    new IdentityResource[]
    {
      new IdentityResources.OpenId()
    };

  public static IEnumerable<ApiScope> ApiScopes =>
    new ApiScope[]{
      new ApiScope("web-api", "Web API")
    };

  public static IEnumerable<Client> Clients =>
    new List<Client>
    {
      new Client
      {
        ClientId = "web-client",

        // no interactive user, use the clientid/secret for authentication
        AllowedGrantTypes = GrantTypes.ClientCredentials,

        // secret for authentication
        ClientSecrets =
        {
          new Secret("secret".Sha256())
        },

        // scopes that client has access to
        AllowedScopes = { "web-api" }
      }
    };
}
