namespace PCBuilder.Service.ComponentsAPI.Utilities;

public interface IComponentTypeResolver
{
    bool TryResolve(string category, out Type? type);
    IEnumerable<string> Categories { get; }
}