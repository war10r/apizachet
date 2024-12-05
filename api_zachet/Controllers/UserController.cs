using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using api_zachet.Interface;
using api_zachet.ActionClass.HelperClass.DTO;

namespace api_zachet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _IUser;
        public UserController(IUser iUser) => _IUser = iUser;

        [HttpGet("Persons")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PersonDTO>>> Get() => await Task.FromResult(_IUser.GetPersons());

        [HttpDelete("Persons/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<List<string>>> Delete(int id) => await Task.FromResult(_IUser.DeletePerson(id));

        [HttpGet("Persons/{name}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PersonDTO>>> Get(string name) => await Task.FromResult(_IUser.GetPerson(name));
    }
}
