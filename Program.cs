using System;

using PlantRecommender.Services;

var builder = WebApplication.CreateBuilder(args);//voor config voor starten v.d. app

builder.Services.AddControllers();//we gebruiken controllers
builder.Services.AddSingleton<RecommenderService>();//dependency injection -> checken (singleton zorgt dat zelfde blijft gebruiken zolang app draait)

var app = builder.Build();//effectief builden wat je geconfiged hebt hiervoor

app.MapControllers();//maakt endpoints effectief beschikbaar

app.Run();//webserver starten -> dan http://localhost:5281/api/recommendations/easy