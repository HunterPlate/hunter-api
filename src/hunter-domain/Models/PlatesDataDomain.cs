using hunter_api.Enums;

namespace hunter_domain.Models
{
    public class PlatesDataDomain
    {
        public string Company { get; set; }
        public string CustomerName { get; set; }
        public EFederatedStatesDomain UF { get; set; }
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
        public EStatusDomain Status { get; set; }
    }
}
