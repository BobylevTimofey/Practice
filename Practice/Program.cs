using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Practice.Interfaces;
using Practice.Services;
using Practice.Services.AdditionalInfoServices;
using Practice.Services.AdditionalInfoServices.Sortings;
using Practice.Services.AdditionalInfoServices.Sortings.TreeSort;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Practice in Maxim Technology",
        Description = "An ASP.NET Core Web API for string processing",
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
builder.Services.AddTransient<StringProcessingService>();
builder.Services.AddTransient<AggregatorAdditionalInformationServices>();
builder.Services.AddTransient<IValidator<string>, OnlyEnglishLettersValidator>();
builder.Services.AddTransient<IAdditionalInfoService, SymbolCountingService>();
builder.Services.AddTransient<IAdditionalInfoService, FindSubstringService>();
builder.Services.AddTransient<IAdditionalInfoService, SortingService>();
builder.Services.AddTransient<IAdditionalInfoService, SymbolRemoveService>();
builder.Services.AddTransient<ISorter<char>, QuickSort<char>>();
builder.Services.AddTransient<ISorter<char>, TreeSort<char>>();
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
