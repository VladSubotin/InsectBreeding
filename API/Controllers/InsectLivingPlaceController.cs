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
    public class InsectLivingPlaceController : ControllerBase
    {
        private readonly IInsectLivingPlaceService insectLivingPlaceService;
        public InsectLivingPlaceController(IInsectLivingPlaceService insectLivingPlaceService)
        {
            this.insectLivingPlaceService = insectLivingPlaceService;
        }

        [HttpGet]
        [Route("get")]
        public ActionResult<InsectLivingPlase> Get(string insectId, string livingPlaseId)
        {
            try
            {
                var insectLivingPlase = insectLivingPlaceService.GetById(insectId, livingPlaseId);
                return Ok(insectLivingPlase);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getByLivingPlaceId")]
        public ActionResult<List<InsectLivingPlase>> GetByLivingPlaceId(string id)
        {
            try
            {
                var insectLivingPlases = insectLivingPlaceService.GetByLivingPlaceId(id);
                return Ok(insectLivingPlases);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("add")]
        public ActionResult<InsectLivingPlase> Add(InsectLivingPlase insectLivingPlase)
        {
            try
            {
                insectLivingPlaceService.Insert(insectLivingPlase);
                return Ok(insectLivingPlase);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public ActionResult<InsectLivingPlase> Update(InsectLivingPlase insectLivingPlase)
        {
            try
            {
                insectLivingPlaceService.Update(insectLivingPlase);
                return Ok(insectLivingPlase);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(string insectId, string livingPlaseId)
        {
            try
            {
                insectLivingPlaceService.Delete(insectId, livingPlaseId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getRequiredTemperature")]
        public ActionResult GetRequiredTemperature(string insectId, string livingPlaseId)
        {
            try
            {
                var requiredTemperature = insectLivingPlaceService.CheckRequiredTemperature(insectId, livingPlaseId);
                return Ok(requiredTemperature);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getRequiredHumidity")]
        public ActionResult GetRequiredHumidity(string insectId, string livingPlaseId)
        {
            try
            {
                var requiredHumidity = insectLivingPlaceService.CheckRequiredHumidity(insectId, livingPlaseId);
                return Ok(requiredHumidity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getRequiredFoddersExistence")]
        public ActionResult GetRequiredFoddersExistence(string insectId, string livingPlaseId)
        {
            try
            {
                var requiredFoddersExistence = insectLivingPlaceService.CheckRequiredFoddersExistence(insectId, livingPlaseId);
                return Ok(requiredFoddersExistence);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getLivingTimeIsUp")]
        public ActionResult GetLivingTimeIsUp(string insectId, string livingPlaseId)
        {
            try
            {
                var livingTimeIsUp = insectLivingPlaceService.CheckLivingTimeIsUp(insectId, livingPlaseId);
                return Ok(livingTimeIsUp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
