namespace REPR_API.REPRInfra.RequestExtensions
{
    public static class HttpRequestExtension
    {
        public static async Task<string> ReadAsStringAsync(this Stream requestBody)
        {
            using StreamReader reader = new(requestBody);
            var bodyAsString = await reader.ReadToEndAsync();
            return bodyAsString;
        }
    }
}
