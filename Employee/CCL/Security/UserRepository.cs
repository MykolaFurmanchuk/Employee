using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DAL.EF;
using CCL.Security.Identity;

namespace DAL.Repositories.Impl
{
    public class UserRepository
         : BaseRepository<User>
    {
        public UserRepository(EmployeersContext context) : base(context)
        {
        }
    }
}