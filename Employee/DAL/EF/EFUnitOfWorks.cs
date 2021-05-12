using DAL.Entities;
using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL.EF
{
    public class EFUnitOfWork
        : IUnitOfWork
    {
        private EmployeersContext db;
        private EmployeersRepository employeersRepository;
        private PosadyRepository posadyRepository;
        private TrudBookRepository trudBookRepository;

        public EFUnitOfWork(EmployeersContext context)
        {
            db = context;
        }
        public IEmployeersRepository employeers
        {
            get
            {
                if (employeersRepository == null)
                    employeersRepository = new EmployeersRepository(db);
                return employeersRepository;
            }
        }

        public ITrudBookRepository TrudBooks
        {
            get
            {
                if (trudBookRepository == null)
                    trudBookRepository = new TrudBookRepository(db);
                return trudBookRepository;
            }
        }
        public IPosadyRepository Posadys
        {
            get
            {
                if (posadyRepository == null)
                    posadyRepository = new PosadyRepository(db);
                return posadyRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}