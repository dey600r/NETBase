using Microservice.Chatbot.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microservice.Chatbot.DataAccess.Context
{
    public class ItemsConfiguration: IEntityTypeConfiguration<Items>
    {
        public virtual void Configure(EntityTypeBuilder<Items> builder)
        {
            builder.ToTable("items");
            builder.HasKey(b => b.id);
            builder.Property(x => x.id).UseIdentityAlwaysColumn();
            builder.Property(b => b.name).IsRequired();
            builder.Property(b => b.item_data).HasColumnType("jsonb").IsRequired();
            builder.Property(b => b.embedding).HasColumnType("vector");
        }
    }
}
