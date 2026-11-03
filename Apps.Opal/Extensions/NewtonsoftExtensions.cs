using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Apps.Opal.Extensions;

public static class NewtonsoftExtensions
{
    public static string AsText(this JToken token)
    {
        return token.Type == JTokenType.String ? token.ToString() : token.ToString(Formatting.None);
    }
}