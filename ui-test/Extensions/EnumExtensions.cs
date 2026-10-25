using System.ComponentModel;
using System.Reflection;

public static class EnumExtensions
{
    public static string GetValue<T>(this T type) where T : Enum
    {
        var field = typeof(T).GetField(type.ToString());

        var attribute = field?.GetCustomAttribute<DescriptionAttribute>();

        return attribute?.Description ?? type.ToString();
    }
}