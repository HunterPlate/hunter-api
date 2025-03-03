using CsvHelper;
using CsvHelper.Configuration;
using hunter_api.Enums;
using hunter_api.Models.Request;
using System.Globalization;

namespace hunter_api.Extensions
{
    public static class CsvService
    {
            public static List<PlatesDataModelRequest> ProcessCsv(Stream fileStream)
            {
                var data = new List<PlatesDataModelRequest>();

                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ";",
                    BadDataFound = null
                };

                using (var reader = new StreamReader(fileStream))
                using (var csv = new CsvReader(reader, config))
                {
                    csv.Read();
                    csv.ReadHeader();

                    while (csv.Read())
                    {
                        var item = new PlatesDataModelRequest
                        {
                            Company = csv.GetField(0),
                            CustomerName = csv.GetField(1),
                            Contact = csv.GetField(2),
                            UF = Enum.TryParse<EFederatedStates>(csv.GetField(3), out var uf) ? uf : default,
                            City = csv.GetField(4),
                            AutoPlate = csv.GetField(5),
                            Chassis = csv.GetField(6),
                            Renavan = long.TryParse(csv.GetField(7), out var renavan) ? renavan : 0,
                            AutoBrand = csv.GetField(8),
                            AutoModel = csv.GetField(9),
                            YearManufacture = int.TryParse(csv.GetField(10), out var yearManufactore) ? yearManufactore : 0,
                            YearModel = int.TryParse(csv.GetField(11), out var yearModel) ? yearModel : 0,
                            Folder = csv.GetField(14).ToString(),
                            ProcessNumber = csv.GetField(15),
                            Status = csv.GetField(16).ToLower() == "ativos" ? EStatus.Active : EStatus.Inactive
                        };

                        data.Add(item);
                    }
                }

                return data;
            }
    }
}
