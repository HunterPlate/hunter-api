using hunter_api.Enums;
using hunter_api.Interfaces;
using hunter_api.Models.Request;
using hunter_domain.Interfaces;
using hunter_domain.Models;

namespace hunter_api.Services
{

    public class RegisterPlatesService : IRegisterPlatesService
    {
        private readonly IRegisterPlatesDomain _registerPlatesDomain;
        public RegisterPlatesService(IRegisterPlatesDomain registerPlatesDomain)
        {
            _registerPlatesDomain = registerPlatesDomain;
        }

        public async Task RegisterPlates(List<PlatesDataRequest> plates)
        {
            var result = await _registerPlatesDomain.InsertPlatesDomain(plates.Select(_ => new PlatesDataDomain()
            {
                Company = _.Company,
                CustomerName = _.CustomerName,
                UF = (EFederatedStatesDomain)_.UF,
                City = _.City,
                CarPlate = _.CarPlate,
                Chassis = _.Chassis,
                Renavan = _.Renavan,
                AutoBrand = _.AutoBrand,
                AutoModel = _.AutoModel,
                YearManufactore = _.YearManufactore,
                YearModel = _.YearModel,
                Folder = _.Folder,
                ProcessNumber = _.ProcessNumber,
                Status = (EStatusDomain)_.Status,

            }).ToList());
        }

        public async Task GetPlate(string plate)
        {
            var result = await _registerPlatesDomain.GetPlatesDomain(plate);
        }
    }
}
