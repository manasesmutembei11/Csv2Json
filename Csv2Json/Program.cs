using System.Globalization;
using Newtonsoft.Json;
using CsvHelper;
using CsvHelper.Configuration;
using Csv2Json;

class Program
{
    public static void Main()
    {
        var validRecords = new List<ClaimRecord>();
        var filePath = "C:\\Users\\Lenovo\\Downloads\\claim1.csv";

        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture) { HeaderValidated = null, MissingFieldFound = null }))
        {
            csv.Read();
            csv.ReadHeader();

            while (csv.Read())
            {
                try
                {
                    var record = new ClaimRecord
                    {
                        Payroll = Validation.ValidateString(csv.GetField("PAYROLL")),
                        ClaimantName = Validation.ValidateString(csv.GetField("CLAIMANT'S NAME")),
                        IdNumber = Validation.ValidateString(csv.GetField("ID NUMBER")),
                        DateOfLoss = Validation.ValidateDate(csv.GetField("DATE OF LOSS")),
                        IntimationDate = Validation.ValidateDate(csv.GetField("INTIMATION DATE")),
                        BritamClaimNo = Validation.ValidateString(csv.GetField("BRITAM CLAIM NO.")),
                        NatureOfLoss = Validation.ValidateString(csv.GetField("NATURE OF LOSS")),
                        Scheme = Validation.ValidateString(csv.GetField("SCHEME")),
                        NatureOfInjury = Validation.ValidateString(csv.GetField("NATURE OF INJURY")),
                        Service = Validation.ValidateString(csv.GetField("SERVICE")),
                        OriginalReserve = Validation.ValidateDecimal(csv.GetField("Original reserve")),
                        TotalPaid = Validation.ValidateDecimal(csv.GetField("TOTAL PAID")),
                        PaidToService = Validation.ValidateDecimal(csv.GetField("PAID TO SERVICE")),
                        DoctorsFee = Validation.ValidateDecimal(csv.GetField("DOCTORS' FEE")),
                        PTD = Validation.ValidateDecimal(csv.GetField("PTD")),
                        TTD = Validation.ValidateDecimal(csv.GetField("TTD")),
                        OccupationalDisease = Validation.ValidateDecimal(csv.GetField("OCCUPATIONAL DISEAS")),
                        DeathFee = Validation.ValidateDecimal(csv.GetField("DEATH")),
                        MedicalFee = Validation.ValidateDecimal(csv.GetField("MEDICAL FEES")),
                        CurrentOs = Validation.ValidateDecimal(csv.GetField("CURRENT OS")),
                        IncurredLessDF = Validation.ValidateDecimal(csv.GetField("Incurred less doctor's fee")),
                        IncurredAmount = Validation.ValidateDecimal(csv.GetField("Incurred Amount (Paid+OS)")),
                        DocumentationStatus = Validation.ValidateString(csv.GetField("Documentation Status")),
                        PaymentStatus = Validation.ValidateString(csv.GetField("PAYMENT STATUS")),
                        EndToEndTAT = Validation.ValidateString(csv.GetField("END TO END TAT")),
                        DateFullyDocumented = Validation.ValidateDate(csv.GetField("DATE FULLY DOCUMENTED")),
                        DocumentationTAT = Validation.ValidateString(csv.GetField("Documentation TAT")),
                        DvIssueDate = Validation.ValidateDate(csv.GetField("DV ISSUED DATE")),
                        DvIssueTAT = Validation.ValidateString(csv.GetField("DV ISSUE TAT")),
                        DvReceiveDate = Validation.ValidateDate(csv.GetField("DV RECEIVED DATE")),
                        DatePaid = Validation.ValidateDate(csv.GetField("date paid/declined")),
                        DateRemitted = Validation.ValidateDate(csv.GetField("DATE REMITTED")),
                        TATFinance = Validation.ValidateString(csv.GetField("TAT FINANCE")),
                        PaymentRequisitionNo = Validation.ValidateString(csv.GetField("payment requisition no.")),
                        Station = Validation.ValidateString(csv.GetField("STATION")),
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

