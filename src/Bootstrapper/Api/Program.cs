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


// Common Services : Carter, MediatR, Fluent Validation
var catalogAssembly = typeof(CatalogModule).Assembly;
var basketAssembly = typeof(BasketModule).Assembly;

builder.Services
    .AddCarterWithAssemblies(
        catalogAssembly,
        basketAssembly
    );

builder.Services
    .AddMediatRWithAssemblies(
        catalogAssembly,
        basketAssembly
    );

builder.Services.AddStackExchangeRedisCache(opt =>
    {
        opt.Configuration = builder.Configuration.GetConnectionString("Redis");
    }); 

//builder.Services.AddMediatR(config =>
//{
//    config.RegisterServicesFromAssemblies(
//        catalogAssembly, 
//        basketAssembly
//    );

//    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
//    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
//});

//builder.Services.AddValidatorsFromAssemblies([catalogAssembly, basketAssembly]);

// Module Services : Catalog, Basket, Ordering
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
