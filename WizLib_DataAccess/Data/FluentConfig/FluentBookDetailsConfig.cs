using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WizLib_Models.Models;

namespace WizLib_DataAccess.Data.FluentConfig
{
    public class FluentBookDetailsConfig : IEntityTypeConfiguration<FluentBookDetail>
    {
        public FluentBookDetailsConfig()
        {
        }

        public void Configure(EntityTypeBuilder<FluentBookDetail> modelBuilder)
        {
            modelBuilder.HasKey(b => b.BookDetail_Id);
            modelBuilder.Property(b => b.NumberOfChapters).IsRequired();
        }
    }
}
