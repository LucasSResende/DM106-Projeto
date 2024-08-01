using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SerieManager.EndPoints;
using SerieManager.Shared.Data.BD;
using SerieManager.Shared.Data.Models;
using SeriesManager.EndPoints;
using SeriesManager_Console;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(
    options =>
    options
    .SerializerOptions
    .ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services
    .AddIdentityApiEndpoints<AccessUser>()
    .AddEntityFrameworkStores<SerieManagerContext>();

builder.Services.AddAuthorization();

builder.Services.AddDbContext<SerieManagerContext>();
builder.Services.AddTransient<DAL<Serie>>();
builder.Services.AddTransient<DAL<Episode>>();
builder.Services.AddTransient<DAL<Platform>>();
builder.Services.AddTransient<DAL<Country>>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseAuthorization();

app.AddEndPointsSerie();
app.AddEndPointsEpisode();
app.AddEndPointsPlatform();
app.AddEndPointsCountry();

app.MapGroup("auth").MapIdentityApi<AccessUser>()
    .WithTags("Authorization");

app.MapPost("auth/logout", async ([FromServices] SignInManager<AccessUser> signInManager) =>
{
    await signInManager.SignOutAsync();
    return Results.Ok();
}).RequireAuthorization().WithTags("Authorization");

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
