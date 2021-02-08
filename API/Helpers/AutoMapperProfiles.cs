using System.Linq;
using API.DTOs;
using API.Entities;
using API.Extentions;
using AutoMapper;

namespace API.Helpers
{
  public class AutoMapperProfiles : Profile
  {
    public AutoMapperProfiles()
    {
      CreateMap<AppUser, MemberDto>()
      .ForMember(
          dest => dest.PhotoUrl, // wisch proprety to affect 
          opt => opt.MapFrom( //options
              src => src.Photos.FirstOrDefault( //where to map from
                  x => x.IsMain).Url))//get url from this proprety and put it in dest.PhotoUrl
       .ForMember(dest => dest.Age,
        opt => opt.MapFrom(
            src => src.DateOfBirth.CalculateAge()));
      CreateMap<Photo, PhotoDto>();

    }
  }
}