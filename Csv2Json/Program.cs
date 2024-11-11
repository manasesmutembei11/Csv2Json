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
        var csvData = ReadCsvWithCsvHelper(csvFilePath);
        string jsonData = JsonConvert.SerializeObject(csvData, Formatting.Indented);
        Console.WriteLine(jsonData);
    }

    static List<Dictionary<string, string>> ReadCsv(string filePath)
    {
        var csvData = new List<Dictionary<string, string>>();
        var lines = File.ReadAllLines(filePath);

        if (lines.Length == 0)
            return csvData;

        var headers = lines[0].Split(',');

        for (int i = 1; i < lines.Length; i++)
        {
            var values = lines[i].Split(',');
            var row = new Dictionary<string, string>();

            for (int j = 0; j < headers.Length; j++)
            {
                row[headers[j]] = j < values.Length ? values[j] : null;
            }

            csvData.Add(row);
        }

        return csvData;
    }
    static List<Dictionary<string, string>> ReadCsvWithCsvHelper(string filePath)
    {
        var csvData = new List<Dictionary<string, string>>();

        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            csv.Read(); // Reads the first row to check for headers
            csv.ReadHeader(); // Reads the header row and sets HeaderRecord

            if (csv.HeaderRecord == null)
            {
                Console.WriteLine("The CSV file is missing headers.");
                return csvData; // Return an empty list if no headers are present
            }

            // Read each row
            while (csv.Read())
            {
                var row = new Dictionary<string, string>();
                foreach (var header in csv.HeaderRecord)
                {
                    if (header == null) continue; // Skip any null headers

                    string value = csv.GetField(header);
                    row[header] = value ?? ""; // Store an empty string if the value is null
                }
                csvData.Add(row);
            }
        }

        return csvData;
    }

}

