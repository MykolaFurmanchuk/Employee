using System.Collections.Generic;

namespace DAL.Entities
{
    public class Employeers
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<Posady> Posady { get; set; }
        public TrudBook TrudBooks { get; set; }
    }
}
