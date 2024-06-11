using Microsoft.Extensions.Configuration;
using Npgsql;
using baciar.meta.Services.Impl;

var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(AppContext.BaseDirectory))
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile("appsettings.Development.json", optional: true);
var configuration = builder.Build();

var postgresConnectionString = configuration.GetConnectionString("DatabaseConnection") ?? "";
//var postgresConnectionString = configuration.GetConnectionString("AddressConnection") ?? "";

//System.Console.WriteLine($"Connection string: {postgresConnectionString}");

var dataSourceBuilder = new NpgsqlDataSourceBuilder(postgresConnectionString);
var dataSource = dataSourceBuilder.Build();

var schemaReader = new SchemaReader(dataSource);
var allSchemas = await schemaReader.ReadAsync();
foreach(var item in allSchemas)
{
    System.Console.WriteLine($"{item}");
}
string[] schemas = ["finance","loca"];
//var serverVersion = new ServerVersion(dataSource);
var tableReader = new TableReader(dataSource);
var viewReader = new ViewReader(dataSource);
//var version = await serverVersion.VersionAsync();
//System.Console.WriteLine(version);
var tables = await tableReader.ReadAsync(schemas);
foreach(var item in tables)
{
    System.Console.WriteLine($"{item.schema}.{item.name}");
}
var views = await viewReader.ReadAsync(schemas);
foreach(var item in views)
{
    System.Console.WriteLine($"{item.schema}.{item.name}: {item.definition}");
}
var checkConstraintReader = new CheckConstraintReader(dataSource);
var checks = await checkConstraintReader.ReadAsync(schemas);
foreach(var item in checks)
{
    System.Console.WriteLine($"{item.schema}.{item.name}: {item.definition}");
}
var generatedColumnDependencyReader = new GeneratedColumnDependencyReader(dataSource);
var generatedColumns = await generatedColumnDependencyReader.ReadAsync(schemas);
foreach(var item in generatedColumns)
{
    System.Console.WriteLine($"{item.schema}.{item.name}: {item.columnName} - {item.generatedColumnName}");
}
var columnPrivilegesReader = new ColumnPrivilegesReader(dataSource);
var columnPrivileges = await columnPrivilegesReader.ReadAsync(schemas);
foreach(var item in columnPrivileges)
{
    System.Console.WriteLine($"{item.schema}.{item.name}.{item.columnName} - {item.privilige} for {item.grantee}");
}
var columnReader = new ColumnReader(dataSource);
var columns = await columnReader.ReadAsync(schemas);
foreach(var item in columns)
{
    System.Console.WriteLine($"{item.schema}.{item.name}.{item.columnName} - {item.dataType} ");
}