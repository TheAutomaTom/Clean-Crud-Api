using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Web;
using CCA.Core.Application.Interfaces.Infrastructure;
using CCA.Core.Infra.Models.Users;
using CCA.Core.Infra.Models.Users.Config;
using CCA.Core.Infra.Models.Users.Requests.Create;
using CCA.Core.Infra.Models.Users.Requests.Search;
using CCA.Core.Infra.Models.Users.Results;
using CCA.Core.Infra.ResultTypes;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using CCA.Data.Infra.Users;

namespace CCA.Data.Infra.Users
{
	public class UserService : IManageUsers
  {
    public UserServiceSettings Settings { get; }

    readonly ILogger<UserService> _logger;
    readonly ICache _cache;

    readonly HttpClient _adminClient;
		readonly JsonSerializerOptions _jsonOptions;

		readonly JwtSecurityTokenHandler _jwt;

		public UserService(IOptions<UserServiceSettings> settings, ILogger<UserService> logger, ICache cache)
    {
      Settings = settings.Value;

      _logger = logger;
      _cache = cache;

      _adminClient = new HttpClient()
      {
        BaseAddress = new Uri(settings.Value.BaseAddress)
      };

			_jwt = new JwtSecurityTokenHandler();

			_jsonOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
		}

    public async Task<Result<User>> CreateUser(UserCreateRequest userRequest, UserRole role)
    {
      try
      {
        // Url
        var url = $"{Settings.PathToGetUsers}";
        url = url.Replace("{{Realm}}", Settings.KeycloakRealm);

        // Content
        var json = JsonSerializer.Serialize(userRequest);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        // Auth token
        var token = await getAdminToken();
        _adminClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        // Send request
        var response = await _adminClient.PostAsync(url, content);
				// TODO: Catch 409 Conflicts.
        response.EnsureSuccessStatusCode();

        // Manually get the new user's Id to use for further operations
        var search = new UserSearchRequest()
        {
					Exact = true,
          Email = userRequest.Email,
          SearchParams = [UserSearchParam.Email, UserSearchParam.Exact]
        };

        var user = await getUser(search);

				var assignedRole = await addRoleToUser(user, role);
				

        return Result<User>.Ok(user);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "Failed to create user");
				return Result<User>.Fail(ex);
      }
    }

    async Task<User> getUser(UserSearchRequest search)
    {
      // Url base
      var url = $"{Settings.PathToGetUsers}";
      url = url.Replace("{{Realm}}", Settings.KeycloakRealm);

      // Url query parameters // TODO: getUserBy(KeycloakUserQuery query)
      var queryString = HttpUtility.ParseQueryString(string.Empty);
      queryString.Add(UserSearchParam.Email.ToString(), search.Email);      
      url += "?" + queryString.ToString();

      // Auth token
      var token = await getAdminToken();
      _adminClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

      // Send
      var response = await _adminClient.GetAsync(url);
      response.EnsureSuccessStatusCode();

      // Receive
      var responseJson = await response.Content.ReadAsStringAsync();
      var result = JsonSerializer.Deserialize<List<User>>(responseJson, _jsonOptions);

      if (result!.Count == 0)
      {
        return null;
      }
      
      // TODO: refactor user query and try `exact` param to avoid multiple hits.
      if (result.Count > 1)
      {
        _logger.LogWarning("More than one user found for search criteria: {search}", search);
      }

      // Assign roles to user.

      return result.FirstOrDefault()!;
    }


    async Task<Result> addRoleToUser(User userDetail, UserRole roleRequested)
    {
			// Content
      var role = await getRoleDetailByName(roleRequested);
			var roleRequest = new UserRoleInfo[] {role };
			var json = JsonSerializer.Serialize(roleRequest);
			var content = new StringContent(json, Encoding.UTF8, "application/json");

			// Url
			var url = $"{Settings.PathToAssignUseRole}";
			url = url.Replace("{{Realm}}", Settings.KeycloakRealm);
			url = url.Replace("{{User-Uuid}}", userDetail.Guid);
			url = url.Replace("{{Ui-Client-Uuid}}", Settings.UiClientUuid);

			// Auth token
			var token = await getAdminToken();
			_adminClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

			// Send request
			var response = await _adminClient.PostAsync(url, content);
			response.EnsureSuccessStatusCode();

			return Result.Ok();

		}



