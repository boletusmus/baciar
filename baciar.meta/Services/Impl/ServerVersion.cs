
using baciar.meta.Services;
using Npgsql;

public class ServerVersion : IServerVersion
{
    private readonly NpgsqlDataSource dataSource;

    public ServerVersion(NpgsqlDataSource dataSource)
    {
        this.dataSource = dataSource;
    }
    public async Task<string> VersionAsync()
    {
        string result = "";
        var sql = "select version();";
        await using (var cmd = dataSource.CreateCommand(sql))
        await using (var reader = await cmd.ExecuteReaderAsync())
        {
            if(await reader.ReadAsync())
            {
                result = reader.GetString(0);
            }
        }
        return result;
    }
}