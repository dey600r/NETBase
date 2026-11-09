
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

        public async Task<IReadOnlyList<float>> CallEmbeddingOllamaAPI(string sentence)
        {
            var embeddingUrl = GetEmbeddingUrl("OllamaAI");

            var request = new OllamaEmbeddingRequest("nomic-embed-text", sentence);

            var response = await SendPost($"{embeddingUrl}", request);

            var embeddingResponse = await response.Content.ReadFromJsonAsync<OllamaEmbeddingResponse>();
            var values = embeddingResponse?.Embeddings?.FirstOrDefault();

            if (values == null)
            {
                throw new InvalidOperationException("La respuesta del embedding no contiene valores.");
            }
            return values;
        }

        public async Task<string?> CallGenerateContentOllamaAPI(string prompt)
        {
            var generateContentUrl = GetGenerateContentUrl("OllamaAI");

            var request = new OllamaGenerateContentRequest("gemma3:1b", new[] { new OllamaMessage("user", prompt) }, false);

            var response = await SendPost($"{generateContentUrl}", request);
            var contentResponse = await response.Content.ReadFromJsonAsync<OllamaGenerateContentResponse>();
            return contentResponse?.Message?.Content;
        }

        public async Task<IReadOnlyList<float>> CallEmbeddingGeminiAPI(string sentence)
        {
            var apiKey = GetApiKey();

            var embeddingUrl = GetEmbeddingUrl("GoogleAi");

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

        public async Task<string?> CallGenerateContentGeminiAPI(string prompt)
        {
            var apiKey = GetApiKey();

            var generateContentUrl = GetGenerateContentUrl("GoogleAi");

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

        private string GetEmbeddingUrl(string property)
        {
            var embeddingUrl = _configuration[$"{property}:EmbeddingUrl"];
            if (string.IsNullOrWhiteSpace(embeddingUrl))
            {
                throw new InvalidOperationException($"No se encontró {property}:EmbeddingUrl en la configuración.");
            }
            return embeddingUrl;
        }

        private string GetGenerateContentUrl(string property)
        {
            var generateContentUrl = _configuration[$"{property}:GenerateContentUrl"];
            if (string.IsNullOrWhiteSpace(generateContentUrl))
            {
                throw new InvalidOperationException($"No se encontró {property}:GenerateContentUrl en la configuración.");
            }
            return generateContentUrl;
        }
        #endregion

        #region Private Records for Ollama API

        private sealed record OllamaGenerateContentRequest(
           [property: JsonPropertyName("model")] string Model,
           [property: JsonPropertyName("messages")] IReadOnlyList<OllamaMessage> Content,
           [property: JsonPropertyName("stream")] bool Stream);

        private sealed record OllamaMessage(
            [property: JsonPropertyName("role")] string Role,
            [property: JsonPropertyName("content")] string Content);

        private sealed record OllamaGenerateContentResponse(
            [property: JsonPropertyName("model")] string Model,
            [property: JsonPropertyName("created_at")] string CreatedAt,
            [property: JsonPropertyName("message")] OllamaMessage Message);

        private sealed record OllamaEmbeddingRequest(
            [property: JsonPropertyName("model")] string Model,
            [property: JsonPropertyName("input")] string Input);

        private sealed record OllamaEmbeddingResponse(
            [property: JsonPropertyName("model")] string Model,
            [property: JsonPropertyName("embeddings")] IReadOnlyList<IReadOnlyList<float>> Embeddings);

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
