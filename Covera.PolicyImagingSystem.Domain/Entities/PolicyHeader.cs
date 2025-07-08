using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using Abp.Domain.Entities;

namespace Covera.PolicyImagingSystem.Domain.Entities
{
    [Table("PolicyHeader",Schema = "C360")]
    public class PolicyHeader : Entity<string>
    {
        [Column("PolicyNumber")] 
        public override string Id { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal SumAssured { get; set; }
        public string PolicyStatus { get; set; }

        // Foreign Keys
        public long PolicyOwnerId { get; set; }

        public long LifeAssuredId { get; set; }
        public LifeAssured LifeAssured { get; set; }

    }
}