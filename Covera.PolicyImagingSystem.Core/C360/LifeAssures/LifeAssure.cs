using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Covera.PolicyImagingSystem.Core.Helper;

namespace Covera.PolicyImagingSystem.Core.C360.LifeAssures
{
    [Table("LifeAssured", Schema = "C360")]
    public class LifeAssure : EntityNotMap<string>
    {
        [Column("PolicyNumber")]
        [StringLength(15)]
        public string Id { get; set; }

        [StringLength(15)]
        public string LifeAssuredNumber { get; set; }

        [Column("PolicyOwnerFlag")]
        [StringLength(2)]
        public string PolicyOwnerFlag { get; set; }

        public int LifeAssuredSequence { get; set; }

        [StringLength(50)]
        public string FullName { get; set; }

        [StringLength(5)]
        public string Nationality { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [StringLength(2)]
        public string Gender { get; set; }

        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        public string ClientAddress1 { get; set; }

        [StringLength(50)]
        public string ClientAddress2 { get; set; }

        [StringLength(50)]
        public string ClientAddress3 { get; set; }

        [StringLength(50)]
        public string ClientAddress4 { get; set; }

        [StringLength(50)]
        public string ClientAddress5 { get; set; }

        public int EntryAge { get; set; }
    }
}