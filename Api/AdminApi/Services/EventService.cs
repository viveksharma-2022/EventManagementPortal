using CommonDbLayer.CommonDbEntities;

namespace AdminApi.Services
{
    public class EventService : IEventService
    {
        private readonly EventManagementContext _dbcontext;

        public EventService(EventManagementContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public List<Event> GetAllEvents()
        {
            try
            {
                var eventlist=_dbcontext.Events.Where(x=>x.EventDate>=DateTime.Today).ToList();
                return eventlist;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public Event GetEventById(long id)
        {
            try
            {
                Event events = new Event();
                
                var result= _dbcontext.Events.FirstOrDefault(x => x.EventId == id);
                events.EventId = result.EventId;
                events.EventName = result.EventName;
                events.Description = result.Description;
                events.IsRegistered = result.IsRegistered;
                events.UserEmail=result.UserEmail;
                events.EventDate = result.EventDate;
                //events.EventTime = result.EventTime;
                events.RegistrationCount=result.RegistrationCount;  


                return events;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public string AddEvent(Event events)
        {
            try
            {
                _dbcontext.Events.Add(events);
                _dbcontext.SaveChanges();
                return $"{events.EventName} Added Successfully";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public string UpdateEvents(Event events)
        {
            try
            {
                var eventdata = _dbcontext.Events.FirstOrDefault(x => x.EventId == events.EventId);
                if (eventdata != null)
                {
                    eventdata.EventId = events.EventId;
                    eventdata.EventName = events.EventName;
                    eventdata.Description = events.Description;
                    eventdata.UserEmail = events.UserEmail;
                    eventdata.EventDate = events.EventDate;
                    //eventdata.EventTime = events.EventTime;
                    
                    _dbcontext.Events.Update(eventdata);
                    _dbcontext.SaveChanges();
                    return $"Records has been updated for EventId: {events.EventId}.";
                }
                else
                {
                    return $"Event Id doesn't exist";
                }

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public string DeleteEvent(long id)
        {
            try
            {
                Event events = _dbcontext.Events.Find(id);
                var Title = events.EventName;
                if (events != null)
                {
                    _dbcontext.Events.Remove(events);
                    _dbcontext.SaveChanges();
                    return $"{Title} event has been Deleted !";
                }
                else
                {
                    return "Record is not present.";
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
