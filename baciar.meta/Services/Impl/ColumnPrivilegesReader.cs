using System.Data.Common;
using baciar.meta.Model;
using Npgsql;

namespace baciar.meta.Services.Impl;
public class ColumnPrivilegesReader : IColumnPrivilegesReader
{
    private readonly NpgsqlDataSource dataSource;
    private readonly BaseReader<ColumnPrivilegesItem> reader;
    public ColumnPrivilegesReader(NpgsqlDataSource dataSource)
    {
        this.dataSource = dataSource;
        reader = new BaseReader<ColumnPrivilegesItem>();
    }
    public async Task<IEnumerable<ColumnPrivilegesItem>> ReadAsync(string[] schemas)
    {
        return await reader.ReadAsync(
            dataSource, 
            schemas, 
            (name)=>$"select table_schema,table_name,column_name,privilege_type,case when is_grantable='YES' then true else false end,grantor,grantee from information_schema.column_privileges where table_schema='{name}';",
            (DbDataReader reader)=>reader.ReadColumnPrivilegesItem()
            );
    }
}