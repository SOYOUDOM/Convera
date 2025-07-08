using Covera.PolicyImagingSystem.Core.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Covera.PolicyImagingSystem.Core.C360.PolicyHeaders
{
    [Table("PolicyHeader", Schema = "C360")]
    public class PolicyHeader : EntityNotMap<string>
    {
        [Column("PolicyNumber")]
        [StringLength(15)]
        public override string Id { get; set; }

        [StringLength(10)]
        public string PolicyOwnerNumber { get; set; }

        public int? BillFrequencyDescription { get; set; }

        public DateTime SubmissionDate { get; set; }

        public DateTime IssueDate { get; set; }

        public decimal PremiumAmount { get; set; }

        [StringLength(20)]
        public string ContractStatus { get; set; }

        [StringLength(5)]
        public string PlanCode { get; set; }

        [StringLength(100)]
        public string PlanNameEn { get; set; }

        // Consider clarifying what this is: count or FK?
        public long LifeAssured { get; set; }
    }
}