using System.Text;
using System.Text.RegularExpressions;

namespace alimenta_bem.helpers;

public class StringUtility
{
    private static readonly string ENCODING = "iso-8859-7"; // GREEK Encoding

    public static string? RemoveSpecialCharacter(string value)
    {
        if (value is null || string.IsNullOrEmpty(value?.Trim())) return null;

        var sanitizedValue = Regex.Replace(value, "[^0-9a-zA-Z]+", "");
        return sanitizedValue;
    }

    public static string? ToQueryParam(string? value)
    {
        if (value is null || string.IsNullOrEmpty(value?.Trim())) return null;

        return Regex.Replace(value, "[^0-9A-Za-z ,]", "");
    }

    public static string? RemoveAcentuation(string text)
    {
        if (text is null || string.IsNullOrEmpty(text?.Trim())) return null;

        return
            System.Web.HttpUtility.UrlDecode(
                System.Web.HttpUtility.UrlEncode(
                    text.Trim(), Encoding.GetEncoding(ENCODING)));
    }
}