using Kombox.DataAccess.Repository.Interfaces;
using Kombox.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kombox.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShoppingCartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                List<ShoppingCart> carts = _unitOfWork.shoppingCartRepository.GetAll().ToList();
                if (carts.Count() == 0)
                {
                    return Ok(new
                    {
                        status = true,
                        Message = "not payments do it alredy"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        status = true,
                        Carts = carts
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = false,
                    message = ex.Message
                });
               
            }
            
        }

    }
}
