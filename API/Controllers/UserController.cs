using Application.Entities.Requests;
using Application.Entities.Requests.Create;
using Application.Entities.Requests.Update;
using Application.Interfaces.IServices;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IHttpContextAccessor httpContextAccessor;

        public UserController(IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            this.userService = userService;
            this.httpContextAccessor = httpContextAccessor;
        }

        //[Authorize]
        [HttpGet]
        [Route("getAll")]
        public ActionResult<List<User>> GetAll()
        {
            try
            {
                var user = userService.GetAll();
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet]
        [Route("get")]
        public ActionResult<User> Get()
        {
            try
            {
                var authorizationHeader = httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString();
                if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer "))
                {
                    var token = authorizationHeader.Substring("Bearer ".Length).Trim();
                    string id = userService.GetIdFromToken(token).ToString();

                    var user = userService.GetById(id);
                    return Ok(user);
                }
                else
                {
                    return BadRequest("Invalid token format");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("add")]
        public ActionResult<User> Add(CreateUser createUser)
        {
            try
            {
                userService.Insert(createUser);
                return Ok(createUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPut]
        [Route("update")]
        public ActionResult<User> Update(UpdateUser updateUser)
        {
            try
            {
                userService.Update(updateUser);
                return Ok(updateUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(string id)
        {
            try
            {
                userService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginUser loginUser)
        {
            try
            {
                var tokenObject = new { token = userService.Login(loginUser) };

                return Ok(tokenObject);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
