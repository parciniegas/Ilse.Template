namespace Ilse.Start.Api.Config;

internal static partial class Config
{
    public static void ConfigureSecurityPolicies(WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication().AddJwtBearer();
        builder.Services.AddAuthorization();

        builder.Services.AddAuthorizationBuilder()
            .AddPolicy(Policies.TodoCreate, policy =>
                policy.RequireAssertion(c =>
                    c.User.HasClaim(Policies.TodoCreate, "true")));

    }
}
