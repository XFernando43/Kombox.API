using Kombox.DataAccess.Repository.Interfaces;
using Kombox.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kombox.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult getAll()
        {
            try
            {

                List<Product> products = _unitOfWork.productRepository.GetAll().ToList();
                return Ok(new
                {
                    status = true,
                    Products = products
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {

                var product = _unitOfWork.productRepository.Get(u => u.ProductId == id);
                return Ok(new
                {
                    status = true,
                    Product = product
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            try
            {
                _unitOfWork.productRepository.Add(product);
                _unitOfWork.Save();
                return Ok(new
                {
                    status = true,
                    Product = product,
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
        [HttpPatch]
        public IActionResult UpdateProduct(int id, [FromBody] Product product)
        {
            try
            {
                _unitOfWork.productRepository.Update(id, product);
                _unitOfWork.Save();
                return Ok(new
                {
                    status=true,
                    Product = product,
                    message="Product Update It"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    status = false,
                    message = ex.Message
                }) ;
            }
        }
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                var product = _unitOfWork.productRepository.Get(u=>u.ProductId == id);
                _unitOfWork.productRepository.Remove(product);
                _unitOfWork.Save();
                return Ok(new
                {
                    status = true,
                    Product = product,
                    message = "Delete It"
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
