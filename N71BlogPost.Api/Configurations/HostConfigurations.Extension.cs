using Microsoft.EntityFrameworkCore;
using N71BlogPost.Application.Services;
using N71BlogPost.Infrastructure.Services;
using N71BlogPost.Persistence.DataAccess;
using N71BlogPost.Persistence.Repositories.BlogRepository;
using N71BlogPost.Persistence.Repositories.CommentRepository;
using N71BlogPost.Persistence.Repositories.UserRepository;

namespace N71BlogPost.Api.Configurations
{
    public static partial class HostConfigurations

    {

        private static WebApplicationBuilder AddInfrostructures(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddScoped<IUserService, UserService>()
                .AddScoped<IBlogService, BlogService>()
                .AddScoped<ICommentService, CommentService>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<ICommentRepository, CommentRepository>()
                .AddScoped<IBlogRepository, BlogPostRepository>();
                
                
            return builder;
        }
        private static WebApplicationBuilder AddDatabase(this WebApplicationBuilder builder  )
        {
            builder.Services.AddDbContext<AppDbContext>(option => 
            option.UseNpgsql(builder.Configuration.GetConnectionString("DefoultConnection"))); 

            return builder;
        }
        private static  WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddControllers();

            return builder;
        }


        private static WebApplication UseDevTools(this WebApplication app) 
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.MapControllers();

            return app;

        }

    }
}
