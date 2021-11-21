using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PetStop_API.Util
{
    public class Base64StringJsonConverter : JsonConverter<byte[]>
    {
        public override byte[] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var dt = reader.GetString();
            return Convert.FromBase64String(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, byte[] value, JsonSerializerOptions options)
        {
            writer.WriteBase64StringValue(value);
        }
    }
}
