using System;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Volo.Abp.TenantManagement.EntityFrameworkCore
{
    public static class AbpTenantManagementDbContextModelCreatingExtensions
    {
        public static void ConfigureTenantManagement(
            this ModelBuilder builder,
            [CanBeNull] Action<AbpTenantManagementModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new AbpTenantManagementModelBuilderConfigurationOptions(
                AbpTenantManagementDbProperties.DbTablePrefix,
                AbpTenantManagementDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            builder.Entity<Tenant>(b =>
            {
                b.ToTable(options.TablePrefix + "Tenants", options.Schema);

                b.ConfigureByConvention();

                b.Property(t => t.Name).IsRequired().HasMaxLength(TenantConsts.MaxNameLength);
                b.Property(t => t.DisplayName).HasMaxLength(TenantConsts.MaxDisplayNameLength);
                b.Property(t => t.License).HasMaxLength(TenantConsts.MaxLicenseLength);
                b.Property(t => t.Contact).HasMaxLength(TenantConsts.MaxContactLength);
                b.Property(t => t.Phone).HasMaxLength(TenantConsts.MaxPhoneLength);
                b.Property(t => t.Province).HasMaxLength(TenantConsts.MaxProvinceLength);
                b.Property(t => t.City).HasMaxLength(TenantConsts.MaxCityLength);
                b.Property(t => t.Address).HasMaxLength(TenantConsts.MaxAddressLength);
                b.Property(t => t.Description).HasMaxLength(TenantConsts.MaxDescriptionLength);

                b.HasMany(u => u.Applications).WithOne().HasForeignKey(uc => uc.TenantId).IsRequired();
                b.HasMany(u => u.ConnectionStrings).WithOne().HasForeignKey(uc => uc.TenantId).IsRequired();

                b.HasIndex(u => u.Name);
            });

            builder.Entity<TenantApplication>(b =>
            {
                b.ToTable(options.TablePrefix + "TenantApplications", options.Schema);

                b.ConfigureByConvention();

                b.HasKey(x => new { x.TenantId, x.EditionId });
            });

            builder.Entity<TenantConnectionString>(b =>
            {
                b.ToTable(options.TablePrefix + "TenantConnectionStrings", options.Schema);

                b.ConfigureByConvention();

                b.HasKey(x => new { x.TenantId, x.Name });

                b.Property(cs => cs.Name).IsRequired().HasMaxLength(TenantConnectionStringConsts.MaxNameLength);
                b.Property(cs => cs.Value).IsRequired().HasMaxLength(TenantConnectionStringConsts.MaxValueLength);
            });
        }
    }
}