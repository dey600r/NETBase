using Microservice.Chatbot.Core.Dtos;
using Microservice.Chatbot.DataAccess.Entities;

namespace Microservice.Chatbot.Core.Logic
{
    public interface IChatbotCore
    {
        Task<string> SearchExplanation(string sentence);
        Task<IEnumerable<SearchCoseneItemView>> GetItemsByVector(string sentence);
        Task<object> VectorizeAndSaveData(string plainText);
    }
}
