namespace N71BlogPost.Api.Configurations
{
    public static partial class HostConfigurations
    
    {
        public static ValueTask<WebApplicationBuilder> ConfigurAsync(this WebApplicationBuilder builder)
        {
            builder
                .AddDatabase()
                .AddInfrostructures()
                .AddDevTools();
            return new(builder);
            
        }
        public static ValueTask<WebApplication> ConfigureAsync(this WebApplication app) 
        {
            app.UseDevTools();
            return new(app);
        }
    }
}
