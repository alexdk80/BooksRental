using AutoMapper;
using BooksRental.Dtos;
using BooksRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksRental.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
        }
    }
}