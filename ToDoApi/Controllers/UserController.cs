using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.UserDTOs;
using Services.IServices;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("{id}")]
        public async ValueTask<IActionResult> Get([FromRoute] int id) =>
            Ok(await userService.GetAsync(c => c.Id == id));

        [HttpGet("GetAll")]
        public async ValueTask<IActionResult> GetAll() =>
            Ok(await userService.GetAllAsync());

        [HttpPost]
        public async ValueTask<IActionResult> Create([FromBody] UserForCreationDTO userForCreation) =>
            Ok(await userService.CreateAsync(userForCreation));

        [HttpPut]
        public async ValueTask<IActionResult> Update([FromQuery] int id,
                     [FromBody] UserForCreationDTO userForCreation) =>
            Ok(await userService.UpdateAsync(id, userForCreation));

        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> Delete([FromRoute]int id)=>
            Ok(await userService.DeleteAsync(id));

        [HttpPut("PasswordChange")]
        public async ValueTask<IActionResult> PasswordChange(
                     [FromBody]UserForPasswordChangeDTO userForPassword)=>
            Ok(await userService.ChangePasswordAsync(userForPassword));
    }
}
