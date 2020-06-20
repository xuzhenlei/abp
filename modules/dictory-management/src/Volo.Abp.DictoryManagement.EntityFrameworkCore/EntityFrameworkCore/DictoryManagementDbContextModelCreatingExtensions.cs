using System;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Volo.Abp.DictoryManagement.EntityFrameworkCore
{
    public static class DictoryManagementDbContextModelCreatingExtensions
    {
        public static void ConfigureDictoryManagement(
            this ModelBuilder builder,
            Action<DictoryManagementModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new DictoryManagementModelBuilderConfigurationOptions(
                AbpDictoryManagementDbProperties.DbTablePrefix,
                AbpDictoryManagementDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            builder.Entity<Dictory>(b =>
            {
                //Configure table & schema name
                b.ToTable(options.TablePrefix + "Dictory", options.Schema);

                b.ConfigureByConvention();

                //Properties
                b.Property(d => d.Code).IsRequired().HasMaxLength(DictoryConsts.MaxCodeLength);
                b.Property(d => d.Name).IsRequired().HasMaxLength(DictoryConsts.MaxNameLength);
                b.Property(d => d.CoverImage).HasMaxLength(DictoryConsts.MaxCoverImageLength);
                b.Property(d => d.Description).HasMaxLength(DictoryConsts.MaxDescriptionLentth);

                b.Ignore(d => d.Items);

                //Relations
                b.HasMany(d => d.Children).WithOne().HasForeignKey(d => d.ParentId);

                //Indexes
                b.HasIndex(d => d.CreationTime);
            });

            builder.Entity<DataItem>(b =>
            {
                //Configure table & schema name
                b.ToTable(options.TablePrefix + "DataItems", options.Schema);

                b.ConfigureByConvention();

                //Properties
                b.Property(d => d.Name).IsRequired().HasMaxLength(DictoryConsts.MaxNameLength);
                b.Property(d => d.CoverImage).HasMaxLength(DictoryConsts.MaxCoverImageLength);
                b.Property(d => d.Description).HasMaxLength(DictoryConsts.MaxDescriptionLentth);

                //Relations
                b.HasMany(d => d.Children).WithOne().HasForeignKey(d => d.ParentId);
            });
        }
    }
}