using baciar.meta.Model;

namespace baciar.meta.Services;

public interface IGeneratedColumnDependencyReader
{
    Task<IEnumerable<GeneratedColumnDependencyItem>> ReadAsync(string[] schemas);
}