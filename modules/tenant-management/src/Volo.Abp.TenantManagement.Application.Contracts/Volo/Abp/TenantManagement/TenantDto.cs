using System;
using Volo.Abp.Application.Dtos;

namespace Volo.Abp.TenantManagement
{
    public class TenantDto : ExtensibleEntityDto<Guid>
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public TenantState State { get; set; }

        public decimal Balance { get; set; }

        public decimal TotalAmount { get; set; }

        public Guid Industry { get; set; }

        public string Contact { get; set; }

        public string Phone { get; set; }

        public string Province { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string License { get; set; }

        public string Description { get; set; }
    }
}