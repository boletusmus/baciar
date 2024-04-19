namespace baciar.meta.Services;

public interface ISchemaGenerator
{
    (bool status, string name, string info)[] Generate();
}