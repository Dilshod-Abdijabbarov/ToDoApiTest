using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.CategoryDTOs;
using Services.DTOs.TaskBaseDTOs;
using Services.IServices;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet("{id}")]
        public async ValueTask<IActionResult> Get([FromRoute] int id) =>
           Ok(await categoryService.GetAsync(c => c.Id == id));

        [HttpGet("GetAll")]
        public async ValueTask<IActionResult> GetAll() =>
            Ok(await categoryService.GetAllAsync());

        [HttpPost]
        public async ValueTask<IActionResult> Create(
                     [FromBody] CategoryForCreationDTO categoryForCreation) =>
            Ok(await categoryService.CreateAsync(categoryForCreation));

        [HttpPut]
        public async ValueTask<IActionResult> Update([FromQuery] int id,
                     [FromBody] CategoryForCreationDTO categoryForCreation) =>
            Ok(await categoryService.UpdateAsync(id, categoryForCreation));

        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> Delete([FromRoute] int id) =>
            Ok(await categoryService.DeleteAsync(id));
    }
}
