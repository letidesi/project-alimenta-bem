using Newtonsoft.Json;
using System.Globalization;

namespace alimenta_bem.helpers;

public class Localizer
{
    private readonly Dictionary<string, JsonLocalization[]> _localization = new ();
    private readonly CultureInfo[] SUPPORTED_CULTURES = new CultureInfo[] { new("en-US"), new("pt-BR") };

    private readonly IHttpContextAccessor _httpContextAccessor;

    public Localizer(IHttpContextAccessor httpContextAccessor, bool useBase = true, Dictionary<Type, string>? additionalPaths = null)
    {
        _httpContextAccessor = httpContextAccessor;

        if (useBase) PopulateLocalization("languages");
        if (additionalPaths == null) return;

        foreach (var additional in additionalPaths)
        {
            var codeBase = additional.Key.Assembly.Location;
            var uri = new UriBuilder(codeBase);
            var data = Uri.UnescapeDataString(uri.Path);
            var path = Path.GetDirectoryName(data);
            var fullPath = Path.Combine(path, additional.Value);

            PopulateLocalization(fullPath);
        }
    }

    /// <summary>
    /// resource:key:culture
    /// resource is the resource name
    /// "key" is the is the term you would like to LOCALIZE
    /// culture is optional
    /// </summary>
    /// <param name="query"></param>
    public string this[string query] => GetString(query);

    private void PopulateLocalization(string path)
    {
        var resources = Directory.GetFiles(path, "*.json", SearchOption.AllDirectories);

        foreach (var resource in resources)
        {
            try
            {
                LoadResourceFile(resource);
            }
            catch (Exception e)
            {
                throw new I18NException($"Error loading resource file {resource}", e);
            }
        }
    }

    private void LoadResourceFile(string resource)
    {
        var fileInfo = new FileInfo(resource);
        var fileName = fileInfo.Name[..fileInfo.Name.IndexOf('.')];
        var loc = JsonConvert.DeserializeObject<JsonLocalization[]>(File.ReadAllText(resource));
        _localization.Add(fileName, loc);
    }

    private string GetString(string query)
    {
        QueryParameters parameters = HandleQuery(query);
        
        var resource = _localization.SingleOrDefault(l => l.Key == parameters.Resource);
        if (resource.Value is null)
            throw new I18NException($"Couldn't find resource: {parameters.Resource}");
        
        var key = resource.Value.SingleOrDefault(x => x.Key == parameters.Key);
        if (key is null)
            throw new I18NException($"Couldn't find key: {parameters.Key}");

        var term = key.LocalizedValues.SingleOrDefault(x => x.Key == parameters.Culture);
        if (term.Value is null)
            throw new I18NException($"Couldn't find the term for culture: {parameters.Culture}");

        return term.Value;
    }

    private struct QueryParameters
    {
        public string Resource { get; set; }
        public string Key { get; set; }
        public string Culture { get; set; }
    }

    private QueryParameters HandleQuery(string query)
    {
        var split = query.Split(':');
        var resource = split[0];
        var key = split[1];
        var culture = split.Length > 2 ? split[2] : GetDefaultCulture();

        return new QueryParameters
        {
            Resource = resource,
            Key = key,
            Culture = culture
        };
    }

    private string GetDefaultCulture()
    {
        var request = _httpContextAccessor.HttpContext.Request;
        var acceptLanguageHeader = request.Headers["accept-language"].ToString();

        if (string.IsNullOrEmpty(acceptLanguageHeader))
            return CultureInfo.CurrentCulture.Name;

        // get the culture closest to the user's preference
        var culture = acceptLanguageHeader
                        .Split(',').FirstOrDefault()?.Trim()
                        .Split(';').FirstOrDefault()?.Trim();

        var isValidCulture = SUPPORTED_CULTURES.Any(c => c.Name == culture);

        if (isValidCulture is false)
            return CultureInfo.CurrentCulture.Name;

        return culture;
    }
}