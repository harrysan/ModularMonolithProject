var builder = WebApplication.CreateBuilder(args);

// Add Services to the container

//builder.Services.AddCarter(configurator: config =>
//{
//    var catalogModules = typeof(CatalogModule).Assembly.GetTypes()
//    .Where(t => t.IsAssignableFrom(typeof(ICarterModule))).ToArray();

//    config.WithModules(catalogModules);
//});

builder.Services
    .AddCarterWithAssemblies(typeof(CatalogModule).Assembly);

// Add services to the Container.
builder.Services
    .AddCatalogModule(builder.Configuration)
    .AddBasketModule(builder.Configuration)
    .AddOrderingModule(builder.Configuration)
    .AddAccountModule(builder.Configuration);

var app = builder.Build();

// Configure the HTTP Request Pipeline.

app.MapCarter();

app
    .UseCatalogModule()
    .UseBasketModule()
    .UseOrderingModule()
    .UseAccountModule();


app.Run();
