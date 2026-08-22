using Autofac;
using Autofac.Extensions.DependencyInjection;
using Electrobombas.Api.Middlewares;
using Electrobombas.Application.Cores.Contexts;
using Electrobombas.Infraestructure.Cores.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Route Options
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;

});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Infrastructure
builder.Services.addInfrastructureServices(builder.Configuration);


// Applications
builder.Services.AddApplicationServices();

// Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(options =>
    {
        options.RegisterModule(new InfrastructureAutofacModule());
        options.RegisterModule(new ApplicationAutofacModule());
    });

// API
builder.Services.AddTransient<ExceptionMiddleware>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Electrobombas.Api v1");
        c.RoutePrefix = "swagger"; // opcional, pero así será /swagger en PROD
    });
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseCors(options =>
{
    options.AllowAnyHeader()
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .Build();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
