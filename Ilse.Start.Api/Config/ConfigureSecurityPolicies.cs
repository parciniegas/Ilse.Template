namespace Ilse.Start.Api.Config;

internal static partial class Config
{
    public static void ConfigureSecurityPolicies(WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication().AddJwtBearer();
        builder.Services.AddAuthorization();

        builder.Services.AddAuthorizationBuilder()
            .AddPolicy("todo.create", policy =>
                policy.RequireAssertion(c =>
                    c.User.HasClaim("catalog.guest", "true")));

    }
}
