using hunter_repository.Models;

namespace hunter_repository.Interface
{
    public interface IRegisterPlatesRepositorie
    {
        Task<List<InsertedPlatesResults>> InsertPlatesRepositorie(List<RegisterPlatesRepositorieModel> plates);
    }
}
