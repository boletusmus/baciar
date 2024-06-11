namespace baciar.meta.Services;

public interface ISchemaReader
{
    Task<IEnumerable<string>> ReadAsync();
}