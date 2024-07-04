using TalentTracker.Shared.Extensions;
using TalentTracker.Shared.Middlewares;
using TalentTracker.Api.DependencyResolution;
using TalentTracker.Web.DependencyResolution;
using MediatR;
using TalentTracker.Shared.Application.Behaviors;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatrBehaviours();
builder.Services.AddApplicationCORS(builder.Configuration);

builder.Services.AddTalentTrackerApplication(builder.Configuration)
    .AddWeb(builder.Environment, builder.Configuration)
    .AddMediatR(typeof(Program).Assembly)
    .AddAutoMapper(typeof(Program).Assembly)
    .AddMemoryCache();

builder.Services.AddSwaggerGen(_ =>
{
    _.AddApplicationSwaggerGen(builder.Configuration);
    _.AddTalentTrackerSwaggerGen();

    //Prevent collision
    _.CustomSchemaIds(x => x.FullName);

    // Set the comments path for the Swagger JSON and UI.
    var xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly).ToList();
    xmlFiles.ForEach(xmlFile => _.IncludeXmlComments(xmlFile));
});

var app = builder.Build();

app.UseTalentTrackerSwagger(builder.Configuration, builder.Environment, endpoints =>
{
    endpoints.UseTalentTrackerSwaggerEndpoints();
});

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseApplicationCORS();
app.MapControllers();

app.MapSwagger();

app.Run();
