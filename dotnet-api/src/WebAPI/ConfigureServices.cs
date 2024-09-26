using NSwag;
using NSwag.Generation.Processors.Security;

namespace WebAPI;

public static class ConfigureServices
{
    public static IServiceCollection AddWebAPIServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpContextAccessor();

        // Allow all origin since it will be web service
        services.AddCors(options =>
        {
            options.AddPolicy(
                name: "CorsPolicy",
                policy =>
                {
                    policy.AllowAnyOrigin();
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                });
        });
        
        services.AddOpenApiDocument(options =>
        {
            options.PostProcess = document =>
            {
                document.Info = new OpenApiInfo
                {
                    Title = "Cerxos Web API",
                    Version = "v1",
                    Description = "Cerxos Web API is a web api for Akmal Personal App",
                    TermsOfService = "https://example.com/terms",
                    Contact = new OpenApiContact
                    {
                        Name = "Nur Akmal Bin Jalil",
                        Email = "nurakmaljalil91@gmail.com",
                        Url = "https://nurakmaljalil.com/"
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Example License",
                        Url = "https://example.com/license"
                    }
                };
            };

            // Add JWT token authorization
            options.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
            {
                Type = OpenApiSecuritySchemeType.ApiKey,
                Name = "Authorization",
                In = OpenApiSecurityApiKeyLocation.Header,
                Description = "Type into the text box: Bearer {your JWT token}."
            });

            options.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
        });
        return services;
    }
}