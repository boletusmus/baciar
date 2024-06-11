using baciar.meta.Model;

namespace baciar.meta.Services;
public interface IColumnReader
{
    Task<IEnumerable<ColumnItem>> ReadAsync(string[] schemas);
}