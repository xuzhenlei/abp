using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities.Auditing;

namespace Volo.Abp.TenantManagement
{
    public class Tenant : FullAuditedAggregateRoot<Guid>
    {
        public virtual string Name { get; protected set; }

        public virtual string DisplayName { get;protected set; }

        public virtual TenantState State { get; protected set; }

        public virtual decimal Balance { get; protected set; }

        public virtual decimal TotalAmount { get; protected set; }

        public virtual Guid Industry { get; protected set; }

        public virtual string Contact { get; protected set; }

        public virtual string Phone { get; protected set; }

        public virtual string Province { get; protected set; }

        public virtual string City { get; protected set; }

        public virtual string Address { get; protected set; }
        
        public virtual string License { get; set; }

        public virtual string Description { get; set; }

        public virtual List<TenantApplication> Applications { get; protected set; }

        public virtual List<TenantConnectionString> ConnectionStrings { get; protected set; }

        protected Tenant()
        {

        }

        protected internal Tenant(Guid id, [NotNull] string name)
            : base(id)
        {
            SetName(name);
            Applications = new List<TenantApplication>();
            ConnectionStrings = new List<TenantConnectionString>();
        }

        protected internal virtual void SetName([NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name), TenantConsts.MaxNameLength);
        }

        public virtual void SetDisplayName([NotNull] string name)
        {
            DisplayName = Check.NotNullOrWhiteSpace(name, nameof(name), TenantConsts.MaxDisplayNameLength);
        }

        protected internal virtual void SetState(TenantState state)
        {
            State = state;
        }

        protected internal virtual void SetBalance(decimal amount)
        {
            Balance = amount;
        }

        protected internal virtual void SetTotalAmount(decimal amount)
        {
            TotalAmount = amount;
        }

        public virtual void SetIndustry(Guid dataItemId)
        {
            Industry = dataItemId;
        }

        public virtual void SetContact([NotNull]string contact)
        {
            Contact = contact;
        }

        public virtual void SetPhone([NotNull]string phone)
        {
            Phone = phone;
        }

        public virtual void SetProvince([NotNull]string province)
        {
            Province = province;
        }

        public virtual void SetCity([NotNull]string city)
        {
            City = city;
        }

        public virtual void SetAddress([NotNull]string address)
        {
            Address = address;
        }

        public virtual void SetApplication(Guid editionId, ApplicationState state)
        {
            var tenantApplication = Applications.FirstOrDefault(t => t.EditionId == editionId);
            if (tenantApplication == null)
            {
                Applications.Add(new TenantApplication(Id, editionId, state));
            }
        }

        public virtual void RemoveApplication(Guid editionId)
        {
            var tenantApplication = Applications.FirstOrDefault(t => t.EditionId == editionId);
            if (tenantApplication != null)
            {
                if (tenantApplication.State != ApplicationState.停用)
                {
                    throw new UserFriendlyException($"应用的状态必须为 {ApplicationState.停用}");
                }
                Applications.Remove(tenantApplication);
            }
        }

        [CanBeNull]
        public virtual string FindDefaultConnectionString()
        {
            return FindConnectionString(Data.ConnectionStrings.DefaultConnectionStringName);
        }

        [CanBeNull]
        public virtual string FindConnectionString(string name)
        {
            return ConnectionStrings.FirstOrDefault(c => c.Name == name)?.Value;
        }

        public virtual void SetDefaultConnectionString(string connectionString)
        {
            SetConnectionString(Data.ConnectionStrings.DefaultConnectionStringName, connectionString);
        }

        public virtual void SetConnectionString(string name, string connectionString)
        {
            var tenantConnectionString = ConnectionStrings.FirstOrDefault(x => x.Name == name);

            if (tenantConnectionString != null)
            {
                tenantConnectionString.SetValue(connectionString);
            }
            else
            {
                ConnectionStrings.Add(new TenantConnectionString(Id, name, connectionString));
            }
        }

        public virtual void RemoveDefaultConnectionString()
        {
            RemoveConnectionString(Data.ConnectionStrings.DefaultConnectionStringName);
        }

        public virtual void RemoveConnectionString(string name)
        {
            var tenantConnectionString = ConnectionStrings.FirstOrDefault(x => x.Name == name);

            if (tenantConnectionString != null)
            {
                ConnectionStrings.Remove(tenantConnectionString);
            }
        }
    }
}