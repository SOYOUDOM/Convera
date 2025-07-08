using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
using Covera.PolicyImagingSystem.Core.Helper;

namespace Covera.PolicyImagingSystem.Core.C360.PolicyOwners
{
    [Table("PolicyOwner",Schema = "C360")]
    public class PolicyOwner : EntityNotMap<string>
    {
        [Column("PolicyOwnerNumber")]
        [StringLength(10)]
        public override string Id { get; set; }

        [StringLength(50)]
        public string? FullName { get; set; }

        [StringLength(3)]
        public string? OwnerAge { get; set; }

        [StringLength(10)]
        public string? Gender { get; set; }

        [StringLength(15)]
        public string? PhoneNumber { get; set; }

        [StringLength(50)]
        public string? ClientAddress1 { get; set; }

        [StringLength(50)]
        public string? ClientAddress2 { get; set; }

        [StringLength(50)]
        public string? ClientAddress3 { get; set; }

        [StringLength(50)]
        public string? ClientAddress4 { get; set; }

        [StringLength(50)]
        public string? ClientAddress5 { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}
