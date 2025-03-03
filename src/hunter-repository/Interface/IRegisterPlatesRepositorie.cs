using hunter_repository.Models;

namespace hunter_repository.Interface
{
    public interface IRegisterPlatesRepositorie
    {
        Task<bool> InsertPlates(List<RegisterPlatesModelRepository> plates);
        Task<CollectedPlatesModelRepository?> GetPlates(string plate);
    }
}
