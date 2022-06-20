using AutoMapper;
using UniNote.Application.Dtos;
using UniNote.Domain.Entities;

namespace UniNote.Application.MappingProfiles;

public class DefaultMappingProfile : Profile
{
    public DefaultMappingProfile()
    {
        CreateMap<User, UserDto>();
    }
}