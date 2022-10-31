using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.HttpOverrides;
using OrdersManager.API.Extensions;
using OrdersManager.CQRS;
using OrdersManager.CQRS.Queries.Feedbacks;

var builder = WebApplication.CreateBuilder(args);

if (args.Length != 0)
{
    int firstIp = int.Parse($"5{args[0]}");
    int secondIp = int.Parse($"7{args[0]}");

    builder.WebHost.ConfigureKestrel(options =>
    {
        options.ListenAnyIP(firstIp);
        options.ListenAnyIP(secondIp, configure => configure.UseHttps());
    });
}

builder.Services.ConfigureMessageBroker(builder.Configuration);

builder.Services.ConfigureDbServices();

//builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddMediatR(typeof(GetAllFeedbacksQuery).Assembly);

builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = true;
    config.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson();

builder.Services.ConfigureConstants(builder.Configuration);

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureSqlContext(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper autoMapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(autoMapper);

var app = builder.Build();

app.ConfigureExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
