namespace baciar.meta.Services;

public interface IServerVersion
{
    Task<string> VersionAsync();
}