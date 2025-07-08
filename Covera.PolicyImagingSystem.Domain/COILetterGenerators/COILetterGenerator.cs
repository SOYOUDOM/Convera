using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covera.PolicyImagingSystem.Domain.COILetterGenerators
{
    public class COILetterGenerator
    {
        public string PolicyNumber { get; private set; }
        public DateTime IssueDate { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public decimal SumAssured { get; private set; }
        public string PolicyStatus { get; private set; }

        // Owner Info
        public string OwnerName { get; private set; }
        public string OwnerIdType { get; private set; }
        public string OwnerIdNumber { get; private set; }
        public DateTime? OwnerDOB { get; private set; }
        public string OwnerGender { get; private set; }
        public string OwnerAddress { get; private set; }
        public string OwnerPhone { get; private set; }
        public string OwnerEmail { get; private set; }

        // Life Assured Info
        public string LifeAssuredName { get; private set; }
        public string LifeAssuredIdType { get; private set; }
        public string LifeAssuredIdNumber { get; private set; }
        public DateTime LifeAssuredDOB { get; private set; }
        public string LifeAssuredGender { get; private set; }
        public string LifeAssuredAddress { get; private set; }
        public string RelationshipToOwner { get; private set; }
    }
}
