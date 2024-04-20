using System.Data.Common;
using baciar.meta.Model;
using Npgsql;

namespace baciar.meta.Services.Impl;
public class TableReader : ITableReader
{
    private readonly NpgsqlDataSource dataSource;
    private readonly BaseReader<TableItem> reader;

    public TableReader(NpgsqlDataSource dataSource)
    {
        this.dataSource = dataSource;
        reader = new BaseReader<TableItem>();
    }
    public async Task<IEnumerable<TableItem>> ReadAsync(string[] schemas)
    {
        return await reader.ReadAsync(
            dataSource, 
            schemas, 
            (name)=>$"select table_schema,table_name from information_schema.tables where table_schema='{name}';",
            (DbDataReader reader)=>reader.ReadTableItem()
            );
    }
}