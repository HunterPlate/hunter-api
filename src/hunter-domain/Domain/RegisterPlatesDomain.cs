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

        public async Task DeletePlatesDomain(List<DeletePlatesDataModelDomain> plates)
        {
            await _registerPlatesRepositorie.DeletePlates(plates.Select(x => _mapper.Map<DeletePlatesModelRepository>(x)).ToList());
        }

        public async Task<List<CollectedPlatesModelDomain>> GetPlatesDomain()
        {
            var response = await _registerPlatesRepositorie.GetPlates();

            var autoPlatesList = new List<CollectedPlatesModelDomain>();

            foreach (var item in response)
            {
                autoPlatesList.Add(_mapper.Map<CollectedPlatesModelDomain>(item));
            }

            return autoPlatesList;
        }

        public async Task<bool> InsertPlatesDomain(List<PlatesDataModelDomain> plates)
        {
            var response = await _registerPlatesRepositorie.InsertPlates(plates.Select(x => _mapper.Map<RegisterPlatesModelRepository>(x)).ToList());

            return response;
        }
    }
}
