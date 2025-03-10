﻿using hunter_api.Enums;

namespace hunter_api.Models.Request
{
    public class PlatesDataModelRequest
    {
        public string Company { get; set; }
        public string CustomerName { get; set; }
        public string Contact { get; set; }
        public EFederatedStates UF { get; set; }
        public string City { get; set; }
        public string AutoPlate { get; set; }
        public string Chassis { get; set; }
        public long Renavan { get; set; }
        public string AutoBrand { get; set; }
        public string AutoModel { get; set; }
        public int YearManufacture { get; set; }
        public int YearModel { get; set; }
        public string Folder { get; set; }
        public string ProcessNumber { get; set; }
        public EStatus Status { get; set; }
    }
}
