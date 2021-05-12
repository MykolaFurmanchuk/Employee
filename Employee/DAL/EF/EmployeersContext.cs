using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using DAL.Entities;

namespace DAL.EF
{
    public class EmployeersContext
        : DbContext
    {
        public DbSet<Employeers> employeers { get; set; }
        public DbSet<Posady> Posadys { get; set; }
        public DbSet<TrudBook> TrudBooks { get; set; }

        public EmployeersContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}
