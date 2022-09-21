
using AuthenticationApi.Models;
using AuthenticationApi.Services;
using CommonDbLayer.CommonDbEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        public EventManagementContext DbContext { get; set; }
        public readonly IConfiguration _configuration;
        public AuthenticationController(ITokenService tokenService, EventManagementContext dbContext, IConfiguration configuration)
        {
            _tokenService = tokenService;
            DbContext = dbContext;
            _configuration = configuration;
        }

        private class RequestedUserInfo
        {
            public long UserId { get; set; }
            public string FirstName { get; set; }
            public string UserType { get; set; }
            public string UserEmail { get; set; }
            public string Password { get; set; }
            public RequestedUserInfo(long userId, string email, string usertype, string firstname, string password)
            {
                UserId = userId;
                UserEmail = email;
                UserType = usertype;
                FirstName = firstname;
                Password = password;
            }
        }


        /// <summary>
        /// This method is used to authenticate a user credentials
        /// </summary>
        /// <param name="userdetail"></param>
        /// <returns>Returns Token if credentials are correct</returns>
        [HttpPost]
        public ActionResult<string> Authentication(ValidateUserCredentials userdetail)
        {
            try
            {
                var userdata = ValidateUserCredential(userdetail);
                if (userdata != null)
                {
                    var token = _tokenService.BuildToken(_configuration["Jwt:Key"],
                                _configuration["Jwt:Issuer"],
                                new[]
                                {
                                //_configuration["Jwt:ApiGatewayAudience"],
                                _configuration["Jwt:AdminAudience"],
                                //_configuration["Jwt:EventAudience"]
                                //_configuration["Jwt:AuthorAudience"]
                                },
                                userdata.FirstName,
                                userdata.UserEmail,
                                userdata.UserType);
                    return Ok(new
                    {
                        Token = token,
                        IsAuthenticated = true
                    });
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {

                return Unauthorized();
            }

        }

        /// <summary>
        /// This method returns bool value based on user credentials
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>Returns true if a valid user else returns false</returns>
        private RequestedUserInfo ValidateUserCredential(ValidateUserCredentials userLogin)
        {
            try
            {

                List<UserDetail> list = _tokenService.validateuser(userLogin);
                foreach (var item in list)
                {
                    return new RequestedUserInfo(item.UserId, item.UserEmail, item.UserType, item.FirstName, item.Password);

                }
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
