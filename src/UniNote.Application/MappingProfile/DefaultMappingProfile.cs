using AutoMapper;
using UniNote.Application.Dtos;
using UniNote.Domain.Entities;

namespace UniNote.Application.MappingProfile;

public class DefaultMappingProfile : Profile
{
    public DefaultMappingProfile()
    {
        CreateMap<User, UserDto>();
    }
}