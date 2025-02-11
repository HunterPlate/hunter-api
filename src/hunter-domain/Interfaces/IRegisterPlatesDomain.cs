using hunter_domain.Models;

namespace hunter_domain.Interfaces
{
    public interface IRegisterPlatesDomain
    {
        Task<List<InsertedPlatesResultDomain>> InsertPlatesDomain(List<PlatesDataDomain> plates); 
    }
}
