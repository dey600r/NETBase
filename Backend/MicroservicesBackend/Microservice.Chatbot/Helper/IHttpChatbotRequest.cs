namespace Microservice.Chatbot.Helper
{
    public interface IHttpChatbotRequest
    {
        Task<IReadOnlyList<float>> CallEmbeddingAPI(string sentence);
        Task<string?> CallGenerateContentAPI(string prompt);
        Task<HttpResponseMessage> SendPost(string url, object request);
    }
}
