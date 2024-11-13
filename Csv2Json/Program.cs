using System.Globalization;
using Newtonsoft.Json;
using CsvHelper;
using CsvHelper.Configuration;
using Csv2Json;

class Program
{
    public static void Main()
    {
        var validRecords = new List<ExpaqClaim>();
        var filePath = "";

        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture) { HeaderValidated = null, MissingFieldFound = null }))
        {
            csv.Read();
            csv.ReadHeader();

            while (csv.Read())
            {
                try
                {
                    var record = new ExpaqClaim
                    {
                        DocumentType = Validation.ValidateString(csv.GetField("DOCUMENT TYPE")),
                        DateFiled = Validation.ValidateDate(csv.GetField("DATE FILED")),
                        DateReceived = Validation.ValidateDate(csv.GetField("DATE RECEIVED")),
                        CourtStation = Validation.ValidateString(csv.GetField("COURT STATION")),
                        Rank = Validation.ValidateString(csv.GetField("RANK")),
                        CaseNo = Validation.ValidateString(csv.GetField("CASE NO")),
                        Year = Validation.ValidateString(csv.GetField("YEAR")),
                        Plaintiff = Validation.ValidateString(csv.GetField("PLAINTIFF")),
                        Defendant = Validation.ValidateString(csv.GetField("DEFENDANT")),
                        ThirdPartyAdvocate = Validation.ValidateString(csv.GetField("THIRD PARTY ADVOCATE")),
                        InjuryType = Validation.ValidateString(csv.GetField("INJURY TYPE")),
                        LossDate = Validation.ValidateDate(csv.GetField("LOSS DATE")),
                        InsuredMV = Validation.ValidateString(csv.GetField("INSURED M/V")),
                        ClaimNo = Validation.ValidateString(csv.GetField("CLAIM NUMBER")),
                        Region = Validation.ValidateString(csv.GetField("REGION")),
                        OurAdvocate = Validation.ValidateString(csv.GetField("OUR ADVOCATE")),
                    };

                    validRecords.Add(record);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Validation error: {ex.Message}");
                }
            }
        }

        var json = JsonConvert.SerializeObject(validRecords, Formatting.Indented);
        Console.WriteLine(json);
    }
}

