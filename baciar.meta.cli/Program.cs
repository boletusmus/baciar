using Microsoft.Extensions.Configuration;
using Npgsql;
using baciar.meta.Services.Impl;

var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(AppContext.BaseDirectory))
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile("appsettings.Development.json", optional: true);
var configuration = builder.Build();

var postgresConnectionString = configuration.GetConnectionString("DatabaseConnection") ?? "";

System.Console.WriteLine($"Connection string: {postgresConnectionString}");

var dataSourceBuilder = new NpgsqlDataSourceBuilder(postgresConnectionString);
var dataSource = dataSourceBuilder.Build();

string[] schemas = ["meter","public"];
var tableGenerator = new TableGenerator(dataSource);
var viewGenerator = new ViewGenerator(dataSource);
var tables = await tableGenerator.GenerateAsync(schemas);
foreach(var item in tables)
{
    //System.Console.WriteLine($"{item.schema}.{item.name}");
}
var views = await viewGenerator.GenerateAsync(schemas);
foreach(var item in views)
{
    System.Console.WriteLine($"{item.schema}.{item.name}: {item.definition}");
}
