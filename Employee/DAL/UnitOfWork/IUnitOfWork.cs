using DAL.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeersRepository employeers { get; }
        IPosadyRepository Posadys{ get; }
        ITrudBookRepository TrudBooks { get; }
        void Save();
    }
}