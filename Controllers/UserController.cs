using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cookEaseBackEnd.Models.Dto;
using cookEaseBackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using cookEaseBackEnd.Models;

namespace cookEaseBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _data;
        public UserController(UserService dataFromService){
            _data = dataFromService;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginDto User){
            return _data.Login(User);
        }

        [HttpPost]
        [Route("AddUser")]
        public bool AddUser(CreateAccountDto UserToAdd){
            return _data.AddUser(UserToAdd);
        }

        [HttpPost]
        [Route("UpdateUser")]
        public bool UpdateUser(UserModel userToUpdate){
            return _data.UpdateUser(userToUpdate);
        }

        [HttpPost]
        [Route("UpdateUser/{id}/{username}")]
        public bool UpdateUser(int id, string username){
            return _data.UpdateUsername(id, username);
        }
        
        [HttpPost]
        [Route("DeleteUser/{userToDeleted}")] 
        public bool DeleteUser(string userToDelete){
            return _data.DeleteUser(userToDelete);
        }
        
        [HttpGet]
        [Route("GetUserByUsername/{username}")]
        public UserModel GetUserByUsername(string? username){
            return _data.GetUserByUsername(username);
        }
    }
}