using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Volo.Abp.DictoryManagement
{
    public class DataItem : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual Guid DictoryId { get; protected set; }

        public virtual string Name { get; protected set; }

        public virtual int Sort { get; set; }

        public virtual bool IsStatic { get; set; }

        public virtual string CoverImage { get; protected set; }

        public virtual string Description { get; protected set; }

        public virtual Guid? ParentId { get; protected set; }

        public virtual List<DataItem> Children { get; set; }

        protected DataItem()
        {

        }

        protected internal DataItem(Guid dictoryId, Guid itemId, [NotNull] string name)
            : base(itemId)
        {
            DictoryId = dictoryId;
            Name = name;
            Children = new List<DataItem>();
        }

        protected internal virtual void SetName([NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name), DictoryConsts.MaxNameLength);
        }

        protected internal virtual void SetParent(Guid? parentId = null)
        {
            if (parentId == Id)
            {
                throw new UserFriendlyException("禁止选择自己做为父级");
            }
            ParentId = parentId;
        }

        public virtual void SetCoverImage(string coverImage)
        {
            CoverImage = Check.Length(coverImage, nameof(coverImage), DictoryConsts.MaxCoverImageLength);
        }

        public virtual void SetDescription(string description)
        {
            Description = Check.Length(description, nameof(description), DictoryConsts.MaxDescriptionLentth);
        }
    }
}
