using System.Data.Common;
using baciar.meta.Model;
using baciar.meta.Services;
using Npgsql;

namespace baciar.meta.Services.Impl;
public class CheckConstraintReader : ICheckConstraintReader
{
    private readonly NpgsqlDataSource dataSource;
    private readonly BaseReader<CheckConstraintItem> reader;

    public CheckConstraintReader(NpgsqlDataSource dataSource)
    {
        this.dataSource = dataSource;
        reader = new BaseReader<CheckConstraintItem>();
    }
    public async Task<IEnumerable<CheckConstraintItem>> ReadAsync(string[] schemas)
    {
       return await reader.ReadAsync(
            dataSource, 
            schemas, 
            (name)=>$"select constraint_schema, constraint_name, check_clause from information_schema.check_constraints where constraint_schema='{name}';",
            (DbDataReader reader)=>reader.ReadCheckConstraintItem()
            );
     }
}