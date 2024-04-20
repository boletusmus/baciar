using baciar.meta.Model;
//
namespace baciar.meta.Services;

public interface IViewReader
{
    Task<IEnumerable<ViewItem>> ReadAsync(string[] schemas);
}