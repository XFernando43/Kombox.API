using Kombox.DataAccess.Repository.Interfaces;
using Kombox.Models.Models;
using Kombox.Models.Request;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
                List<Product> products = _unitOfWork.productRepository
                    .GetAll(includeProperties: "Category") // Aquí se especifica que se debe cargar la propiedad de navegación "Category" junto con cada producto
                    .ToList();

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

                var product = _unitOfWork.productRepository.Get(u => u.ProductId == id, includeProperties: "Category");
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
        public IActionResult Post([FromBody] ProductRequest product)
        {
            try
            {
                var category = _unitOfWork.categoryRepository.Get(u => u.CategoryId == product.CategoryId);
                Product ProductAux = new Product
                {

                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    CategoryId = product.CategoryId,
                    Category = category,
                };
                _unitOfWork.productRepository.Add(ProductAux);
                _unitOfWork.Save();
                return Ok(new
                {
                    status = true,
                    Product = ProductAux,
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
        public IActionResult UpdateProduct(int id, [FromBody] ProductRequest product)
        {
            try
            {
                _unitOfWork.productRepository.Update(id, product);
                _unitOfWork.Save();
                return Ok(new
                {
                    status = true,
                    Product = product,
                    message = "Product Update It"
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
        [HttpDelete]

        public dynamic DeleteProduct(int id)
        {

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var rtoken = _unitOfWork.authorizationRepository.ValidarToken(identity);

            if (rtoken.Success == false) { return rtoken; }

            Usuario usuario = rtoken.Result;

            if (usuario.Rol != "Admin")
            {
                return BadRequest(new
                {
                    status = false,
                    message = "U don't have access to do this"
                });
            }
            else
            {
                var product = _unitOfWork.productRepository.Get(u => u.ProductId == id);
                _unitOfWork.productRepository.Remove(product);
                _unitOfWork.Save();
                return Ok(new
                {
                    status = true,
                    Product = product,
                    message = "Delete It"
                });
            }


        }
    }
}
