using DAL.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.EF;
using CCL.Security.Identity;

namespace Catalog.DAL.Repositories.Interfaces
{
    public interface IUserRepository
        : IRepository<User>
    {
    }
}