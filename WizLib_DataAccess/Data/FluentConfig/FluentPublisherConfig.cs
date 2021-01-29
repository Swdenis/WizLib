using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WizLib_Models.Models;

namespace WizLib_DataAccess.Data.FluentConfig
{
    public class FluentPublisherConfig: IEntityTypeConfiguration<FluentPublisher>
    {
        public FluentPublisherConfig()
        {
        }

        public void Configure(EntityTypeBuilder<FluentPublisher> modelBuilder)
        {
            modelBuilder.HasKey(b => b.Publisher_Id);
            modelBuilder.Property(b => b.Name).IsRequired();
            modelBuilder.Property(b => b.Location).IsRequired();
        }
    }
}
