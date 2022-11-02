using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace EventRate.Core.Extensions
{
    public static class StringExtensions
    {
        public static string ToJson<T>(this T model)
        {
            JsonSerializerOptions options = new() { Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) };
            return JsonSerializer.Serialize(model, options);
        }
    }
}
