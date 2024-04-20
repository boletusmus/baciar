using System.Data.Common;
using Npgsql;

namespace baciar.meta.Services.Impl;

public class SchemaReader : ISchemaReader
{
    private readonly NpgsqlDataSource dataSource;

    public SchemaReader(NpgsqlDataSource dataSource)
    {
        this.dataSource = dataSource;
    }

    public async Task<IEnumerable<string>> ReadAsync()
    {
        var result = new List<string>();
        var sql = "select schema_name from information_schema.schemata;";
        await using (var cmd = dataSource.CreateCommand(sql))
        await using (var reader = await cmd.ExecuteReaderAsync())
        {
            while(await reader.ReadAsync())
            {
                result.Add(reader.GetString(0));
            }
        }
        return result;
    }
}