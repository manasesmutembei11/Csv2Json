using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using Newtonsoft.Json;
using CsvHelper;

class Program
{
    static void Main()
    {
        string csvFilePath = "C:\\Users\\Lenovo\\Downloads\\claims.csv";
        var csvData = ReadCsv(csvFilePath);
        string jsonData = JsonConvert.SerializeObject(csvData, Formatting.Indented);
        Console.WriteLine(jsonData);
    }

    static List<Dictionary<string, string>> ReadCsv(string filePath)
    {
        var csvData = new List<Dictionary<string, string>>();

        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csv.Read();
            csv.ReadHeader();

            if (csv.HeaderRecord == null)
            {
                Console.WriteLine("The CSV file is missing headers.");
                return csvData;
            }

            while (csv.Read())
            {
                var row = new Dictionary<string, string>();
                foreach (var header in csv.HeaderRecord)
                {
                    if (header == null) continue;

                    string value = csv.GetField(header);
                    row[header] = value ?? "";
                }
                csvData.Add(row);
            }
        }

        return csvData;
    }

}

