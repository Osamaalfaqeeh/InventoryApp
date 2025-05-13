namespace InventoryApp.Application.Auth
{
    /// <summary>
    /// Represents the login credentials for authentication.
    /// </summary>
    public class LoginRequest
    {
        /// <summary>Username to log in with.</summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>Password to log in with.</summary>
        public string Password { get; set; } = string.Empty;
    }
}
