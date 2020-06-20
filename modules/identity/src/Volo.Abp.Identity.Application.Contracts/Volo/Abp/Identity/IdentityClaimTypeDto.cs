using System;
using Volo.Abp.Application.Dtos;

namespace Volo.Abp.Identity
{
    public class IdentityClaimTypeDto : EntityDto<Guid>
    {
        public virtual string Name { get; set; }

        public virtual bool Required { get; set; }

        public virtual bool IsStatic { get; set; }

        public virtual string Regex { get; set; }

        public virtual string RegexDescription { get; set; }

        public virtual string Description { get; set; }

        public virtual IdentityClaimValueType ValueType { get; set; }
    }
}
