using CommonDbLayer.CommonDbEntities;

namespace AdminApi.Services
{
    public interface IEventService
    {
        List<Event> GetAllEvents();
        string AddEvent(Event events);
        Event GetEventById(long id);
        string UpdateEvents(Event events);
        string DeleteEvent(long id);
    }
}