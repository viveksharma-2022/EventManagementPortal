using CommonDbLayer.CommonDbEntities;

namespace AdminApi.Services
{
    public class EventRegisterService : IEventRegisterService
    {
        private readonly EventManagementContext _dbContext;

        public EventRegisterService(EventManagementContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public string RegisterEvent(string currentUserEmail,long eventId, string eventName, string description, DateTime eventDate)
        {
            try
            {
                if (currentUserEmail != null)
                {
                    EventRegister eventdata = new EventRegister();
                    eventdata.MemberEmailId = currentUserEmail;
                    eventdata.EventId = eventId;
                    eventdata.EventName = eventName;
                    eventdata.Description = description;
                    eventdata.EventDate = eventDate;
                    _dbContext.EventRegisters.Add(eventdata);
                    _dbContext.SaveChanges();
                    Registercount(eventdata.EventId);
                    return $"Event Registered successfully";
                }
                else
                {
                    return "Email id is not entered";
                }
            }
            catch (Exception ex)
            {

                return (ex.Message);
            }
        }
        public string Registercount(long? id)
        {
            var eventdata = _dbContext.Events.FirstOrDefault(x => x.EventId == id);
            if (eventdata != null)
            {
                eventdata.RegistrationCount = eventdata.RegistrationCount + 1;
                eventdata.IsRegistered=true;
                _dbContext.Events.Update(eventdata);
                _dbContext.SaveChanges();
                return $"Event Registered";

            }
            else
            {
                return "eventId doesnot exist";
            }
        }
        public List<EventRegister> GetAllRegisteredEvents(string emailid)
        {
            try
            {
                return _dbContext.EventRegisters.Where(x => x.MemberEmailId == emailid).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public string DeRegisterEvent(string currentUserEmail, long eventId, string eventName, string description, DateTime eventDate)
        {
            try
            {
                EventRegister eventlist = _dbContext.EventRegisters.FirstOrDefault(x=>x.EventId==eventId);
                
                if (eventlist != null)
                {                                    
                    _dbContext.EventRegisters.Remove(eventlist);
                    _dbContext.SaveChanges();
                    DeRegistercount(eventlist.EventId);
                    return $"Event DeRegistered successfully";
                }
                else
                {
                    return "Email id is not entered";
                }
            }
            catch (Exception ex)
            {

                return (ex.Message);
            }
        }
        public string DeRegistercount(long? id)
        {
            var eventdata = _dbContext.Events.FirstOrDefault(x => x.EventId == id);
            if (eventdata != null)
            {
                eventdata.RegistrationCount = eventdata.RegistrationCount - 1;
                eventdata.IsRegistered = false;
                _dbContext.Events.Update(eventdata);
                _dbContext.SaveChanges();
                return $"Event Registered";

            }
            else
            {
                return "eventId doesnot exist";
            }
        }
    }
}