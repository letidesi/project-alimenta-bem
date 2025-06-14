namespace alimenta_bem.helpers;

public static class WhiteSpaces
{
    public static object RemoveFromAllStringProperty(object obj)
    {
        var stringProperties = obj.GetType().GetProperties()
            .Where(p => p.PropertyType == typeof(string));

        foreach (var stringProperty in stringProperties)
        {
            string currentValue = (string)stringProperty.GetValue(obj, null);

            stringProperty.SetValue(obj, currentValue?.Trim(), null);
        }

        return obj;
    }
}
