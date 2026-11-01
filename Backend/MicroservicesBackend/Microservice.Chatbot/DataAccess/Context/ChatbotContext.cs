using Microservice.Chatbot.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microservice.Chatbot.DataAccess.Context
{
    public class ChatbotContext : DbContext
    {
        public ChatbotContext(DbContextOptions<ChatbotContext> options) : base(options)
        {
        }
        public DbSet<Items> Items { get; set; }

        public DbSet<ChatbotEmbeddingView> ChatbotEmbeddingView { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ChatbotContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }

}
