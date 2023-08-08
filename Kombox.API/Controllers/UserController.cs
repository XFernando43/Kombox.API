using Kombox.DataAccess.Repository.Interfaces;
using Kombox.Models.Models;
using Kombox.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Kombox.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IConfiguration _configuration { get; set; }
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserRequest request)
        {
            try
            {
                
                Usuario usuarioAux = new Usuario
                {
                    usuario = request.usuario,
                    password = request.password,
                    Rol = request.Rol
                    
                };
                _unitOfWork.userRepository.Add(usuarioAux);
                _unitOfWork.Save();
                return Ok(new
                {
                    status = true,
                    Product = usuarioAux,
                    Message = "Product Save it"
                });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("login")]
        public dynamic Login([FromBody] Object optData)
        {
            var data = JsonConvert.DeserializeObject<dynamic>(optData.ToString());

            string user = data.usuario.ToString();
            string password = data.password.ToString();

            //Usuario usuario = Usuario.DB().Where(x => x.usuario == user && x.password == password).FirstOrDefault();

            //if (usuario == null)
            //{
            //    return new
            //    {
            //        status = false,
            //        message = "Credenciales Incorrectas",
            //        results = ""
            //    };
            //}

            var jwt = _configuration.GetSection("JWT").Get<Jwt>();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                //new Claim("id",usuario.IdUser),
                //new Claim("usuario",usuario.usuario),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                jwt.Issuer,
                jwt.Audience,
                claims,
                expires: DateTime.Now.AddMinutes(4),
                signingCredentials: signIn
              );

            return new
            {
                success = true,
                message = "Exito",
                result = new JwtSecurityTokenHandler().WriteToken(token)
            };


        }
    }
}
