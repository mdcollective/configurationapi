using Data.Domain;

namespace Data.Repositories
{
	/// <summary>
	/// Repository layer security service to be used for authentication.
	/// </summary>
	public interface ISecurityRepository
	{
		/// <summary>
		/// Authentication for standard user authentication.
		/// </summary>
		/// <param name="loginRequest">Credentials to authenticate.</param>
		/// <returns>LoginResponse object indicating result.</returns>
		(LoginResponse loginResponse, string[] errors) LogIn(LoginRequest request);
	}
}