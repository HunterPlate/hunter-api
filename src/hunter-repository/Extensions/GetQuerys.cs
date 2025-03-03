namespace hunter_repository.Extensions
{
    public static class GetQuerys
    {
        public static class Insert
        {
            public static readonly string InsertPlates = "INSERT INTO AutoPlates (\r\n    Id, Company, CustomerName, Contact, UF, City, AutoPlate, Chassis, Renavan, AutoBrand, AutoModel, \r\n    YearManufacture, YearModel, Folder, ProcessNumber, Status\r\n)\r\nSELECT \r\n    UUID(), @Company, @CustomerName, @Contact, @UF, @City, @AutoPlate, @Chassis, @Renavan, \r\n    @AutoBrand, @AutoModel, @YearManufacture, @YearModel, @Folder, @ProcessNumber, @Status\r\nFROM DUAL\r\nWHERE NOT EXISTS (SELECT 1 FROM AutoPlates WHERE AutoPlate = @AutoPlate);\r\n\r\nINSERT INTO InsertedAutoPlates (\r\n    id, id_Auto_Plates, Company, Contact, AutoPlate, AutoModel\r\n)\r\nSELECT \r\n    UUID(), Id, @Company, @Contact, @AutoPlate, @AutoModel\r\nFROM AutoPlates\r\nWHERE AutoPlate = @AutoPlate;\r\n";
        }

        public static class Get
        {
            public static readonly string GetPlates = "SELECT * FROM InsertedAutoPlates IAP WHERE IAP.AutoPlate = @plate";
        }

    }
}
