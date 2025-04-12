using Microsoft.Maui.Storage;
using System.Threading.Tasks;
using MovingAndGroovingApp.Services;

namespace MovingAndGroovingApp.Services
{
    public class AuthenticationService
    {
        private readonly DatabaseService _databaseService;

        public AuthenticationService()
        {
            _databaseService = new DatabaseService();
        }
        public async Task<bool> LoginAsync(string username, string password)
        {
            var user = await _databaseService.GetUserAsync(username, password);
            if (user != null)
            {
                // Store the user ID in Preferences or SecureStorage
                Preferences.Set("CurrentUserId", user.Id);
                return true;
            }
            return false;
        }
    }
}