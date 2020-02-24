using Data.Domain;
using Data.Extensions;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Data.Repositories
{
	/// <summary>
	/// Repository layer security service to be used for authentication.
	/// </summary>
	public class SecurityRepository : ISecurityRepository
	{
		private IEnumerable<Configuration> _configurations;

		private int _lookupCodeId = 0;

		public SecurityRepository(List<Configuration> configurations)
		{
			_configurations = configurations;
		}

		/// <summary>
		/// Authentication for standard user authentication.
		/// </summary>
		/// <param name="loginRequest">Credentials to authenticate.</param>
		/// <returns>LoginResponse object indicating result.</returns>
		public (LoginResponse loginResponse, string[] errors) LogIn(LoginRequest request)
		{
			var loginUrl = _configurations.Get("login-url");

			try
			{
				var httpClient = new HttpClient();

				(var response, var error) = httpClient.Post<LoginResponse, LoginRequest>(loginUrl, request, null);

				if (error != null)
					return (null, new string[] { error });

				return (new LoginResponse { Success = true, Token = response.Token }, null);
			}
			catch (Exception exception)
			{
				return (null, new string[] { exception.Message });
			}
		}
	}
}
