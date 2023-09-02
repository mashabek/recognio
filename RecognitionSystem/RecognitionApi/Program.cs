using ApplicationCore;
using ApplicationCore.Persistance;
using Microsoft.AspNetCore.Identity;
using RecognitionApi.Features.Recognitions;
using RecognitionApi.Features.Users;
using RecognitionCore.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorizationBuilder();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationCore(builder.Configuration);
builder.Services.AddApiVersioning(
        options =>
        {
            // reporting api versions will return the headers
            // "api-supported-versions" and "api-deprecated-versions"
            options.ReportApiVersions = true;
        })
    .AddApiExplorer();
//to allow communication from simple blazor web app
string? origins = "origins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(origins,
        policy =>
        {
            policy.WithOrigins("http://localhost:7284")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});
builder.Services.AddIdentityCore<User>().AddEntityFrameworkStores<AppDbContext>().AddApiEndpoints();

var app = builder.Build();
app.UseCors(origins);
app.MapIdentityApi<User>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
        options =>
        {
            foreach (var description in app.DescribeApiVersions())
            {
                options.SwaggerEndpoint(
                    $"/swagger/{description.GroupName}/swagger.json",
                    description.GroupName);
            }
        });

    // Initialise and seed database
    using (var scope = app.Services.CreateScope())
    {
        var initialiser = scope.ServiceProvider.GetRequiredService<AppDbContextInitialiser>();
        await initialiser.InitialiseAsync();
        await initialiser.SeedDataAsync();
    }
}

app.UseHttpsRedirection();
var recognitionsGroup = app.MapGroup("/recognitions");
recognitionsGroup.MapRecognitionsApi();

var usersGroup = app.MapGroup("/users");
usersGroup.MapUsersApi();

app.Run();