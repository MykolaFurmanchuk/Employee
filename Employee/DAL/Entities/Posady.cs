using System.Collections.Generic;

namespace DAL.Entities
{
    public class Posady
    {
        public int PosadyId { get; set; }
        public ICollection<Employeers> employeers { get; set; }
        public string NamePosady { get; set; }



    }
}
