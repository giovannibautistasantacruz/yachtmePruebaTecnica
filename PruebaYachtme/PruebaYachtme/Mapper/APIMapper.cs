using AutoMapper;
using PruebaAxen_CasaBolsa.Models;
using PruebaYachtme.Models;
using PruebaYachtme.Models.DTO;

namespace PruebaAxen_CasaBolsa.Mapper
{
    public class APIMapper:Profile
    {
        public APIMapper()
        {
            
            CreateMap<Items, ItemAddDTO>().ReverseMap();
            CreateMap<ItemAddDTO, Items>().ReverseMap();
        }
    }
}
