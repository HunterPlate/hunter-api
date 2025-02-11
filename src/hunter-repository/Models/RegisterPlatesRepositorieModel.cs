using hunter_repository.Enums;

namespace hunter_repository.Models
{
    public class RegisterPlatesRepositorieModel
    {
        public string Company { get; set; }
        public string CustomerName { get; set; }
        public EFederatedStatesRepositorie UF { get; set; }
        public string City { get; set; }
        public string CarPlate { get; set; }
        public string Chassis { get; set; }
        public long Renavan { get; set; }
        public string AutoBrand { get; set; }
        public string AutoModel { get; set; }
        public int YearManufactore { get; set; }
        public int YearModel { get; set; }
        public string Folder { get; set; }
        public string ProcessNumer { get; set; }
        public EStatusRepositorie Status { get; set; }
    }
}
