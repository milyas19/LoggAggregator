using Application.GetList;
using AutoMapper;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class LogProfile : Profile
    {
        public LogProfile()
        {
            CreateMap<LoggAggregator, LogDto>();
        }
    }
}
