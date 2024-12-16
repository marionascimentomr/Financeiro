using AutoMapper;
using Pay.Application.Dtos.Responses;
using Pay.Domain.Moldes;

namespace Pay.Application.Mappings
{
    public class ModelToDtoMap : Profile
    {
        public ModelToDtoMap()
        {
            CreateMap<User, UserResponseDto>();
        }
    }
}
