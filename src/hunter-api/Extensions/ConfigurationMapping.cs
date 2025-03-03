using AutoMapper;
using hunter_api.Models.Request;
using hunter_domain.Models;
using hunter_repository.Models;

namespace hunter_api.Extensions
{
    public class ConfigurationMapping : Profile
    {
        public ConfigurationMapping()
        {
            CreateMap<CollectedPlatesModelDomain, CollectedPlatesModelRepository>().ReverseMap();
            CreateMap<PlatesDataModelRequest, PlatesDataModelDomain>().ReverseMap();
            CreateMap<PlatesDataModelDomain, RegisterPlatesModelRepository>().ReverseMap();
            CreateMap<DeletePlatesDataModelDomain, DeletePlatesDataModelRequest>().ReverseMap();
            CreateMap<DeletePlatesDataModelDomain, DeletePlatesModelRepository>().ReverseMap();
        }
    }
}
