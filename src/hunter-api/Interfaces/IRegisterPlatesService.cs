using hunter_api.Models.Request;

namespace hunter_api.Interfaces
{
    public interface IRegisterPlatesService
    {
        Task RegisterPlates(PlatesDataRequest plates);
    }
}
