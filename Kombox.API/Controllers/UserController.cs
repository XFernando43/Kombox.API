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

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<Usuario> usuarios = _unitOfWork.userRepository.GetAll(includeProperties: "RolUser").ToList();
                if (usuarios == null || usuarios.Count == 0)
                {
                    return Ok(new
                    {
                        status = true,
                        Usuarios = "Not Usuarios already in Db now"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        status = true,
                        Usuarios = usuarios
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = true,
                    message = ex.Message
                });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            try
            {
                var userFromDB = _unitOfWork.userRepository.Get(u => u.IdUser == id, includeProperties: "RolUser");
                if(userFromDB == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(new
                    {
                        status=true,
                        usuario = userFromDB
                    });
                }
            }catch(Exception ex) {
                return BadRequest(ex.Message);
            }
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
                    IdRol = request.RolId

                };
                

                _unitOfWork.userRepository.Add(usuarioAux);
                _unitOfWork.Save();

                ShoppingCart cartAux = new ShoppingCart
                {
                    IdUser = usuarioAux.IdUser,
                    TotalPrice = 0
                };

                _unitOfWork.shoppingCartRepository.Add(cartAux);
                _unitOfWork.Save();

                

                return Ok(new
                {
                    status = true,
                    Product = usuarioAux,
                    Message = "Product Save it"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            try
            {
                var UserFromDb = _unitOfWork.userRepository.Get(u => u.IdUser == id);
                if (UserFromDb == null)
                {
                    return BadRequest(new
                    {
                        status = false,
                        message = "User not found it"
                    });
                }
                else
                {
                    _unitOfWork.userRepository.Remove(UserFromDb);
                    _unitOfWork.Save();
                    return Ok(new
                    {
                        status = true,
                        User = UserFromDb,
                        message = "Delete it"
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = false,
                    message = "User not found it"
                });

            }
        }

        [HttpPatch("id")]
        public IActionResult Update(int id, [FromBody] UserRequest request)
        {
            try
            {
                var _userFromDb = _unitOfWork.userRepository.Get(u => u.IdUser == id);

                _unitOfWork.userRepository.Update(id, request);
                _unitOfWork.Save();
                return Ok(new
                {
                    status = true,
                    message = "User Update it",
                    User = _userFromDb,
                });

            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    status = false,
                    message = "User not found it"
                });
            }

        }


        [HttpPost]
        [Route("login")]
        public dynamic Login([FromBody] UserLogin optData)
        {
            string JsonData = JsonConvert.SerializeObject(optData);

            var data = JsonConvert.DeserializeObject<dynamic>(JsonData);

            string user = data.usuario.ToString();
            string password = data.password.ToString();

            Usuario usuario = _unitOfWork.userRepository.Get(x => x.usuario == user && x.password == password);

            if (usuario == null)
            {
                return new
                {
                    status = false,
                    message = "Credenciales Incorrectas",
                    results = ""
                };
            }

            var jwt = _configuration.GetSection("JWT").Get<Jwt>();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("id",usuario.IdUser.ToString()),
                new Claim("usuario",usuario.usuario),
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
