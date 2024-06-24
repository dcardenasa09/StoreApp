using AutoMapper;
using System.Reflection;
using Store.Entities.Common.Mapping;

namespace Store.Api.Common.Mapping;

public class MappingProfile : Profile {
    
    public MappingProfile() {
        ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
    }
    
    private void ApplyMappingsFromAssembly(Assembly assembly) {
        var types = assembly.GetExportedTypes()
                            .Where(t => typeof(IMapFrom).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                            .ToList();

        foreach (var type in types) {
            var instance   = Activator.CreateInstance(type);
            var methodInfo = type.GetMethod("Mapping") ?? type.GetInterfaceMap(typeof(IMapFrom)).TargetMethods.FirstOrDefault();

            methodInfo?.Invoke(instance, new object[] { this });
        }
    }
}