using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entities;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;


namespace BLL.Services.Impl
{
    public class EmployeersService
        : IEmployeersService
    {
        private readonly IUnitOfWork _database;
        private int pageSize = 10;

        public EmployeersService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException(
                    nameof(unitOfWork));
            }
            _database = unitOfWork;
        }

        /// <exception cref="MethodAccessException"></exception>
        public IEnumerable<EmployeersDTO> GetEmployeers(int pageNumber)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType == typeof(Admin)
                && userType != typeof(Accountant))
            {
                throw new MethodAccessException();
            }
            var UserId = user.UserId;
            var employeersEntities =
                _database
                    .employeers
                    .Find(z => z.EmployeersId == UserId, pageNumber, pageSize);
            var mapper =
                new MapperConfiguration(
                    cfg => cfg.CreateMap<Employeers, EmployeersDTO>()
                    ).CreateMapper();
            var employeersDto =
                mapper
                    .Map<IEnumerable<Employeers>, List<EmployeersDTO>>(
                        employeersEntities);
            return employeersDto;
        }

        public void AddEmployeer(EmployeersDTO employeers)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if (userType == typeof(Admin)
                && userType == typeof(Accountant))
            {
                throw new MethodAccessException();
            }
            if (employeers == null)
            {
                throw new ArgumentNullException(nameof(employeers));
            }

            validate(employeers);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EmployeersDTO, Employeers>()).CreateMapper();
            var employeersEntity = mapper.Map<EmployeersDTO, Employeers>(employeers);
            _database.employeers.Create(employeersEntity);
        }

        private void validate(EmployeersDTO employeers)
        {
            if (string.IsNullOrEmpty(employeers.Name))
            {
                throw new ArgumentException("Name повинне містити значення!");
            }
        }
    }
}