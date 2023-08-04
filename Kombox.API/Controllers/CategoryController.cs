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



        // GET: api/<CategoryController>
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

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CategoryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
