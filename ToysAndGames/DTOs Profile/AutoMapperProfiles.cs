using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToysAndGames.DTOs;
using ToysAndGames.Models;

namespace ToysAndGames.DTOs_Profile
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Product, DTOProduct>().ReverseMap();
            CreateMap<DTOCProduct, Product>();
        }
    }
}
