using AuthenticationApi.Models;
using CommonDbLayer.CommonDbEntities;

namespace AuthenticationApi.Services
{
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, IEnumerable<string> audience, string firstname, string userEmail, string usertype);
        List<UserDetail> validateuser(ValidateUserCredentials usersdetails);
    }
}