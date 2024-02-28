using FileOrbis_User_Registration.DTO.Requests;
using FileOrbis_User_Registration.DTO.Responses;
using FileOrbis_User_Registration.Services;
using Microsoft.AspNetCore.Mvc;

namespace FileOrbis_User_Registration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("/users")]
        public List<UserResponse> GetAll()
        {
            return userService.GetAll();
        }

        [HttpGet("/users/{id}")]
        public UserResponse GetById(int id)
        {
            return userService.GetById(id);
        }

        [HttpPost("/users")]
        public UserResponse Add([FromForm] UserRegistrationRequest newUser)
        {
            return userService.Add(newUser);
        }

        [HttpPut("/users/{id}")]
        public UserResponse Update([FromForm] UserUpdateRequest updatedUser, int id)
        {
            return userService.Update(updatedUser, id);
        }

        [HttpDelete("/users/{id}")]
        public bool DeleteById(int id)
        {
            return userService.DeleteById(id);
        }

    }
}
