using AdminApi.Services;
using CommonDbLayer.CommonDbEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdminApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminservice _adminservice;
        private readonly IEventService _eventService;

        public AdminController(IAdminservice adminservice, IEventService eventService)
        {
            _adminservice = adminservice;
            _eventService = eventService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userdetails"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateAccount([FromBody] UserDetail userdetails)
        {
            try
            {
                string result = _adminservice.AddAccount(userdetails);
                if(result != "UserEmail Already exists!")
                {
                    return Ok(result);
                }
                return BadRequest();
                
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]

        public ActionResult GetAllEvents()
        {
            try
            {
                return Ok(_eventService.GetAllEvents());
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetEventById(long id)
        {
            try
            {
                var result = _eventService.GetEventById(id);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest($"Event not Found");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        //[Authorize]
        public ActionResult AddEvent([FromBody] Event events)
        {
            try
            {
                string result = _eventService.AddEvent(events);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return Ok(ex);
            }

        }

        [HttpPut]
        //[Authorize]
        public ActionResult UpdateEvent([FromBody] Event events)
        {
            try
            {
                string result = _eventService.UpdateEvents(events);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return Ok(ex);
            }
        }

        
        [HttpDelete("{id}")]
        public ActionResult DeleteEvent(long id)
        {
            try
            {
                string res = _eventService.DeleteEvent(id);
                if (res != null)
                {
                    return Ok(res);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception)
            {

                throw;
            }
            
            return BadRequest();
        }

    }
}