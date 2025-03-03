using AutoMapper;
using hunter_api.Extensions;
using hunter_api.Interfaces;
using hunter_api.Models.Request;
using hunter_domain.Interfaces;
using hunter_domain.Models;

namespace hunter_api.Services
{

    public class RegisterPlatesService : IRegisterPlatesService
    {
        private readonly IRegisterPlatesDomain _registerPlatesDomain;
        private readonly IMapper _mapper;
        public RegisterPlatesService(IRegisterPlatesDomain registerPlatesDomain, IMapper mapper)
        {
            _registerPlatesDomain = registerPlatesDomain;
            _mapper = mapper;
        }

        public async Task<bool> RegisterPlates(List<PlatesDataModelRequest> plates)
        {
            var result = await _registerPlatesDomain.InsertPlatesDomain(plates.Select(_ => _mapper.Map<PlatesDataModelDomain>(_)).ToList());

            return true;
        }

        public async Task<List<CollectedPlatesModelDomain>> GetPlate()
        {
            var result = await _registerPlatesDomain.GetPlatesDomain();

            return result;
        }

        public async Task<bool> InsertTablePlates(IFormFile file)
        {

            var data = new List<PlatesDataModelRequest>();

            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                stream.Position = 0;

                data = CsvService.ProcessCsv(stream);
            }

            var result = await _registerPlatesDomain.InsertPlatesDomain(data.Select(_ => _mapper.Map<PlatesDataModelDomain>(_)).ToList());
            return result;
        }

        public async Task DeletePlates(List<DeletePlatesDataModelRequest> plates)
        {
            await _registerPlatesDomain.DeletePlatesDomain(plates.Select(_=> _mapper.Map<DeletePlatesDataModelDomain>(_)).ToList());
        }
    }
}
