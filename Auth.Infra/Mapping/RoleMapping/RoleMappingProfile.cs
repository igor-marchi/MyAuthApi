using Auth.Core.Domain;
using Auth.Core.Shared.ViewModels.Role;
using AutoMapper;

namespace Auth.Infra.Mapping.RoleMapping
{
    public class RoleMappingProfile : Profile
    {
        public RoleMappingProfile()
        {
            CreateMap<Role, RoleView>();
        }
    }
}