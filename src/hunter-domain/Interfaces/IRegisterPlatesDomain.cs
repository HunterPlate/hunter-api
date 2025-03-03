using hunter_domain.Models;
using hunter_repository.Models;

namespace hunter_domain.Interfaces
{
    public interface IRegisterPlatesDomain
    {
        Task<bool> InsertPlatesDomain(List<PlatesDataModelDomain> plates); 
        Task<CollectedPlatesModelDomain?> GetPlatesDomain(string plate); 
    }
}
