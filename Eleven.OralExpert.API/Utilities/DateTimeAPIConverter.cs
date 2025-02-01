using System.Text.Json;
using System.Text.Json.Serialization;

namespace Eleven.OralExpert.API.Utilities;

public class DateTimeAPIConverter : JsonConverter<DateTime>
{
    private const string DateFormat = "dd-MM-yyyy HH:mm:ss";

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    { 
        var stringValue = reader.GetString();
 
        if (string.IsNullOrWhiteSpace(stringValue))
        {
            throw new JsonException("O valor da data no JSON é nulo ou vazio.");
        }
 
        var formats = new[] { "dd-MM-yyyy HH:mm:ss", "yyyy-MM-ddTHH:mm:ss", "MM/dd/yyyy HH:mm:ss" };
        if (DateTime.TryParseExact(stringValue, formats, null, System.Globalization.DateTimeStyles.None, out var date))
        {
            return date;
        }
 
        throw new JsonException($"O valor '{stringValue}' não é uma data válida nos formatos esperados: {string.Join(", ", formats)}.");
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(DateFormat));
    }
}