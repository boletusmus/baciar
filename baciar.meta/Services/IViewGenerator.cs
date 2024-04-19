using baciar.meta.Model;
//
namespace baciar.meta.Services;

public interface IViewGenerator
{
    Task<IEnumerable<ViewItem>> GenerateAsync(string[] schemas);
}