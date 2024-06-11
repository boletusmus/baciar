using baciar.meta.Model;

namespace baciar.meta.Services;

public interface ITableReader
{
    Task<IEnumerable<TableItem>> ReadAsync(string[] schemas);
}