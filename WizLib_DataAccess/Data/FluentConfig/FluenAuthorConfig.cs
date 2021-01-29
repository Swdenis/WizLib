using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WizLib_Models.Models;

namespace WizLib_DataAccess.Data.FluentConfig
{
    public class FluentAuthorConfig : IEntityTypeConfiguration<FluentAuthor>
    {
        public FluentAuthorConfig()
        {
        }

        public void Configure(EntityTypeBuilder<FluentAuthor> modelBuilder)
        {
            modelBuilder.HasKey(b => b.Author_Id);
            modelBuilder.Property(b => b.FirstName).IsRequired();
            modelBuilder.Property(b => b.LastName).IsRequired();
            modelBuilder.Ignore(b => b.FullName);
        }
    }
}
