using System.Text.Json;
using System.Text.Json.Serialization;

namespace GrupparbeteVecka4.Converters;
//---  Syftet med koden är att göra JSON-inläsningen helt krashsäker när du tar emot tal från API:er eller databaser--- 
//---  (t.ex. Supabase), oavsett vilket format datan råkar ha när den skickas.---
public class FlexibleIntConverter : JsonConverter<int>
{
    public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number)
        {
            if (reader.TryGetInt32(out int intValue))
                return intValue;

            if (reader.TryGetDouble(out double doubleValue))
                return (int)Math.Round(doubleValue);
        }

        if (reader.TokenType == JsonTokenType.String)
        {
            if (int.TryParse(reader.GetString(), out int parsedInt))
                return parsedInt;

            if (double.TryParse(reader.GetString(), out double parsedDouble))
                return (int)Math.Round(parsedDouble);
        }

        if (reader.TokenType == JsonTokenType.Null)
        {
            return 0;
        }

        return 0;
    }

    public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value);
    }
}
