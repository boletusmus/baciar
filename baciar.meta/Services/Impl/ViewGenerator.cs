using System.Data.Common;
using baciar.meta.Model;
using Npgsql;

namespace baciar.meta.Services.Impl;

public class ViewGenerator : IViewGenerator
{
    private readonly NpgsqlDataSource dataSource;
    private readonly BaseGenerator<ViewItem> generator;

    public ViewGenerator(NpgsqlDataSource dataSource)
    {
        this.dataSource = dataSource;
        generator = new BaseGenerator<ViewItem>();
    }
    public async Task<IEnumerable<ViewItem>> GenerateAsync(string[] schemas)
    {
        return await generator.GenerateAsync(
            dataSource, 
            schemas, 
            (name)=>$"select table_schema,table_name,view_definition from information_schema.views where table_schema='{name}';",
            (DbDataReader reader)=>reader.ReadViewItem()
            );
    }
}