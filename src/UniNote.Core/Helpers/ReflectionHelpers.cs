using System.Reflection;

namespace UniNote.Core.Helpers;

public static class ReflectionHelpers
{
    public static Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
    {
        return
            assembly.GetTypes()
                .Where(t => string.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
                .ToArray();
    }
}