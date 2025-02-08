using AutoMapper;
using Eleven.OralExpert.API.DTOs;
using Eleven.OralExpert.Domain.Entities;

namespace Eleven.OralExpert.Services.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserResponseDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => (int)src.Role))
            .ForMember(dest => dest.ClinicId, opt => opt.MapFrom(src => src.Clinic != null ? src.Clinic.BrandName : "N/A"));
    }
}