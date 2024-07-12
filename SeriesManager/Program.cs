using Microsoft.AspNetCore.Mvc;
using SerieManager.Shared.Data.BD;
using SeriesManager.EndPoints;
using SeriesManager_Console;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(
    options => 
    options
    .SerializerOptions
    .ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<SerieManagerContext>();
builder.Services.AddTransient<DAL<Serie>>();
builder.Services.AddTransient<DAL<Episode>>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.AddEndPointsSerie();
app.AddEndPointsEpisode();
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
