using AuthenticationApi.Models;
using CommonDbLayer.CommonDbEntities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthenticationApi.Services
{
    public class TokenService : ITokenService
    {
        private TimeSpan ExpireDuration = new TimeSpan(20, 30, 0);
        private readonly IConfiguration _configuration;
        private readonly EventManagementContext _dbContext;
        public TokenService(EventManagementContext dbContext, IConfiguration configuration)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        public string BuildToken(string key, string issuer, IEnumerable<string> audience,string firstname, string userEmail, string usertype)
        {
            var claims = new List<Claim>
            {
                new Claim("FirstName",firstname),
                new Claim("UserEmail", userEmail),
                new Claim("Usertype",usertype)
            };

            claims.AddRange(audience.Select(aud => new Claim(JwtRegisteredClaimNames.Aud, aud)));

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(issuer, issuer, claims,
                expires: DateTime.Now.Add(ExpireDuration), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

        }


        public List<UserDetail> validateuser(ValidateUserCredentials usersdetails)
        {
            var userObj = _dbContext.UserDetails.Where(u => u.UserEmail == usersdetails.UserEmail && u.Password == usersdetails.Password).ToList();
            if (userObj != null)
            {
                return userObj;
            }
            else
            {
                return null;
            }
        }
    }
}
