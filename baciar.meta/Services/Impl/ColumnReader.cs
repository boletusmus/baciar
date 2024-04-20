using System.Data.Common;
using baciar.meta.Model;
using Npgsql;

namespace baciar.meta.Services.Impl;
public class ColumnReader : IColumnReader
{
    private readonly NpgsqlDataSource dataSource;
    private readonly BaseReader<ColumnItem> reader;
    public ColumnReader(NpgsqlDataSource dataSource)
    {
        this.dataSource = dataSource;
        reader = new BaseReader<ColumnItem>();
    }
    public async Task<IEnumerable<ColumnItem>> ReadAsync(string[] schemas)
    {
        return await reader.ReadAsync(
            dataSource, 
            schemas, 
            (name)=>$"select table_schema,table_name,column_name,ordinal_position,column_default,case when is_nullable='YES' then true else false end,data_type,character_maximum_length,character_octet_length,numeric_precision,numeric_precision_radix,numeric_scale,datetime_precision,case when is_identity='YES' then true else false end from information_schema.columns where table_schema='{name}';",
            (DbDataReader reader)=>reader.ReadColumnItem()
            );
    }
}