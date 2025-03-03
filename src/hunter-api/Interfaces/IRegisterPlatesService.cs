using hunter_api.Models.Request;
using hunter_domain.Models;
using hunter_repository.Models;

namespace hunter_api.Interfaces
{
    public interface IRegisterPlatesService
    {
        Task<bool> RegisterPlates(List<PlatesDataModelRequest> plates);
        Task<CollectedPlatesModelDomain> GetPlate(string plate);
        Task<bool> InsertTablePlates(IFormFile file);
    }
}
