using Auth.Core.Domain;
using Auth.Core.Shared.InputModels.User;
using Auth.Core.Shared.ViewModels.User;
using AutoMapper;

namespace Auth.Infra.Mapping.UserMapping
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserView>();
            CreateMap<NewUserInput, User>();
        }
    }
}