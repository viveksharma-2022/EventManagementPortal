using AdminApi.Services;
using CommonDbLayer.CommonDbEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdminApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IEventRegisterService _eventService;

        public MemberController(IEventRegisterService eventService)
        {
           
            _eventService = eventService;
        }

        [HttpGet]
        public IActionResult RegisterEvent(string currentUserEmail, long eventId, string eventName, string description, DateTime eventDate)
        {
            try
            {
                string result = _eventService.RegisterEvent(currentUserEmail, eventId, eventName,description,eventDate);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult DeRegisterEvent(string currentUserEmail, long eventId, string eventName, string description, DateTime eventDate)
        {
            try
            {
                string result = _eventService.DeRegisterEvent(currentUserEmail, eventId, eventName, description, eventDate);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{emailid}")]

        public IActionResult GetAllRegisteredEvents(string emailid)
        {
            try 
            { 
                IEnumerable<EventRegister> result = _eventService.GetAllRegisteredEvents(emailid);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return Ok("You have not Registered any Event!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        
    }
}
