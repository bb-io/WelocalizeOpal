using Apps.Opal.Constants;
using Apps.Opal.Models.Error;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Exceptions;
using Blackbird.Applications.Sdk.Utils.Extensions.Sdk;
using Blackbird.Applications.Sdk.Utils.RestSharp;
using Newtonsoft.Json;
using RestSharp;

namespace Apps.Opal.Api;

public class OpalClient : BlackBirdRestClient
{
    public OpalClient(IEnumerable<AuthenticationCredentialsProvider> creds) : base(new()
    {
        BaseUrl = new Uri(creds.Get(CredsNames.Url).Value),
    })
    {
        string token = creds.Get(CredsNames.Token).Value;
        this.AddDefaultHeader("Authorization", $"Bearer {token}");
    }

    protected override Exception ConfigureErrorException(RestResponse response)
    {
        string statusCodePart = $"Status code {(int)response.StatusCode}.";
        if (string.IsNullOrWhiteSpace(response.Content))
            return new PluginApplicationException($"{statusCodePart} No content received from the server");

        if (response.ContentType == "application/json")
        {
            var error = JsonConvert.DeserializeObject<ErrorResponse>(response.Content);
            if (error == null || string.IsNullOrEmpty(error.Detail))
                return new PluginApplicationException($"{statusCodePart} Couldn't parse the error. Raw: {response.Content}");

            return new PluginApplicationException(error.Detail);
        }
        else if (response.ContentType == "text/plain")
            return new PluginApplicationException(response.Content);

        return new PluginApplicationException($"{statusCodePart} Unknown error");
    }
}