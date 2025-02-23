using hunter_repository.Models;

namespace hunter_repository.Interface
{
    public interface IRegisterPlatesRepositorie
    {
        Task<List<InsertedPlatesResultsModel>> InsertPlates(List<RegisterPlatesModel> plates);
        Task<CollectedPlatesModel> GetPlates(string plate);
    }
}
