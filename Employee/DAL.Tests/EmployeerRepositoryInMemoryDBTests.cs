using System;
using Xunit;
using DAL.Repositories.Impl;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System.Linq;

namespace DAL.Tests
{
    public class EmployeersRepositoryInMemoryDBTests
    {
        private Employeers expectedemployeers;

        public EmployeersContext Context => SqlLiteInMemoryContext();

        private EmployeersContext SqlLiteInMemoryContext()
        {

            var options = new DbContextOptionsBuilder<EmployeersContext>()
                .UseSqlite("DataSource=:memory:")
                .Options;

            var context = new EmployeersContext(options);
            context.Database.OpenConnection();
            context.Database.EnsureCreated();
            return context;
        }

        [Fact]
        public void Create_InputStreetWithId0_SetStreetId1()
        {
            // Arrange
            int expectedListCount = 1;
            var context = SqlLiteInMemoryContext();
            EFUnitOfWork uow = new EFUnitOfWork(context);
            IEmployeersRepository repository = uow.employeers;

            Employeers employeer = new Employeers()
            {
                EmployeersId = 5,
                Name = "test",
                Surname = "testD",
                //TrudBooks = new TrudBook() { TrudBookID = 5 }
            };

            //Act
            repository.Create(employeer);
            uow.Save();
            var factListCount = context.employeers.Count();

            // Assert
            Assert.Equal(expectedListCount, factListCount);
        }

        [Fact]
        public void Delete_InputExistEmployeersId_Removed()
        {
            // Arrange
            int expectedListCount = 0;
            var context = SqlLiteInMemoryContext();
            EFUnitOfWork uow = new EFUnitOfWork(context);
            IEmployeersRepository repository = uow.employeers;
            Employeers employeer = new Employeers()
            {
                //StreetId = 1,
                EmployeersId = 5,
                Name = "test",
                Surname = "testD",
                //TrudBooks = new TrudBook() { TrudBookID = 5 }
            };
            context.employeers.Add(employeer);
            context.SaveChanges();

            //Act
            repository.Delete(employeer.EmployeersId);
            uow.Save();
            var factEmployeerCount = context.employeers.Count();

            // Assert
            Assert.Equal(expectedListCount, factEmployeerCount);
        }

        [Fact]
        public void Get_InputExistStreetId_ReturnStreet()
        {
            // Arrange
            var context = SqlLiteInMemoryContext();
            EFUnitOfWork uow = new EFUnitOfWork(context);
            IEmployeersRepository repository = uow.employeers;
            Employeers expectedStreet = new Employeers()
            {

                EmployeersId = 5,
                Name = "test",
                Surname = "testD",
                //TrudBooks = new TrudBook() { TrudBookID = 5 }
            };
            context.employeers.Add(expectedemployeers);
            context.SaveChanges();

            //Act
            var factEmployeers = repository.Get(expectedemployeers.EmployeersId);

            // Assert
            Assert.Equal(expectedStreet, factEmployeers);
        }
    }
}