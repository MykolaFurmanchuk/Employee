using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{
    public class Accountant
        : User
    {
        public Accountant(int userId, string name)
            : base(userId, name, nameof(Accountant))
        {
        }
    }
}