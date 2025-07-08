using System;
using Abp.Domain.Entities;

namespace Covera.PolicyImagingSystem.Domain.Entities
{
    public class PolicyOwner : Entity<long>
    {
        
        public string FullName { get; set; }
        public string IdType { get; set; }
        public string IdNumber { get; set; }
        public DateTime? DOB { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }

        // Foreign Keys
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}