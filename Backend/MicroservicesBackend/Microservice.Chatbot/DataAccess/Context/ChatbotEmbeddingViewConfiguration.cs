using Microservice.Chatbot.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microservice.Chatbot.DataAccess.Context
{
    public class ChatbotEmbeddingViewConfiguration : IEntityTypeConfiguration<ChatbotEmbeddingView>
    {
        public virtual void Configure(EntityTypeBuilder<ChatbotEmbeddingView> builder)
        {
            builder.ToTable("chatbot_embedding_view");
            builder.HasKey(b => b.ItemData);
            builder.Property(b => b.ItemData).HasColumnName("item_data").IsRequired();
            builder.Property(b => b.Distance).HasColumnName("distance").IsRequired();
            builder.Property(b => b.Similarity).HasColumnName("similarity").IsRequired();
        }
    }
}
