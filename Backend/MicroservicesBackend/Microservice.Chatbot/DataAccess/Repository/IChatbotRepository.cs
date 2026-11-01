using Microservice.Chatbot.Core.Dtos;
using Microservice.Chatbot.DataAccess.Entities;
using Pgvector;


namespace Microservice.Chatbot.DataAccess.Repository
{
    public interface IChatbotRepository
    {
        Task<IEnumerable<SearchCoseneItemView>> GetItemsByVector(Vector vector, int topK);
        Task<int> SaveItems(List<Items> items);
    }
}
