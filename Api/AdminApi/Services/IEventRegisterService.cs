using CommonDbLayer.CommonDbEntities;

namespace AdminApi.Services
{
    public interface IEventRegisterService
    {
        string RegisterEvent(string currentUserEmail, long eventId, string eventName, string description, DateTime eventDate);
        string DeRegisterEvent(string currentUserEmail, long eventId, string eventName, string description, DateTime eventDate);
        List<EventRegister> GetAllRegisteredEvents(string emailid);

    }
}