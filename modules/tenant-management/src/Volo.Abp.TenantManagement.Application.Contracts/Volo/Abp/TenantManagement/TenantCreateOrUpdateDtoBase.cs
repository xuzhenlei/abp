using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.ObjectExtending;

namespace Volo.Abp.TenantManagement
{
    public abstract class TenantCreateOrUpdateDtoBase : ExtensibleObject
    {
        [Required]
        [StringLength(TenantConsts.MaxNameLength)]
        public string Name { get; set; }

        [StringLength(TenantConsts.MaxDisplayNameLength)]
        public string DisplayName { get; set; }

        public Guid Industry { get; set; }

        [StringLength(TenantConsts.MaxContactLength)]
        public string Contact { get; set; }

        [StringLength(TenantConsts.MaxPhoneLength)]
        public string Phone { get; set; }

        [StringLength(TenantConsts.MaxProvinceLength)]
        public string Province { get; set; }

        [StringLength(TenantConsts.MaxCityLength)]
        public string City { get; set; }

        [StringLength(TenantConsts.MaxAddressLength)]
        public string Address { get; set; }

        [StringLength(TenantConsts.MaxLicenseLength)]
        public string License { get; set; }

        [StringLength(TenantConsts.MaxDescriptionLength)]
        public string Description { get; set; }
    }
}