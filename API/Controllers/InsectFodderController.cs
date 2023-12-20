using Application.Entities.Requests.Create;
using Application.Entities.Requests.Update;
using Application.Interfaces.IServices;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InsectFodderController : ControllerBase
    {
        private readonly IInsectFodderService insectFodderService;
        public InsectFodderController(IInsectFodderService insectFodderService)
        {
            this.insectFodderService = insectFodderService;
        }

        [HttpGet]
        [Route("get")]
        public ActionResult<InsectFodder> Get(string insectId, string fodderId)
        {
            try
            {
                var insectFodder = insectFodderService.GetById(insectId, fodderId);
                return Ok(insectFodder);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getByInsectId")]
        public ActionResult<List<InsectFodder>> GetByInsectId(string id)
        {
            try
            {
                var insectFodders = insectFodderService.GetByInsectId(id);
                return Ok(insectFodders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("add")]
        public ActionResult<InsectFodder> Add(InsectFodder insectFodder)
        {
            try
            {
                insectFodderService.Insert(insectFodder);
                return Ok(insectFodder);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public ActionResult<InsectFodder> Update(InsectFodder insectFodder)
        {
            try
            {
                insectFodderService.Update(insectFodder);
                return Ok(insectFodder);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(string insectId, string fodderId)
        {
            try
            {
                insectFodderService.Delete(insectId, fodderId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
