using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyModel.Resolution;
using Microsoft.IdentityModel.Tokens;
using RentalyManager.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RentalyManager.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration configuration;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountsController(UserManager<IdentityUser> userManager, IConfiguration configuration,
            SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<ActionResult<TokenDTO>> Register(UserCredentials userCredentials)
        {
            var userRegister = new IdentityUser { UserName = userCredentials.email, Email = userCredentials.email };
            var result = await userManager.CreateAsync(userRegister, userCredentials.password);

            if (result.Succeeded)
            {
                return AuthResponse(userCredentials);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenDTO>> Login(UserCredentials userCredentials)
        {
            var result = await signInManager.PasswordSignInAsync(userCredentials.email, userCredentials.password,
                isPersistent: false, lockoutOnFailure: false);
            if ( result.Succeeded) { return AuthResponse(userCredentials); }
            else{ return BadRequest("Login incorrect"); }
        }

        private TokenDTO AuthResponse(UserCredentials userCredentials)
        {
            var listClaims = new List<Claim>()
            {
                new Claim("email", userCredentials.email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTSalt"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddDays(1);

            var securityToken = new JwtSecurityToken(issuer: null, audience: null, claims: listClaims, expires: expiration,
                signingCredentials: creds);

            return new TokenDTO
            {
                Type = "Bearer",
                Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
                Expire = expiration
            };
        }
    }
}
