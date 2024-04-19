using System.Data.Common;

namespace baciar.meta.Services.Impl;

public class SchemaGenerator : ISchemaGenerator
{
    private readonly DbConnection connection;

    public SchemaGenerator(DbConnection connection)
    {
        this.connection = connection;
    }
    public (bool status, string name, string info)[] Generate()
    {
        throw new NotImplementedException();
    }
}