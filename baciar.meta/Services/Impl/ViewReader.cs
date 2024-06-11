using System.Data.Common;
using baciar.meta.Model;
using Npgsql;

namespace baciar.meta.Services.Impl;

public class ViewReader : IViewReader
{
    private readonly NpgsqlDataSource dataSource;
    private readonly BaseReader<ViewItem> reader;

    public ViewReader(NpgsqlDataSource dataSource)
    {
        this.dataSource = dataSource;
        reader = new BaseReader<ViewItem>();
    }
    public async Task<IEnumerable<ViewItem>> ReadAsync(string[] schemas)
    {
        return await reader.ReadAsync(
            dataSource, 
            schemas, 
            (name)=>$"select table_schema,table_name,view_definition from information_schema.views where table_schema='{name}';",
            (DbDataReader reader)=>reader.ReadViewItem()
            );
    }
}