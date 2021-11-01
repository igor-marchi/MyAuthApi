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
            //View
            CreateMap<User, UserView>();
            CreateMap<User, AuthenticatedUserView>();

            //Input
            CreateMap<NewUserInput, User>();
            CreateMap<AuthUserInput, User>();
        }
    }
}