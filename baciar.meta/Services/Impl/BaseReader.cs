using System.Data.Common;
using Npgsql;

namespace baciar.meta.Services.Impl;

public class BaseReader<Dto>
where Dto:class
{
    internal async Task<IEnumerable<Dto>> ReadAsync(NpgsqlDataSource dataSource, string[] schemas, Func<string,string> createQuery, Func<DbDataReader, Dto> read)
    {
        var data = new List<Dto>();
        if(schemas.Any())
        {
            foreach(var schema in schemas)
            {
                var sql = createQuery(schema);
                await using (var cmd = dataSource.CreateCommand(sql))
                await using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while(await reader.ReadAsync())
                    {
                        data.Add(read(reader));
                    }
                }
            }
        }
        return data;
    }
}