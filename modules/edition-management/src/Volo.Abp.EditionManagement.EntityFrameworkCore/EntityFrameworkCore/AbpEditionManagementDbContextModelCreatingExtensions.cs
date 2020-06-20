using System;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Volo.Abp.EditionManagement.EntityFrameworkCore
{
    public static class AbpEditionManagementDbContextModelCreatingExtensions
    {
        public static void ConfigureEditionManagement(
            this ModelBuilder builder,
            Action<AbpEditionManagementModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new AbpEditionManagementModelBuilderConfigurationOptions(
                AbpEditionManagementDbProperties.DbTablePrefix,
                AbpEditionManagementDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            builder.Entity<Edition>(b =>
            {
                //Configure table & schema name
                b.ToTable(options.TablePrefix + "Editions", options.Schema);

                b.ConfigureByConvention();

                //Properties
                b.Property(t => t.Name).IsRequired().HasMaxLength(EditionConsts.MaxNameLength);
                b.Property(e => e.StepUserCounts).HasMaxLength(EditionConsts.MaxStepUserCountsLength);
                b.Property(t => t.CoverImage).HasMaxLength(EditionConsts.MaxCoverImageLength);
                b.Property(e => e.Summary).HasMaxLength(EditionConsts.MaxSummaryLength);
                b.Property(t => t.Description).HasMaxLength(EditionConsts.MaxDescriptionLength);

                //Indexes
                b.HasIndex(u => u.Name);
                b.HasIndex(q => q.CreationTime);
            });
        }
    }
}