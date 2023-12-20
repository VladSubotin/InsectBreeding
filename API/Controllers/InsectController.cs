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
    public class InsectController : ControllerBase
    {
        private readonly IInsectService insectService;
        public InsectController(IInsectService insectService)
        {
            this.insectService = insectService;
        }

        [HttpGet]
        [Route("getAll")]
        public ActionResult<List<Insect>> GetAll()
        {
            try
            {
                var insect = insectService.GetAll();
                return Ok(insect);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("get")]
        public ActionResult<Insect> Get(string id)
        {
            try
            {
                var insect = insectService.GetById(id);
                return Ok(insect);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getByUserId")]
        public ActionResult<List<Insect>> GetByUserId(string id)
        {
            try
            {
                var insects = insectService.GetByUserId(id);
                return Ok(insects);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("add")]
        public ActionResult<Insect> Add(CreateInsect createInsect)
        {
            try
            {
                insectService.Insert(createInsect);
                return Ok(createInsect);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public ActionResult<Insect> Update(UpdateInsect updateInsect)
        {
            try
            {
                insectService.Update(updateInsect);
                return Ok(updateInsect);
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
                insectService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
