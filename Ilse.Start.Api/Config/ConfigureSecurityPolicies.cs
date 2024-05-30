namespace Ilse.Start.Api.Config;

internal static partial class Config
{
    public static void ConfigureSecurityPolicies(WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication().AddJwtBearer();
        builder.Services.AddAuthorization();

        builder.Services.AddAuthorizationBuilder()
            .AddPolicy(Policies.AllowAll, policy =>
                policy.RequireAssertion(c =>
                    c.User.HasClaim(Policies.AllowAll, "true")))
            .AddPolicy(Policies.TodoCreate, policy =>
                policy.RequireAssertion(c =>
                    c.User.HasClaim(Policies.TodoCreate, "true")))
            .AddPolicy(Policies.TodoRead, policy =>
                policy.RequireAssertion(c =>
                    c.User.HasClaim(Policies.TodoRead, "true") ||
                    c.User.IsInRole(Roles.Admin)))
            .AddPolicy(Policies.CategoryCreate, policy =>
                policy.RequireAssertion(c =>
                    c.User.HasClaim(Policies.CategoryCreate, "true")));

    }
}
