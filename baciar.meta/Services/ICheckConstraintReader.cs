using baciar.meta.Model;

namespace baciar.meta.Services;

public interface ICheckConstraintReader
{
    Task<IEnumerable<CheckConstraintItem>> ReadAsync(string[] schemas);
}