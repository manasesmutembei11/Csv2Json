using System.Globalization;

namespace Csv2Json
{
    public class Validation
    {
        public static string ValidateString(string field, bool isRequired = false)
        {
            if (isRequired && string.IsNullOrWhiteSpace(field))
                throw new ArgumentException("Field is required but was empty");

            if (string.IsNullOrWhiteSpace(field))
                return null;

            return field;
        }

        public static DateTime? ValidateDate(string field)
        {
            if (string.IsNullOrEmpty(field))
                return null;

            var formats = new[]
            {
            "dd-MMM-yy", "dd/MM/yyyy", "dd-MMM-yyyy", "dd-MM-yyyy",
            "d-MMM-yyyy", "d-MMM-yy", "d-MM-yyyy", "d-M-yyyy",
            "yyyy-MM-dd", "dd-MMMM-yy", "d-MMMM-yy", "d-MMMM-yyyy"
            };

            if (DateTime.TryParseExact(field, formats, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces, out var date))
                return date;

            throw new ArgumentException($"Invalid date format: {field}");
        }

        public static decimal? ValidateDecimal(string field)
        {
            if (string.IsNullOrEmpty(field))
                return null;

            string sanitizedField = field.Replace(",", "");

            if (decimal.TryParse(sanitizedField, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out var value))
                return value;

            throw new ArgumentException("Invalid decimal value");
        }
    }
}
