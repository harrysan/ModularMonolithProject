var builder = WebApplication.CreateBuilder(args);

// Add Services to the container
// -----Service Section Start--------- //

//builder.Services.AddCarter(configurator: config =>
//{
//    var catalogModules = typeof(CatalogModule).Assembly.GetTypes()
//    .Where(t => t.IsAssignableFrom(typeof(ICarterModule))).ToArray();

//    config.WithModules(catalogModules);
//});

builder.Host.UseSerilog((context, config) =>
    config.ReadFrom.Configuration(context.Configuration));

builder.Services
    .AddCarterWithAssemblies(typeof(CatalogModule).Assembly);

// Add services to the Container.
builder.Services
    .AddCatalogModule(builder.Configuration)
    .AddBasketModule(builder.Configuration)
    .AddOrderingModule(builder.Configuration)
    .AddAccountModule(builder.Configuration);

builder.Services
    .AddExceptionHandler<CustomExceptionHandler>();

// -----Service Section End--------- //

// -----Build Section Start--------- //
var app = builder.Build();

// Configure the HTTP Request Pipeline.

app.MapCarter();
app.UseSerilogRequestLogging();
app.UseExceptionHandler(options => { });

app
    .UseCatalogModule()
    .UseBasketModule()
    .UseOrderingModule()
    .UseAccountModule();

// -----Build Section End--------- //

app.Run();
