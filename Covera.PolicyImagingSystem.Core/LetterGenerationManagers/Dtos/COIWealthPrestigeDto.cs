using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covera.PolicyImagingSystem.Core.LetterGenerationManagers.Dtos
{

    public class COIWealthPrestigeDto
    {
        // Policy Details
        public string PolicyNumber { get; set; }
        public string PlanCode { get; set; }
        public string PlanNameEn { get; set; }
        public string PlanNameKh { get; set; }
        public string IssueDate { get; set; }
        public string ExpiryDate { get; set; }
        public string PremiumAmount { get; set; }

        // Policy Owner Information
        public string OwnerFullName { get; set; }
        public string OwnerGender { get; set; }
        public string OwnerDOB { get; set; }
        public string OwnerPhoneNumber { get; set; }
        public string OwnerFullAddress { get; set; }
        public string OwnerAge { get; set; }

        // Life Assured Information
        public string LifeAssuredFullName { get; set; }
        public string LifeAssuredGender { get; set; }
        public string LifeAssuredDOB { get; set; }
        public string LifeAssuredNationality { get; set; }
        public string LifeAssuredEntryAge { get; set; }
        public string LifeAssuredPhoneNumber { get; set; }
        public string LifeAssuredFullAddress { get; set; }

        // Generation Metadata
        public string PrintDate { get; set; }
        public string CurrentYear { get; set; }

    }
}

