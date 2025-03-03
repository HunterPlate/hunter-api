using hunter_repository.Models;

namespace hunter_repository.Interface
{
    public interface IRegisterPlatesRepositorie
    {
        Task<bool> InsertPlates(List<RegisterPlatesModelRepository> plates);
        Task<List<CollectedPlatesModelRepository>> GetPlates();
        Task DeletePlates(List<DeletePlatesModelRepository> plates);
    }
}
