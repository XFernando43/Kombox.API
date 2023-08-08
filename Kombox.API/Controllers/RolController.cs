using Azure.Core;
using Kombox.DataAccess.Repository.Interfaces;
using Kombox.Models.Models;
using Kombox.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace Kombox.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public RolController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                List<RolUser> roles = _unitOfWork.rolRepository.GetAll().ToList();
                if (roles == null || roles.Count == 0)
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
                        Roles = roles
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

        [HttpPost]
        public IActionResult Post([FromBody] RolRequest request)
        {
            try
            {
                RolUser rolAux = new RolUser
                {
                    RolName = request.RolName,
                    Access = request.Access,
                };
                _unitOfWork.rolRepository.Add(rolAux);
                _unitOfWork.Save();
                return Ok(new
                {
                    status = true,
                    Role = rolAux,
                    Message = "Product Save it"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = false,
                    Message = ex.Message
                });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            try
            {
                var Rol = _unitOfWork.rolRepository.Get(u => u.RolId == id);
                if(Rol == null)
                {
                    return BadRequest(new
                    {
                        status = false,
                        message = "Not founded"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        status = true,
                        rol = Rol
                    });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    status = false,
                    message = "Not founded"
                });
            }
        }

        [HttpPatch("{id}")]
        public IActionResult Update(int id, [FromBody] RolRequest request)
        {
            try
            {
                var roleFromDb = _unitOfWork.rolRepository.Get(u => u.RolId == id);
                _unitOfWork.rolRepository.Update(id, request);
                return Ok(new
                {
                    status = true,
                    rol = roleFromDb
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = false,
                    message = "Not founded"
                });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var roleFromDb = _unitOfWork.rolRepository.Get(u => u.RolId == id);
                _unitOfWork.rolRepository.Remove(roleFromDb);
                _unitOfWork.Save();
                return Ok(new
                {
                    status = true,
                    message="Delete it",
                    rol = roleFromDb
                });

            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    status = false,
                    message = "Not founded"
                });
            }
        }
    }
}
