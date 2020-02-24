using Data.Domain;
using Data.Repositories;

namespace Data.Services
{
	/// <summary>
	/// Service layer security service to be used for authentication.
	/// </summary>
	public class SecurityService : ISecurityService
	{
		private readonly ISecurityRepository _securityRepository;

		public SecurityService(ISecurityRepository securityRepository)
			=> _securityRepository = securityRepository;

		/// <summary>
		/// Authentication for standard user authentication.
		/// </summary>
		/// <param name="loginRequest">Credentials to authenticate.</param>
		/// <returns>LoginResponse object indicating result.</returns>
		public (LoginResponse loginResponse, string[] errors) Login(LoginRequest loginRequest)
			=> _securityRepository.LogIn(loginRequest);
	}
}