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

        public async Task<CollectedPlatesModel> GetPlatesDomain(string plate)
        {
            var response = await _registerPlatesRepositorie.GetPlates(plate);

            return new CollectedPlatesModel() 
            { 
                CarPlate = response.CarPlate,
                AutoModel = response.AutoModel,
                AutoBrand = response.AutoBrand 
            };
        }

        public async Task<List<InsertedPlatesResultDomain>> InsertPlatesDomain(List<PlatesDataDomain> plates)
        {
            var response = await _registerPlatesRepositorie.InsertPlates(plates.Select(x => new RegisterPlatesModel()
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
                ProcessNumer = x.ProcessNumber,
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
