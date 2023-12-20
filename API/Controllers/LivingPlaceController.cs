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
    public class LivingPlaceController : ControllerBase
    {
        private readonly ILivingPlaceService livingPlaceService;
        public LivingPlaceController(ILivingPlaceService livingPlaceService)
        {
            this.livingPlaceService = livingPlaceService;
        }

        [HttpGet]
        [Route("getAll")]
        public ActionResult<List<LivingPlace>> GetAll()
        {
            try
            {
                var livingPlace = livingPlaceService.GetAll();
                return Ok(livingPlace);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("get")]
        public ActionResult<LivingPlace> Get(string id)
        {
            try
            {
                var livingPlace = livingPlaceService.GetById(id);
                return Ok(livingPlace);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getByUserId")]
        public ActionResult<List<LivingPlace>> GetByUserId(string id)
        {
            try
            {
                var livingPlace = livingPlaceService.GetByUserId(id);
                return Ok(livingPlace);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("add")]
        public ActionResult<LivingPlace> Add(CreateLivingPlace createLivingPlace)
        {
            try
            {
                livingPlaceService.Insert(createLivingPlace);
                return Ok(createLivingPlace);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public ActionResult<LivingPlace> Update(UpdateLivingPlace updateLivingPlace)
        {
            try
            {
                livingPlaceService.Update(updateLivingPlace);
                return Ok(updateLivingPlace);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("updateTH")]
        public ActionResult<THUpdate> UpdateTH(THUpdate tHUpdate)
        {
            try
            {
                livingPlaceService.UpdateTH(tHUpdate);
                return Ok(tHUpdate);
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
                livingPlaceService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getRequiredLivingSpace")]
        public ActionResult<LivingPlace> GetRequiredLivingSpace(string id)
        {
            try
            {
                var requiredLivingSpace = livingPlaceService.CheckRequiredLivingSpace(id);
                return Ok(requiredLivingSpace);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
