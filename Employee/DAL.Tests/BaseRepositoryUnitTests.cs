using System;
using Xunit;
using DAL.Repositories.Impl;
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using System.Linq;
using Catalog;
using Moq;

namespace Catalog.DAL.Tests
{
    class TestEmployeersRepository
        : BaseRepository<Employeers>
    {
        public TestEmployeersRepository(DbContext context)
            : base(context)
        {
        }
    }

    public class BaseRepositoryUnitTests
    {

        [Fact]
        public void Create_InputEmployeersInstance_CalledAddMethodOfDBSetWithEmployeersInstance()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<EmployeersContext>()
                .Options;
            var mockContext = new Mock<EmployeersContext>(opt);
            var mockDbSet = new Mock<DbSet<Employeers>>();
            mockContext
                .Setup(context =>
                    context.Set<Employeers>(
                        ))
                .Returns(mockDbSet.Object);
            //EFUnitOfWork uow = new EFUnitOfWork(mockContext.Object);
            var repository = new TestEmployeersRepository(mockContext.Object);

            Employeers expectedEmployeers = new Mock<Employeers>().Object;

            //Act
            repository.Create(expectedEmployeers);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Add(
                    expectedEmployeers
                    ), Times.Once());
        }

        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<EmployeersContext>()
                .Options;
            var mockContext = new Mock<EmployeersContext>(opt);
            var mockDbSet = new Mock<DbSet<Employeers>>();
            mockContext
                .Setup(context =>
                    context.Set<Employeers>(
                        ))
                .Returns(mockDbSet.Object);
            //EFUnitOfWork uow = new EFUnitOfWork(mockContext.Object);
            //IEmployeersRepository repository = uow.Employeerss;
            var repository = new TestEmployeersRepository(mockContext.Object);

            Employeers expectedEmployeers = new Employeers() { EmployeersId = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedEmployeers.EmployeersId)).Returns(expectedEmployeers);

            //Act
            repository.Delete(expectedEmployeers.EmployeersId);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedEmployeers.EmployeersId
                    ), Times.Once());
            mockDbSet.Verify(
                dbSet => dbSet.Remove(
                    expectedEmployeers
                    ), Times.Once());
        }

        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {
            // Arrange
            DbContextOptions opt = new DbContextOptionsBuilder<EmployeersContext>()
                .Options;
            var mockContext = new Mock<EmployeersContext>(opt);
            var mockDbSet = new Mock<DbSet<Employeers>>();
            mockContext
                .Setup(context =>
                    context.Set<Employeers>(
                        ))
                .Returns(mockDbSet.Object);

            Employeers expectedEmployeers = new Employeers() { EmployeersId = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedEmployeers.EmployeersId))
                    .Returns(expectedEmployeers);
            var repository = new TestEmployeersRepository(mockContext.Object);

            //Act
            var actualEmployeers = repository.Get(expectedEmployeers.EmployeersId);

            // Assert
            mockDbSet.Verify(
                dbSet => dbSet.Find(
                    expectedEmployeers.EmployeersId
                    ), Times.Once());
            Assert.Equal(expectedEmployeers, actualEmployeers);
        }


    }
}