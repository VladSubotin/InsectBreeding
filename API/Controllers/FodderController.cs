using Application.Entities.Requests.Create;
using Application.Entities.Requests.Update;
using Application.Interfaces.IServices;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FodderController : ControllerBase
    {
        private readonly IFodderService fodderService;

        public FodderController(IFodderService fodderService)
        {
            this.fodderService = fodderService;
        }

        [HttpGet]
        [Route("getAll")]
        public ActionResult<List<Fodder>> GetAll()
        {
            try
            {
                var fodder = fodderService.GetAll();
                return Ok(fodder);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("get")]
        public ActionResult<Fodder> Get(string id)
        {
            try
            {
                var fodder = fodderService.GetById(id);
                return Ok(fodder);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getByUserId")]
        public ActionResult<List<Fodder>> GetByUserId(string id)
        {
            try
            {
                var fodders = fodderService.GetByUserId(id);
                return Ok(fodders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("add")]
        public ActionResult<Fodder> Add(CreateFodder createFodder)
        {
            try
            {
                fodderService.Insert(createFodder);
                return Ok(createFodder);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public ActionResult<Fodder> Update(UpdateFodder updateFodder)
        {
            try
            {
                fodderService.Update(updateFodder);
                return Ok(updateFodder);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(string id)
        {
            try
            {
                fodderService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
