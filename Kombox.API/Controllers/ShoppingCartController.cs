using Kombox.DataAccess.Repository.Interfaces;
using Kombox.Models.Models;
using Kombox.Models.Request;
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
        [Route("GetAll")]
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
                        Message = "Not payments dasdadas do it alrdasedy!!!"
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

        [HttpGet("GetShoppingCartByUserID/{id}")]
        public ActionResult GetShoppinCartByUserId(int id)
        {
            try
            {
                var cart = _unitOfWork.itemCartRepository.GetAll(x => x.ShoppingCartId == id, includeProperties: "Product");
                if (cart != null)
                {
                    return Ok(new
                    {
                        status = true,
                        Cart = cart,
                    });
                }
                else
                {
                    return BadRequest(new
                    {
                        status = false,
                        message = "Not Found any one cart!!!"
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

        [HttpPost]
        [Route("PostItemCart")]
        public IActionResult Post([FromBody] ItemCartRequest item)
        {
            try
            { 
                ItemCart aux = new ItemCart
                {
                    ProductId = item.ProductId,
                    count = item.count,
                    ShoppingCartId = item.ShoppingCartId,
                };

                // pendiente el acutalizar la cantidad de del producto del item cart d
                // pendiente el acutalizar la cantidad de del producto del item cart d
                // pendiente el acutalizar la cantidad de del producto del item cart d
                // pendiente el acutalizar la cantidad de del producto del item cart d
                // pendiente el acutalizar la cantidad de del producto del item cart d
                // pendiente el acutalizar la cantidad de del producto del item cart d

                _unitOfWork.itemCartRepository.Add(aux);
                _unitOfWork.Save();
                return Ok(new
                {
                    status = true,
                    item = item,
                    Message = "Cart save it successfully!!!!"
                });
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
