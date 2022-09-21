using AdminApi.Services;
using CommonDbLayer.CommonDbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementTest
{
    public  class EventManagementServiceFakes : IEventService
    {

        private readonly List<Event> _eventsTable;

        public EventManagementServiceFakes()
        {
            _eventsTable = new List<Event>()
            {
                new Event(){ EventId =100,
                    EventName = "Digital Event", Description="This is a Digital Event", IsRegistered = false,
                    UserEmail="sai@gmail.com", EventDate=DateTime.Now,RegistrationCount=0
                },
            };
        }

        public List<Event> GetAllEvents()
        {
            return _eventsTable;
        }
        public Event GetEventById(long id)
        {
            return _eventsTable.Where(a => a.EventId == id)
                .FirstOrDefault();
        }
        
        public string AddEvent(Event events)
        {
            throw new NotImplementedException();
        }

        public string DeleteEvent(long id)
        {
            throw new NotImplementedException();
        }     

        public string UpdateEvents(Event events)
        {
            throw new NotImplementedException();
        }
    }
}
