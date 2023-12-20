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
    public class LivingPlaceFodderController : ControllerBase
    {
        private readonly ILivingPlaceFodderService livingPlaceFodderService;
        public LivingPlaceFodderController(ILivingPlaceFodderService livingPlaceFodderService)
        {
            this.livingPlaceFodderService = livingPlaceFodderService;
        }

        [HttpGet]
        [Route("get")]
        public ActionResult<LivingPlaseFodder> Get(string livingPlaseId, string fodderId)
        {
            try
            {
                var livingPlaseFodder = livingPlaceFodderService.GetById(livingPlaseId, fodderId);
                return Ok(livingPlaseFodder);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getByLivingPlaceId")]
        public ActionResult<List<LivingPlaseFodder>> GetByLivingPlaceId(string id)
        {
            try
            {
                var livingPlaseFodders = livingPlaceFodderService.GetByLivingPlaceId(id);
                return Ok(livingPlaseFodders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("add")]
        public ActionResult<LivingPlaseFodder> Add(LivingPlaseFodder livingPlaseFodder)
        {
            try
            {
                livingPlaceFodderService.Insert(livingPlaseFodder);
                return Ok(livingPlaseFodder);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public ActionResult<LivingPlaseFodder> Update(LivingPlaseFodder livingPlaseFodder)
        {
            try
            {
                livingPlaceFodderService.Update(livingPlaseFodder);
                return Ok(livingPlaseFodder);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(string livingPlaseId, string fodderId)
        {
            try
            {
                livingPlaceFodderService.Delete(livingPlaseId, fodderId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getFodderVolumeEnough")]
        public IActionResult CheckFodderVolumeEnough(string livingPlaseId, string fodderId)
        {
            try
            {
                var fodderVolumeEnough = livingPlaceFodderService.CheckFodderVolumeEnough(livingPlaseId, fodderId);
                return Ok(fodderVolumeEnough);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
