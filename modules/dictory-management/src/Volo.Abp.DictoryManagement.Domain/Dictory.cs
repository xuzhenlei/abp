using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Volo.Abp.DictoryManagement
{
    public class Dictory : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        public virtual DictoryType Type { get; set; }

        public virtual string Code { get; protected set; }

        public virtual string Name { get; protected set; }

        public virtual int Sort { get; set; }

        public virtual string CoverImage { get; protected set; }

        public virtual string Description { get; protected set; }

        public virtual Guid? ParentId { get;protected set; }

        public virtual List<Dictory> Children { get; set; }

        public virtual List<DataItem> Items { get; set; }

        protected Dictory()
        {

        }

        protected internal Dictory(Guid id, DictoryType type,[NotNull] string code, [NotNull] string name)
            : base(id)
        {
            Type = type;
            Code = code;
            Name = name;
            Items = new List<DataItem>();
            Children = new List<Dictory>();
        }

        protected internal virtual void SetCode([NotNull] string code)
        {
            Code = Check.NotNullOrWhiteSpace(code, nameof(code), DictoryConsts.MaxCodeLength);
        }

        public virtual void SetName([NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name), DictoryConsts.MaxNameLength);
        }

        public virtual void SetParent(Guid? parentId = null)
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
