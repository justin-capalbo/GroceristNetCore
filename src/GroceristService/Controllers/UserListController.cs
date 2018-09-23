using System.Collections.Generic;
using System.Threading.Tasks;
using GroceristLibrary.Interfaces;
using GroceristLibrary.Models;
using Microsoft.AspNetCore.Mvc;

namespace GroceristService.Controllers
{
    [Route("")]
    [ApiController]
    public class UserListController : Controller
    {
        private readonly IListApplicationLogic _listAppLogic;

        public UserListController(IListApplicationLogic listAppLogic)
        {
            _listAppLogic = listAppLogic;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<UserListModel>> GetAll()
        {
            return await _listAppLogic.GetAllUserListsAsync();
        }

        [HttpPost("AddList")]
        public async Task<IActionResult> Post([FromBody] UserListModel userList)
        {
            await _listAppLogic.AddNewUserListAsync(userList);
            return Ok();
        }
    }
}
