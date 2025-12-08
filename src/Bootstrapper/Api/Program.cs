var builder = WebApplication.CreateBuilder(args);

// Add services to the Container.
builder.Services
    .AddCatalogModule(builder.Configuration)
    .AddBasketModule(builder.Configuration)
    .AddOrderingModule(builder.Configuration)
    .AddAccountModule(builder.Configuration);

var app = builder.Build();

// Configure the HTTP Request Pipeline.
app
    .UseCatalogModule()
    .UseBasketModule()
    .UseOrderingModule()
    .UseAccountModule();


app.Run();
