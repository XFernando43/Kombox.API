using Kombox.DataAccess.Repository;
using Kombox.DataAccess.Repository.Interfaces;
using Kombox.Models.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kombox.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Category> categories = _unitOfWork.categoryRepository.GetAll().ToList();
                Console.WriteLine(categories.Count);

                return Ok(new
                {
                    success = true,
                    Categories = categories
                });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    success = false,
                    Message = ex.Message
                });
            }

        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var Category = _unitOfWork.categoryRepository.Get(u => u.CategoryId == id);

                return Ok(new
                {
                    status = true,
                    category = Category
                });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    status = false,
                    Error = "Object not finded",
                    Message = ex.Message,
                });
            }
        }

        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            try
            {
                _unitOfWork.categoryRepository.Add(category);
                _unitOfWork.Save();
                return Ok(new
                {
                    status = true,
                    category = category,
                });
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    status = false,
                    message = ex.Message,
                });

            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Category category)
        {
            try
            {
                var existingCategory =  _unitOfWork.categoryRepository.Get(u => u.CategoryId == id);
               
                _unitOfWork.categoryRepository.Update(id,category);
                _unitOfWork.Save();

                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Category updated successfully."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    StatusCode = 500,
                    Message = "An error occurred while updating the category.",
                    Error = ex.Message
                });
            }
        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var category = _unitOfWork.categoryRepository.Get(u => u.CategoryId == id);

                if (category == null)
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        message = "Category not found.",
                    });
                }

                _unitOfWork.categoryRepository.Remove(category);
                _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    StatusCode = 500,
                    message = "An error occurred while processing the request.",
                    error = ex.Message,
                });
            }
        }

    }
}



//var Category = _unitOfWork.categoryRepository.Get(u => u.CategoryId == id);

//_unitOfWork.categoryRepository.Remove(Category);
//_unitOfWork.Save();
//return Ok(new
//{
//    StatusCode = 200,
//});

