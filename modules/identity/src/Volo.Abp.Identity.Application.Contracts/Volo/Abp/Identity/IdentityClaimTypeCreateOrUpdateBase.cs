using Volo.Abp.ObjectExtending;

namespace Volo.Abp.Identity
{
    public abstract class IdentityClaimTypeCreateOrUpdateBase: ExtensibleObject
    {
        public virtual string Name { get; set; }

        public virtual bool Required { get; set; }

        public virtual string Regex { get; set; }

        public virtual string RegexDescription { get; set; }

        public virtual string Description { get; set; }

        public virtual IdentityClaimValueType ValueType { get; set; }
    }
}