    async Task<IEnumerable<UserRoleInfo>> updateRoleDetailsCache(UserRole role = UserRole.Unregistered)
    {
      var url = $"{Settings.PathToGetAllRoles}";
      url = url.Replace("{{Realm}}", Settings.KeycloakRealm);
      url = url.Replace("{{Ui-Client-Uuid}}", Settings.UiClientUuid);

      var token = await getAdminToken();
      _adminClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

			try
			{
				var response = await _adminClient.GetAsync(url);
				response.EnsureSuccessStatusCode();

				var json = await response.Content.ReadAsStringAsync();

				var roles = JsonSerializer.Deserialize<List<UserRoleInfo>>(json, _jsonOptions);

				foreach (var r in roles)
				{
					await _cache.Create(r.Name, r, TimeSpan.FromDays(1));
				}

				return roles;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to get roles details");
				throw;
			}
		}






		async Task<UserRoleInfo> getRoleDetailByName(UserRole roleType)
		{
			// Check the cache
			var exists = await _cache.Exists(roleType.ToString());

			if (exists.IsOk && exists.Data == true)
			{
				var cached = await _cache.Read<UserRoleInfo>(roleType.ToString());
				if (cached.IsOk && !String.IsNullOrEmpty(cached?.Data!.Id))
				{
					return cached.Data!;
				}
			}

			// Else, call Keycloak
			var allRoles = await updateRoleDetailsCache(roleType);
			var role = allRoles.FirstOrDefault(r => r.Name == roleType.ToString());
			// TODO: Null check

			return role;


		}


		async Task<string> getAdminToken()
    {
      // Check the cache for an unexpired token.
      var exists = await _cache.Exists("adminToken");

      if (exists.IsOk && exists.Data == true)
      {
        var cached = await _cache.Read<UserTokenInfo>("adminToken");
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
          { "client_id", Settings.AdminClientId },
          { "client_secret", Settings.AdminClientSecret }
        }
      );

      try
      {

        var response = await _adminClient.PostAsync(Settings.PathToAdminToken, formData);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<UserTokenInfo>(json);

        await _cache.Create("adminToken", result, TimeSpan.FromMinutes(result!.ExpiresInSeconds / 60));

        return result.AccessToken;
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "Failed to get admin token");
        throw;
      }
    }

		public async Task<Result<AuthenticationInfo>> AuthenticateUser(string username, string password)
		{


			var userToken = await getUserToken(username, password);

			var user = await getUser(new UserSearchRequest() { 
				Exact = true,
				Username = username,				
				SearchParams = [UserSearchParam.Username, UserSearchParam.Exact]
			});

			var data = new AuthenticationInfo()
			{
				User = user,
				Token = userToken
			};
			
			var result = Result<AuthenticationInfo>.Ok(data);
			return result;

		}

		public async Task<UserTokenInfo> getUserToken(string username, string password)
		{
			// Url
			var url = $"{Settings.PathToUserToken}";
			url = url.Replace("{{Realm}}", Settings.KeycloakRealm);

			// Content
			var formData = new FormUrlEncodedContent(
				new Dictionary<string, string>
				{
					{ "grant_type", "password" },
					{ "client_id", Settings.UiClientId },
					{ "client_secret", Settings.UiClientSecret },
					{ "username", username },
					{ "password", password }
				}
			);

			// Send
			var response = await _adminClient.PostAsync(url, formData);
			response.EnsureSuccessStatusCode();

			// Receive
			var responseJson = await response.Content.ReadAsStringAsync();
			var result = JsonSerializer.Deserialize<UserTokenInfo>(responseJson, _jsonOptions);

			return result;

		}




	}
}
