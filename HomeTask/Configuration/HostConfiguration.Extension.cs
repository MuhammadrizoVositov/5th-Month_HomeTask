using HomeTask.Application;
using HomeTask.Infrostructure;
using HomeTask.Persistance.DataAccess;
using HomeTask.Persistance.Intercetor;
using HomeTask.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HomeTask.Configuration;

public static partial class HostConfiguration
{
    private static WebApplicationBuilder AddInfratructures(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IUserService, UserService>()
            .AddScoped<IBookRepository, BookRepository>()
            .AddScoped<IBookService, BookService>();
        return builder;
    }

    private static WebApplicationBuilder AddPersistense(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<CreateAuditableInterceptor>();
        builder.Services.AddDbContext<AppDbContext>((provider, option) =>
        {
            option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            option.AddInterceptors(provider.CreateScope().ServiceProvider
                .GetRequiredService<CreateAuditableInterceptor>());
        });
        return builder;
    }

    private static WebApplicationBuilder AddExposer(this WebApplicationBuilder builder)
    {
        builder.Services.AddRouting(rout => rout.LowercaseUrls = true);
        builder.Services.AddControllers();
        return builder;
    }

    private static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddSwaggerGen()
            .AddEndpointsApiExplorer();
        return builder;
    }

    private static WebApplication UseDevTools(this WebApplication app)
    {
        app
            .UseSwagger()
            .UseSwaggerUI();
        return app;
    }

    private static WebApplication UseExposer(this WebApplication app)
    {
        app.MapControllers();
        return app;
    }
}
