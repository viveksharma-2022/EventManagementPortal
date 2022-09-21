using CommonDbLayer.CommonDbEntities;

namespace AdminApi.Services
{
    public class Adminservice : IAdminservice
    {
        private readonly EventManagementContext _dbcontext;

        public Adminservice(EventManagementContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public string AddAccount(UserDetail user)
        {
            try
            {
                bool userAlreadyExists = _dbcontext.UserDetails.Any(x => x.UserEmail == user.UserEmail);
                if (!userAlreadyExists) 
                {
                    _dbcontext.UserDetails.Add(user);
                    _dbcontext.SaveChanges();
                    return $"User Created Successfully";
                }
                else
                {
                    return "UserEmail Already exists!";
                }              

            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
    }
}
