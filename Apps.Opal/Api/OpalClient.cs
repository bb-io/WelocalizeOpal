using Apps.Opal.Constants;
using Apps.Opal.Models.Error;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Exceptions;
using Blackbird.Applications.Sdk.Utils.Extensions.Sdk;
using Blackbird.Applications.Sdk.Utils.RestSharp;
using Newtonsoft.Json;
using RestSharp;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Apps.Opal.Api;

public class OpalClient : BlackBirdRestClient
{
    public OpalClient(IEnumerable<AuthenticationCredentialsProvider> creds) : base(new()
    {
        BaseUrl = new Uri($"{creds.Get(CredsNames.Url).Value}/v1"),
    })
    {
        string token = creds.Get(CredsNames.Token).Value;
        this.AddDefaultHeader("Authorization", $"Bearer {token}");
    }

    protected override Exception ConfigureErrorException(RestResponse response)
    {
        string statusCodePart = string.Empty;
        if (response.StatusCode != 0)
            statusCodePart = $"Status code {(int)response.StatusCode}. ";

        if (string.IsNullOrWhiteSpace(response.Content) && string.IsNullOrWhiteSpace(response.ErrorMessage))
            return new PluginApplicationException($"{statusCodePart}No content received from the server");

        if (response.ContentType == "application/json" && !string.IsNullOrWhiteSpace(response.Content))
        {
            //var error = JsonConvert.DeserializeObject<ErrorResponse>(response.Content);
            //if (error == null || string.IsNullOrEmpty(error.Detail))
                //return new PluginApplicationException($"{statusCodePart}Couldn't parse the error. Raw: {response.Content}");

            //return new PluginApplicationException(error.Detail);
            return new PluginApplicationException(response.Content);
        }
        else if (response.ContentType == "text/plain" && !string.IsNullOrWhiteSpace(response.Content))
            return new PluginApplicationException(response.Content);

        string fallbackError = string.IsNullOrWhiteSpace(response.ErrorMessage) ? "Unknown error" : response.ErrorMessage;
        return new PluginApplicationException($"{statusCodePart}{fallbackError}");
    }
}