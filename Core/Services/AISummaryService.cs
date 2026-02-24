namespace EMRDash.Core.Services
{
    public class AISummaryService
    {
        private readonly HttpClient _client;

        public AISummaryService(HttpClient client)
        {
            _client = client;
            _client.Timeout = TimeSpan.FromSeconds(10);
        }

        public async Task<string> GenerateAsync(string content)
        {
            var response = await _client.PostAsJsonAsync(
                "http://localhost:8001/summarize",
                new { note_text = content });

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<SummaryResponse>();
            return result!.Summary;
        }

        private record SummaryResponse(string Summary);
    }
}
