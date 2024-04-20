using baciar.meta.Model;

namespace baciar.meta.Services;
public interface IColumnPrivilegesReader
{
    Task<IEnumerable<ColumnPrivilegesItem>> ReadAsync(string[] schemas);
}