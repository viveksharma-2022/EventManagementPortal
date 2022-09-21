using CommonDbLayer.CommonDbEntities;

namespace AdminApi.Services
{
    public interface IAdminservice
    {
        string AddAccount(UserDetail user);
    }
}