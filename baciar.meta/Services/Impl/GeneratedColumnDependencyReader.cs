using System.Data.Common;
using baciar.meta.Model;
using Npgsql;

namespace baciar.meta.Services.Impl;
public class GeneratedColumnDependencyReader : IGeneratedColumnDependencyReader
{
    private readonly NpgsqlDataSource dataSource;
    private readonly BaseReader<GeneratedColumnDependencyItem> reader;

    public GeneratedColumnDependencyReader(NpgsqlDataSource dataSource)
    {
        this.dataSource = dataSource;
        reader = new BaseReader<GeneratedColumnDependencyItem>();
    }
    public async Task<IEnumerable<GeneratedColumnDependencyItem>> ReadAsync(string[] schemas)
    {
        return await reader.ReadAsync(
            dataSource, 
            schemas, 
            (name)=>$"select table_schema,table_name,column_name,dependent_column from information_schema.column_column_usage where table_schema='{name}';",
            (DbDataReader reader)=>reader.ReadGeneratedColumnDependencyItem()
            );
    }
}