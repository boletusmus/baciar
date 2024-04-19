using baciar.meta.Model;

namespace baciar.meta.Services;

public interface ITableGenerator
{
    Task<IEnumerable<TableItem>> GenerateAsync(string[] schemas);
}