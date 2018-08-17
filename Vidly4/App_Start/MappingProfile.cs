using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly4.Dtos;
using Vidly4.Models;

namespace Vidly4.App_Start
{
    //180817_3_20:18
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //metoda pobiera daw argumenty source i target. Convention mapper tool - używa konwencji i mapuje obiekty po nazwach prop 
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
        }
    }
}