using System.ComponentModel;

namespace alimenta_bem.helpers;

public static class EnumHelper
{
    public static T? ToEnumOrNull<T>(string? value) where T : struct
    {
        if (value == null) return null;

        try
        {
            return (T)Enum.Parse(typeof(T), value.Trim(), true);
        }
        catch
        {
            return null;
        }
    }

    public static T ToEnum<T>(string value) where T : Enum
    {
        try
        {
            return (T)Enum.Parse(typeof(T), value.Trim(), true);
        }
        catch
        {
            throw new Exception("Invalid enum value");
        }
    }

    public static List<T> ToEnumList<T>(List<string> value) where T : struct
    {
        if (value == null) return new List<T>();

        try
        {
            return value
                .Select(item => (T)Enum.Parse(typeof(T), item.Trim(), true))
                .ToList();
        }
        catch
        {
            throw new Exception("Invalid enum value");
        }
    }

    public static bool IsAValidEnum<T>(string value)
    {
        if (typeof(T).IsEnum == false)
        {
            throw new ArgumentException($"Type '{typeof(T).FullName}' is not a valid enum.");
        }

        return Enum.IsDefined(typeof(T), value);
    }

    public static T GetEnumValueFromDescription<T>(string description) where T : Enum
    {
        foreach (var field in typeof(T).GetFields())
        {
            if (Attribute.GetCustomAttribute(field,
            typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
            {
                if (attribute.Description == description)
                    return (T)field.GetValue(null);
            }
            else
            {
                if (field.Name == description)
                    return (T)field.GetValue(null);
            }
        }

        throw new ArgumentException("Not found.", nameof(description));
    }

    public static IEnumerable<string> GetEnumDescriptions<T>()
    {
        var attributes = typeof(T).GetMembers()
            .SelectMany(fi => fi.GetCustomAttributes(typeof(DescriptionAttribute), true)
            .Cast<DescriptionAttribute>())
            .ToList();

        return attributes.Select(x => x.Description);
    }
}
