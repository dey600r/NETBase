using Microservice.Chatbot.Core.Dtos;
using Microservice.Chatbot.DataAccess.Context;
using Microservice.Chatbot.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Pgvector;
using Pgvector.EntityFrameworkCore;
using System.Text.Json;

namespace Microservice.Chatbot.DataAccess.Repository
{
    public class ChatbotRepository: IChatbotRepository
    {
        public readonly ChatbotContext _context;

        public ChatbotRepository(ChatbotContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SearchCoseneItemView>> GetItemsByVector(Vector vector, int topN = 5)
        {
            return await _context.Items
                .Where(x => x.embedding != null)
                .Select(x => new SearchCoseneItemView
                {
                    id = x.id,
                    name = x.name,
                    sentence = JsonSerializer.Deserialize<ItemDataModel>(x.item_data).text,
                    distance = x.embedding != null ? x.embedding.CosineDistance(vector) : float.MaxValue,
                    similarity = x.embedding != null ? 1 - x.embedding.CosineDistance(vector) : 0
                })
                .OrderBy(x => x.distance)
                .Take(topN)
                .ToListAsync();
        }

        public async Task<int> SaveItems(List<Items> itemsToInsert)
        {
            _context.Items.AddRange(itemsToInsert);
            return await _context.SaveChangesAsync();
        }
    }
}
