using hunter_domain.Interfaces;
using hunter_domain.Models;
using hunter_repository.Enums;
using hunter_repository.Interface;
using hunter_repository.Models;

namespace hunter_domain.Domain
{
    public class RegisterPlatesDomain : IRegisterPlatesDomain
    {
        protected readonly IRegisterPlatesRepositorie _registerPlatesRepositorie;

        public RegisterPlatesDomain(IRegisterPlatesRepositorie registerPlatesRepositorie)
        {
            _registerPlatesRepositorie = registerPlatesRepositorie;
        }

        public async Task<List<InsertedPlatesResultDomain>> InsertPlatesDomain(List<PlatesDataDomain> plates)
        {
            var response = await _registerPlatesRepositorie.InsertPlatesRepositorie(plates.Select(x => new RegisterPlatesRepositorieModel()
            {
                Company = x.Company,
                CustomerName = x.CustomerName,
                UF = (EFederatedStatesRepositorie)x.UF,
                City = x.City,
                CarPlate = x.CarPlate,
                Chassis = x.Chassis,
                Renavan = x.Renavan,
                AutoBrand = x.AutoBrand,
                AutoModel = x.AutoModel,
                YearManufactore = x.YearManufactore,
                YearModel = x.YearModel,
                Folder = x.Folder,
                ProcessNumer = x.ProcessNumer,
                Status = (EStatusRepositorie)x.Status
            }).ToList());

            var result = response.Select(x => new InsertedPlatesResultDomain()
            {
                CarPlate = x.CarPlate,
                Status = x.Status
            }).ToList();

            return result;
        }
    }
}
