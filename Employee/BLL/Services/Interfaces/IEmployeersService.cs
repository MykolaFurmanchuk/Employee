using BLL.DTO;
using System.Collections.Generic;

namespace BLL.Services.Interfaces
{
    public interface IEmployeersService
    {
        IEnumerable<EmployeersDTO> GetEmployeers(int page);
    }
}