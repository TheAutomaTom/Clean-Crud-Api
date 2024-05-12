using System.Collections.Specialized;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Web;
using CCA.Core.Application.Features.Users.CreateUser;
using CCA.Core.Application.Interfaces.Auth;
using CCA.Core.Application.Interfaces.Infrastructure;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using CCA.Data.Infra.Identities;
using CCA.Core.Infra.Models.Identities;

namespace CCA.Data.Infra.Identities
{
  public class IdentityManager : IManageIdentities
  {
    public IdentityManagerSettings Settings { get; }
    
    readonly ILogger<IdentityManager> _logger;
    readonly ICache _cache;

    readonly HttpClient _authClient;

    public IdentityManager(IOptions<IdentityManagerSettings> settings, ILogger<IdentityManager> logger, ICache cache)
    {
      Settings = settings.Value;
      
      _logger = logger;
      _cache = cache;

      _authClient = new HttpClient()
      {
        BaseAddress = new Uri(settings.Value.BaseAddress)
      };
    }

    public async Task<IdentityGetDto> CreateUser(IdentityCreateDto user)
    {
      try
      {
        var token = await getAdminToken();
        _authClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var url = $"{Settings.PathToGetUser}";
        url = url.Replace("{{Keycloak-Realm}}", Settings.KeycloakRealm);

        var json = JsonSerializer.Serialize(user);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _authClient.PostAsync(url, content);
        response.EnsureSuccessStatusCode();

        var search = new IdentitySearchDto()
        {
          Email = user.Email,
          SearchParams = [IdentitySearchParam.Email]

        };

        var confirmed = await GetUser(search);

        return confirmed;
      }
      catch(Exception ex)
      {

       _logger.LogError(ex, "Failed to create user");
        throw;
      }
    }

    public async Task<IdentityGetDto> GetUser(IdentitySearchDto search)
    {
      var token = await getAdminToken();

      var url = $"{Settings.PathToGetUser}";
      url = url.Replace("{{Keycloak-Realm}}", Settings.KeycloakRealm);

      // Add query parameters
      var queryString = HttpUtility.ParseQueryString(string.Empty);
      queryString.Add(IdentitySearchParam.Email.ToString(), search.Email);

      url += "?" + queryString.ToString();

      _authClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

      var response = await _authClient.GetAsync(url);
      response.EnsureSuccessStatusCode();

      var responseJson = await response.Content.ReadAsStringAsync();
      var result = JsonSerializer.Deserialize<List<IdentityGetDto>>(responseJson, new JsonSerializerOptions() { PropertyNameCaseInsensitive = false });

      if(result.Count == 0)
      {
        return null;
      }
      if(result.Count > 1)
      {
        _logger.LogWarning("More than one user found for search criteria: {search}", search);
      }

      return result.FirstOrDefault()!;
    }








    async Task<string> getAdminToken()
    {
      var exists = await _cache.Exists("adminToken");

      if (exists.IsOk && exists.Data == true)
      {
        var cached = await _cache.Read<IdentityServerToken>("adminToken");
        if (cached.IsOk && !String.IsNullOrEmpty(cached.Data!.AccessToken))
        {
          return cached.Data.AccessToken;
        }
      }

      // Else, request a new token.

      var formData = new FormUrlEncodedContent(
        new Dictionary<string, string>
        {
          { "grant_type", "client_credentials" },
          { "client_id", Settings.ClientId },
          { "client_secret", Settings.ClientSecret }
        }
      );

      try
      {

        var response = await _authClient.PostAsync(Settings.PathToAdminToken, formData);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<IdentityServerToken>(json);

        await _cache.Create("adminToken", result, TimeSpan.FromMinutes(result.ExpiresInSeconds / 60));

        return result.AccessToken;
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "Failed to get admin token");
        throw;
      }
    }





  }
}
