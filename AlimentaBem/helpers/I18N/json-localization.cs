namespace alimenta_bem.helpers;

internal class JsonLocalization
{
    public string Key { get; set; }
    public Dictionary<string, string> LocalizedValues { get; set; }
}

public class I18NException : Exception
{
    public I18NException(string message) : base(message) {}
    public I18NException(string message, Exception innerException) : base(message, innerException) {}
    public I18NException() {}
}