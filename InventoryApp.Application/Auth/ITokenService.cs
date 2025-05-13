namespace InventoryApp.Application.Auth
{
    public interface ITokenService
    {
        string GenerateJwtToken(string username);
    }
}
