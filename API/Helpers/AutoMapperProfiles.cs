using System.Linq;
using API.DTOs;
using API.Entities;
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
                  x => x.IsMain).Url)); //get url from this proprety and put it in dest.PhotoUrl

      CreateMap<Photo, PhotoDto>();

    }
  }
}