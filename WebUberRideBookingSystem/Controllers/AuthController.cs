using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebUberRideBookingSystem.DTOs.User;
using WebUberRideBookingSystem.Model;
using WebUberRideBookingSystem.UnitOfWorkk;

namespace WebUberRideBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly    IunitOfWork _repo;

        private readonly IConfiguration _config;
        public AuthController(IunitOfWork iunitOfWork,IConfiguration configuration)
        {
            _repo = iunitOfWork;
            _config = configuration;
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> Registration(RegistrationDTO dto)
        {
            var x = await _repo.userCustom.SearchByEmail(dto.Email);
            if (x != null)
            {
                return BadRequest("Email Alredy Exist");
            }
            if (dto.Role != "Rider" || dto.Role != "Driver")
            {
                BadRequest("Invalid role Mast Be Rider Driver");
            }

            var user = new User
            {
                Email = dto.Email,
                Role = dto.Role,
                Password = dto.Password,
                FullName=dto.Fullname,
                phonenumber=dto.phonenumber
            };
           await _repo.userCustom.Create(user);
            await _repo.SaveChangesAsync();
            return Ok("Registration Sucsefully !" );

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var x= await _repo.userCustom.SearchByEmail(dto.Email);
            if (x.Email != dto.Email || x.Password != dto.Password)
            {
                return BadRequest("Invalid Email Or Password");
            }
            var token = GenerateToken(x);
            return Ok(token);



        }

        private string  GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["jwt:key"]));
            var crad=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var claim = new List<Claim>
            {
               new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
               new Claim(ClaimTypes.Email,user.Email),
               new Claim(ClaimTypes.Role,user.Role)
            };

            var token = new JwtSecurityToken
                (
                issuer: _config["jwt:issuer"],
                audience: _config["jwt:audine"],
                signingCredentials: crad,
                claims: claim,
                expires: DateTime.Now.AddMinutes(60)


                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
