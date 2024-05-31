using AutoMapper;
using project_api.Application.DTOs;
using project_api.Core.Entities;

namespace project_api.Application.Mapper;

public class VetProfile : Profile
{
    public VetProfile()
    {
        CreateMap<Pet, PetDTO>();
    }
}
