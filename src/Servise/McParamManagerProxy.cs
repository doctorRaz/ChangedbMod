using System;
using System.Linq;
using System.Reflection;

/// <summary>
/// Идея жопите, нерабочая
/// </summary>
static class McParamManagerProxy
{
    private static dynamic _impl;

    static McParamManagerProxy()
    {
        _impl = FindMcParamManager()
            ?? throw new InvalidOperationException("McParamManager не найден");
    }

    private static Type FindMcParamManager()
    {
        foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
        {
            Type type = asm
                .GetTypes()
                .FirstOrDefault(t =>
                    t.Name == "McParamManager" &&
                    t.GetMethod("SetParam", new[] { typeof(string), typeof(int) }) != null);

            if (type != null)
                return type;
        }

        return null;
    }

    public static bool SetParam(string value, int index)
        => _impl.SetParam(value, index);

    public static string GetStringParam(int index)
        => _impl.GetStringParam(index);
}