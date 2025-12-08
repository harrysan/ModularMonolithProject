var builder = WebApplication.CreateBuilder(args);

// Add services to the Container.

var app = builder.Build();

// Configure the HTTP Request Pipeline.

app.Run();
