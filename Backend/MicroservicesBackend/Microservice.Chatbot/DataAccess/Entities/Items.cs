using Pgvector;

namespace Microservice.Chatbot.DataAccess.Entities
{
    public class Items
    {
        public int id { get; set; }
        public string name { get; set; } = null!;
        public string item_data { get; set; } = null!;
        public Vector embedding { get; set; } = null!;
        public Vector embedding_small { get; set; } = null!;
    }
}