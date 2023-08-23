using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.RepeatTimeDTOs;
using Services.DTOs.TaskBaseDTOs;
using Services.IServices;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepeatTimeController : ControllerBase
    {
        private readonly IRepeatTimeService repeatTimeService;
        public RepeatTimeController(IRepeatTimeService repeatTimeService)
        {
            this.repeatTimeService = repeatTimeService;
        }

        [HttpGet("{id}")]
        public async ValueTask<IActionResult> Get([FromRoute] int id) =>
           Ok(await repeatTimeService.GetAsync(c => c.Id == id));

        [HttpGet("GetAll")]
        public async ValueTask<IActionResult> GetAll() =>
            Ok(await repeatTimeService.GetAllAsync());

        [HttpPost]
        public async ValueTask<IActionResult> Create(
                     [FromBody] RepeatTimeForCreationDTO repeatTimeForCreationDTO) =>
            Ok(await repeatTimeService.CreateAsync(repeatTimeForCreationDTO));

        [HttpPut]
        public async ValueTask<IActionResult> Update([FromQuery] int id,
                     [FromBody] RepeatTimeForCreationDTO repeatTimeForCreationDTO) =>
            Ok(await repeatTimeService.UpdateAsync(id, repeatTimeForCreationDTO));

        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> Delete([FromRoute] int id) =>
            Ok(await repeatTimeService.DeleteAsync(id));
    }
}
