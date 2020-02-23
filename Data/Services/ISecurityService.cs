using Data.Domain;

namespace Data.Services
{
	/// <summary>
	/// Service layer security service to be used for authentication.
	/// </summary>
	public interface ISecurityService
	{
		/// <summary>
		/// Authentication for standard user authentication.
		/// </summary>
		/// <param name="loginRequest">Credentials to authenticate.</param>
		/// <returns>LoginResponse object indicating result.</returns>
		LoginResponse Login(LoginRequest loginRequest);

		/// <summary>
		/// Authentication for api authentication.
		/// </summary>
		/// <param name="loginRequest">Credentials to authenticate.</param>
		/// <returns>ApiLoginResponse object indicating result.</returns>
		ApiLoginResponse Login(ApiLoginRequest loginRequest);
	}
}