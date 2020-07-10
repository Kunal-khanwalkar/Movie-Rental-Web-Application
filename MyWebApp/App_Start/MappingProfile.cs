using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MyWebApp.Models;
using MyWebApp.Dtos;

namespace MyWebApp.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer,CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(Model => Model.ID, opt => opt.Ignore());

            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>().ForMember(Model => Model.ID, opt => opt.Ignore());

            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();
        }
    }
}