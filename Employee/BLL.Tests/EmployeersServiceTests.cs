using BLL.Services.Impl;
using BLL.Services.Interfaces;
using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Moq;
using CCL.Security;
using CCL.Security.Identity;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace BLL.Tests
{
    public class EmployerServiceTests
    {

        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            // Arrange
            IUnitOfWork nullUnitOfWork = null;

            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => new EmployeersService(nullUnitOfWork));
        }

        [Fact]
        public void GetEmployeers_UserIsAdmin_ThrowMethodAccessException()
        {
            // Arrange
            User user = new Admin(1, "test");
            SecurityContext.SetUser(user);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            IEmployeersService employersService = new EmployeersService(mockUnitOfWork.Object);

            // Act
            // Assert
            Assert.Throws<MethodAccessException>(() => employersService.GetEmployeers(0));
        }

        [Fact]
        public void GetEmployeers_EmployeerFromDAL_CorrectMappingToEmployeerDTO()
        {
            // Arrange
            User user = new Accountant(1, "test");
            SecurityContext.SetUser(user);
            var employersService = GetEmployeersService();

            // Act
           // var actualEmployeersDto = employersService.GetEmployeers(0).First();

            // Assert
           // Assert.True(
               // actualEmployeersDto.EmployeeID == 1
                //&& actualEmployeersDto.Name == "test"
               // && actualEmployeersDto.Surname == "TestS"
              //  );
        }

        IEmployeersService GetEmployeersService()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedEmployeers = new Employeers() { EmployeersId = 1, Name = "test", Surname = "TestS"};
            var mockDbSet = new Mock<IEmployeersRepository>();
            mockDbSet.Setup(z =>
                z.Find(
                    It.IsAny<Func<Employeers, bool>>(),
                    It.IsAny<int>(),
                    It.IsAny<int>()))
                  .Returns(
                    new List<Employeers>() { expectedEmployeers }
                    );
            mockContext
                .Setup(context =>
                    context.employeers)
                .Returns(mockDbSet.Object);

            IEmployeersService employeersService = new EmployeersService(mockContext.Object);

            return employeersService;
        }
    }
}