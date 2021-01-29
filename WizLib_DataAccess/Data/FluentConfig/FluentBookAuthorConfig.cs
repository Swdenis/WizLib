using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WizLib_Models.Models;

namespace WizLib_DataAccess.Data.FluentConfig
{
    public class FluentBookAuthorConfig : IEntityTypeConfiguration<FluentBookAuthor>
    {
        public FluentBookAuthorConfig()
        {
        }

        public void Configure(EntityTypeBuilder<FluentBookAuthor> modelBuilder)
        {
            modelBuilder.HasKey(ba => new { ba.Author_Id, ba.Book_Id });
            modelBuilder.HasOne(b => b.FluentBook).WithMany(b => b.FluentBookAuthors)
                .HasForeignKey(b => b.Book_Id);
            modelBuilder.HasOne(b => b.FluentAuthor).WithMany(b => b.FluentBookAuthors)
                .HasForeignKey(b => b.Author_Id);
        }
    }
}
