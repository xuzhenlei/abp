using System;
using Volo.Abp.Application.Dtos;

namespace Volo.Abp.Identity
{
    public class OrganizationUnitDto: ExtensibleFullAuditedEntityDto<Guid>
    {
        /// <summary>
        /// Parent <see cref="OrganizationUnit"/> Id.
        /// Null, if this OU is a root.
        /// </summary>
        public virtual Guid? ParentId { get; set; }

        /// <summary>
        /// Hierarchical Code of this organization unit.
        /// Example: "00001.00042.00005".
        /// This is a unique code for a Tenant.
        /// It's changeable if OU hierarchy is changed.
        /// </summary>
        public virtual string Code { get; set; }

        /// <summary>
        /// Display name of this role.
        /// </summary>
        public virtual string DisplayName { get; set; }
    }
}
