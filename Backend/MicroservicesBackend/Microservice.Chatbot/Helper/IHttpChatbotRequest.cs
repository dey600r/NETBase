namespace Microservice.Chatbot.Helper
{
    public interface IHttpChatbotRequest
    {
        Task<IReadOnlyList<float>> CallEmbeddingOllamaAPI(string sentence);
        Task<string?> CallGenerateContentOllamaAPI(string prompt);
        Task<IReadOnlyList<float>> CallEmbeddingGeminiAPI(string sentence);
        Task<string?> CallGenerateContentGeminiAPI(string prompt);
        Task<HttpResponseMessage> SendPost(string url, object request);
    }
}
