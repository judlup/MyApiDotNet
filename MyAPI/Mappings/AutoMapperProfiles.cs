using AutoMapper;
using MyAPI.Models.Domain;
using MyAPI.Models.Dto;
using MyAPI.Models.DTO;

namespace MyAPI.Mappings {
  public class AutoMapperProfiles : Profile {
    public AutoMapperProfiles() {
      CreateMap<Region, RegionDto>().ReverseMap();
      CreateMap<AddRegionRequestDto, Region>().ReverseMap();
      CreateMap<UpdateRegionRequestDto, RegionDto>().ReverseMap();
      CreateMap<AddWalkRequestDto, Walk>().ReverseMap();
      CreateMap<Walk, WalkDto>().ReverseMap();
      CreateMap<Difficulty, DifficultyDto>().ReverseMap();
      CreateMap<UpdateWalkRequestDto, Walk>().ReverseMap();
    }
  }
}
