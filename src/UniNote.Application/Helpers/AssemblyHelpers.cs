using System.Reflection;

namespace UniNote.Application.Helpers;

public static class AssemblyHelpers
{
    public static List<Assembly> GetAssemblies(Assembly? callingAssembly = null)
    {
        // var coreAssembly = typeof(DefaultCoreModule).Assembly;
        var appAssembly = typeof(DefaultApplicationModule).Assembly;
        var assemblies = new List<Assembly>
        {
            // coreAssembly,
            appAssembly
        };
        
        if (callingAssembly != null)
            assemblies.Add(callingAssembly);

        return assemblies;
    }
}