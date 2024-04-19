using System.Data.Common;
using baciar.meta.Model;
using Npgsql;

namespace baciar.meta.Services.Impl;
public class TableGenerator : ITableGenerator
{
    private readonly NpgsqlDataSource dataSource;
    private readonly BaseGenerator<TableItem> generator;

    public TableGenerator(NpgsqlDataSource dataSource)
    {
        this.dataSource = dataSource;
        generator = new BaseGenerator<TableItem>();
    }
    public async Task<IEnumerable<TableItem>> GenerateAsync(string[] schemas)
    {
        return await generator.GenerateAsync(
            dataSource, 
            schemas, 
            (name)=>$"select table_schema,table_name from information_schema.tables where table_schema='{name}';",
            (DbDataReader reader)=>reader.ReadTableItem()
            );
    }
}