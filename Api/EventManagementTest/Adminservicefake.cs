using AdminApi.Services;
using CommonDbLayer.CommonDbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagementTest
{
    internal class Adminservicefake : IAdminservice
    {
        public string AddAccount(UserDetail user)
        {
            throw new NotImplementedException();
        }
    }
}
