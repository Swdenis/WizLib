using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WizLib_Models.Models;

namespace WizLib_DataAccess.Data.FluentConfig
{
    public class FluentBookConfig : IEntityTypeConfiguration<FluentBook>
    {
        public FluentBookConfig()
        {
        }

        public void Configure(EntityTypeBuilder<FluentBook> modelBuilder)
        {
            modelBuilder.HasKey(b => b.Book_Id);
            modelBuilder.Property(b => b.ISBN).IsRequired().HasMaxLength(15);
            modelBuilder.Property(b => b.Title).IsRequired();
            modelBuilder.Property(b => b.Price).IsRequired();
            //1-to-1 fbook and fbookdetail
            modelBuilder.HasOne(b => b.FluentBookDetail).WithOne(b => b.FluentBook)
                .HasForeignKey<FluentBook>("BookDetail_Id");
            //1-to-many fpublisher and fbook
            modelBuilder.HasOne(b => b.FluentPublisher).WithMany(b => b.fluentBooks)
                .HasForeignKey(b => b.Publisher_IdBook);
        }
    }
}
