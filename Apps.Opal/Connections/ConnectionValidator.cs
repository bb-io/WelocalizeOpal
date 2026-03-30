using Apps.Opal.Api;
using Apps.Opal.Models.Error;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Connections;
using Blackbird.Applications.Sdk.Common.Invocation;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace Apps.Opal.Connections;

public class ConnectionValidator(InvocationContext invocationContext) : BaseInvocable(invocationContext), IConnectionValidator
{
    public async ValueTask<ConnectionValidationResponse> ValidateConnection(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        CancellationToken cancellationToken)
    {
        try
        {
            var client = new OpalClient(authenticationCredentialsProviders);
            var request = new RestRequest("projects/1");

            var response = await client.ExecuteAsync(request, cancellationToken);
            var isValid = response.StatusCode != HttpStatusCode.Unauthorized;

            string message;
            if (!isValid)
            {
                var error = JsonConvert.DeserializeObject<ErrorResponse>(response.Content ?? "");
                message = error?.Detail ?? response.ErrorMessage ?? response.StatusCode.ToString();
            }
            else
                message = "Success";
                

            return new ConnectionValidationResponse
            {
                IsValid = isValid,
                Message = message,
            };

        } 
        catch(Exception ex)
        {
            InvocationContext.Logger?.LogError($"Connection validation failed: {ex.Message}", []);

            return new()
            {
                IsValid = false,
                Message = ex.Message
            };
        }

    }
}