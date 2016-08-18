﻿using AutoMapper;
using CQRSLiteDemo.Domain.Commands;
using CQRSLiteDemo.Domain.Events.Employees;
using CQRSLiteDemo.Domain.WriteModel.Employees;
using CQRSLiteDemo.Web.Commands.Requests.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRSLiteDemo.Web.Commands.AutoMapperConfig
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<CreateEmployeeRequest, CreateEmployeeCommand>()
                .ConstructUsing(x => new CreateEmployeeCommand(Guid.NewGuid(), x.FirstName, x.LastName, x.DateOfBirth, x.JobTitle));

            CreateMap<EmployeeCreatedEvent, Employee>()
                .ConstructUsing(x => new Employee(x.Id, x.FirstName, x.LastName, x.DateOfBirth, x.JobTitle));
        }
    }
}