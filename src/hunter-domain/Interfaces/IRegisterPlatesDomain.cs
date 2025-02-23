using hunter_domain.Models;
using hunter_repository.Models;

namespace hunter_domain.Interfaces
{
    public interface IRegisterPlatesDomain
    {
        Task<List<InsertedPlatesResultDomain>> InsertPlatesDomain(List<PlatesDataDomain> plates); 
        Task<CollectedPlatesModel> GetPlatesDomain(string plate); 
    }
}
