using N71BlogPost.Api.Configurations;

var builder = WebApplication.CreateBuilder(args);
await builder.ConfigurAsync();

var app = builder.Build();

await app.ConfigureAsync();

app.Run();
