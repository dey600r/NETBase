
using System.Text.Json.Serialization;

namespace Microservice.Chatbot.Helper
{
    public class HttpChatbotRequest : IHttpChatbotRequest
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public HttpChatbotRequest(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<IReadOnlyList<float>> CallEmbeddingAPI(string sentence)
        {
            var apiKey = GetApiKey();

            var embeddingUrl = GetEmbeddingUrl();

            var request = new GeminiEmbeddingRequest(
                "models/gemini-embedding-2",
                new GeminiContent(new[] { new GeminiPart(sentence) }));

            var response = await SendPost($"{embeddingUrl}?key={Uri.EscapeDataString(apiKey)}", request);

            var embeddingResponse = await response.Content.ReadFromJsonAsync<GeminiEmbeddingResponse>();

            if(embeddingResponse?.Embedding?.Values == null)
            {
                throw new InvalidOperationException("La respuesta del embedding no contiene valores.");
            }
            return embeddingResponse.Embedding.Values;
        }

        public async Task<string?> CallGenerateContentAPI(string prompt)
        {
            var apiKey = GetApiKey();

            var generateContentUrl = GetGenerateContentUrl();

            var request = new GeminiGenerateContentRequest(
                new[]
                {
                    new GeminiGenerateContent(
                        new[]
                        {
                            new GeminiGeneratePart(prompt)
                        })
                });

            var response = await SendPost($"{generateContentUrl}?key={Uri.EscapeDataString(apiKey)}", request);
            var contentResponse = await response.Content.ReadFromJsonAsync<GeminiGenerateContentResponse>();
            return contentResponse?.Candidates?.FirstOrDefault()?.Content?.Parts?.FirstOrDefault()?.Text;
        }

        public async Task<HttpResponseMessage> SendPost(string url, object request)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.PostAsJsonAsync(url, request);
            if (!response.IsSuccessStatusCode)
            {
                var errorBody = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error al generar el embedding. StatusCode: {response.StatusCode}, Details: {errorBody}");

            }
            return response;
        }

        #region Private Methods

        private string GetApiKey()
        {
            var apiKey = _configuration["GoogleAi:ApiKey"];
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new InvalidOperationException("No se encontró GoogleAi:ApiKey en la configuración.");
            }
            return apiKey;
        }

        private string GetEmbeddingUrl()
        {
            var embeddingUrl = _configuration["GoogleAi:EmbeddingUrl"];
            if (string.IsNullOrWhiteSpace(embeddingUrl))
            {
                throw new InvalidOperationException("No se encontró GoogleAi:EmbeddingUrl en la configuración.");
            }
            return embeddingUrl;
        }

        private string GetGenerateContentUrl()
        {
            var generateContentUrl = _configuration["GoogleAi:GenerateContentUrl"];
            if (string.IsNullOrWhiteSpace(generateContentUrl))
            {
                throw new InvalidOperationException("No se encontró GoogleAi:GenerateContentUrl en la configuración.");
            }
            return generateContentUrl;
        }
        #endregion

        #region Private Records for Gemini API

        private sealed record GeminiGenerateContentRequest(
            [property: JsonPropertyName("contents")] IReadOnlyList<GeminiGenerateContent> Contents);

        private sealed record GeminiGenerateContent(
            [property: JsonPropertyName("parts")] IReadOnlyList<GeminiGeneratePart> Parts);

        private sealed record GeminiGeneratePart(
            [property: JsonPropertyName("text")] string Text);

        private sealed record GeminiGenerateContentResponse(
            [property: JsonPropertyName("candidates")] IReadOnlyList<GeminiCandidate>? Candidates);

        private sealed record GeminiCandidate(
            [property: JsonPropertyName("content")] GeminiCandidateContent? Content);

        private sealed record GeminiCandidateContent(
            [property: JsonPropertyName("parts")] IReadOnlyList<GeminiGeneratePart>? Parts);

        private sealed record GeminiEmbeddingRequest(
           [property: JsonPropertyName("model")] string Model,
           [property: JsonPropertyName("content")] GeminiContent Content);

        private sealed record GeminiContent(
            [property: JsonPropertyName("parts")] IReadOnlyList<GeminiPart> Parts);

        private sealed record GeminiPart(
            [property: JsonPropertyName("text")] string Text);

        private sealed record GeminiEmbeddingResponse(
            [property: JsonPropertyName("embedding")] GeminiEmbedding? Embedding);

        private sealed record GeminiEmbedding(
            [property: JsonPropertyName("values")] IReadOnlyList<float> Values);

        #endregion
    }
}
