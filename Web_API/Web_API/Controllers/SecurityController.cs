using AutoMapper;
using Demo.Database.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Helpers;
using Web_API.DTOModels;

namespace Web_API.Controllers
{
    [Route("api/security")]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "Security")]
    [ApiController]
    public class SecurityController : Controller
    {
        public const string SecretKey = "YXN3ZXJ0cmVkc2ZyeWpoRnIxNEhHUmJramdkZmRraDc0aHRyZWRmYmZydGRrRVJEamdqZ2lkZmRzVFJmd2hranl0dnNFUkRzd2Vl";
        public const string AUTHENTICATION_SCHEME = "UserScheme";
        private readonly IUserRepository UserRepository;
        private readonly IMapper Mapper;

        public SecurityController(IUserRepository userRepository,
            IMapper mapper)
        {
            this.UserRepository = userRepository;
            this.Mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]DTOLogin login)
        {
            try
            {
                var user = await this.UserRepository.GetActiveUserByEmail(login.Username.Trim().ToLower()).ConfigureAwait(false);
                if(user != null)
                {
                    if(string.Compare(Crypto.Hash(login.Password),user.Password) == 0)
                    {
                        var data = Mapper.Map<DTOLoginUser>(user);
                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim("userid", data.Id.ToString()));

                        data.Token = GenerateToken(claims);
                        return Ok(data);
                    }
                    return BadRequest("Invalid password!");
                }
                return BadRequest("Invalid user!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        private static string GenerateToken(List<Claim> claims)
        {
            string returntoken;
            var key = new SymmetricSecurityKey(Convert.FromBase64String(SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                                issuer: "users",
                                claims: claims,
                                audience: "http://localhost:4200",
                                expires: DateTime.UtcNow.AddDays(30),
                                signingCredentials: creds);
            returntoken = new JwtSecurityTokenHandler().WriteToken(token);
            return returntoken;
        }
    }
}
