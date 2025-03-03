using AutoMapper;
using hunter_domain.Interfaces;
using hunter_domain.Models;
using hunter_repository.Interface;
using hunter_repository.Models;

namespace hunter_domain.Domain
{
    public class RegisterPlatesDomain : IRegisterPlatesDomain
    {
        private readonly IRegisterPlatesRepositorie _registerPlatesRepositorie;
        private readonly IMapper _mapper;

        public RegisterPlatesDomain(IRegisterPlatesRepositorie registerPlatesRepositorie, IMapper mapper)
        {
            _registerPlatesRepositorie = registerPlatesRepositorie;
            _mapper = mapper;
        }

        public async Task<CollectedPlatesModelDomain?> GetPlatesDomain(string plate)
        {
            var response = await _registerPlatesRepositorie.GetPlates(plate);

            return _mapper.Map<CollectedPlatesModelDomain?>(response);
        }

        public async Task<bool> InsertPlatesDomain(List<PlatesDataModelDomain> plates)
        {
            var response = await _registerPlatesRepositorie.InsertPlates(plates.Select(x => _mapper.Map<RegisterPlatesModelRepository>(x)).ToList());

            return response;
        }
    }
}
