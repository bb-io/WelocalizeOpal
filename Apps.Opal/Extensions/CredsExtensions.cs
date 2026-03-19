using Apps.Opal.Constants;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Utils.Extensions.Sdk;
using System.Security.Cryptography;
using System.Text;

namespace Apps.Opal.Extensions;

public static class CredsExtensions
{
    public static string GetAccessTokenHash(this IEnumerable<AuthenticationCredentialsProvider> creds)
    {
        var token = creds.Get(CredsNames.Token).Value;

        if (string.IsNullOrEmpty(token)) 
            return string.Empty;

        byte[] hashBytes = SHA256.HashData(Encoding.UTF8.GetBytes(token));
        return Convert.ToHexString(hashBytes).ToLowerInvariant();
    }
}
