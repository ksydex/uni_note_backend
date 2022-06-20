using System.Reflection;

namespace UniNote.Application.Helpers;

public static class AssemblyHelpers
{
    public static List<Assembly> GetAssemblies(Assembly? callingAssembly = null)
    {
        // var coreAssembly = typeof(DefaultCoreModule).Assembly;
        var infrastructureAssembly = typeof(DefaultApplicationModule).Assembly;
        var assemblies = new List<Assembly>
        {
            // coreAssembly,
            infrastructureAssembly
        };
        
        if (callingAssembly != null)
            assemblies.Add(callingAssembly);

        return assemblies;
    }
}