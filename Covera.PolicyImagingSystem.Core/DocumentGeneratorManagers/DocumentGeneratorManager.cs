using System.Runtime.InteropServices;
using System.Transactions;
using Abp.Domain.Uow;
using Covera.PolicyImagingSystem.Application.DocumentGeneratorManagers;
using Covera.PolicyImagingSystem.Core.C360.PolicyHeaders;
using Covera.PolicyImagingSystem.Core.Helper;
using Covera.PolicyImagingSystem.Core.LetterGenerationManagers.Dtos;
using iText.Html2pdf;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Covera.PolicyImagingSystem.Core.DocumentGeneratorManagers
{
    public class DocumentGeneratorManager : IMRDomainServiceBase, IDocumentGeneratorManager

    {
        private readonly IPolicyHeaderManager _policyHeaderManager;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IWebHostEnvironment _environment;
        private readonly IConfigurationManager _configuration;
        public DocumentGeneratorManager(IPolicyHeaderManager policyHeaderManager, IUnitOfWorkManager unitOfWorkManager, IWebHostEnvironment environment, IConfigurationManager configuration)
        {
            _policyHeaderManager = policyHeaderManager;
            _unitOfWorkManager = unitOfWorkManager;
            _environment = environment;
            _configuration = configuration;
        }

        public async Task GenerateCOIDocument(List<PolicyHeader> policyHeaders)
        {
            foreach (var pol in policyHeaders)
            {
                await GenerateCOI(pol);
            }
        }

        private async Task GenerateCOI(PolicyHeader policyHeader)
        {
            using var uow = _unitOfWorkManager.Begin(TransactionScopeOption.RequiresNew);
            var lifeAssures = await _policyHeaderManager.GetLifeAssureAsync(policyHeader.Id);
            var policyOwner = await _policyHeaderManager.GetPolicyOwnerAsync(policyHeader.Id);
            await uow.CompleteAsync();
            var mainLifeAssure = lifeAssures.FirstOrDefault(x => x.LifeAssuredSequence == 1);
            var css = IMRHelperManager.GetDefaultCssTemplate(_environment);

            var letter = new COIWealthPrestigeDto()
            {
                PolicyNumber = policyHeader.Id,
                PlanCode = policyHeader.PlanCode,
                PlanNameEn = policyHeader.PlanNameEn,
                IssueDate = policyHeader.IssueDate.ToShortDateString(),
                ExpiryDate = policyHeader.IssueDate.AddYears(1).ToShortDateString(),
                PremiumAmount = policyHeader.PremiumAmount.ToCurrencyFormat(),

                OwnerFullName = policyOwner.FullName!,
                OwnerGender = policyOwner.Gender! == "M" ? "Male" : "Female",
                OwnerDOB = policyOwner.DateOfBirth.ToShortDateString(),
                OwnerPhoneNumber = policyOwner.PhoneNumber,
                OwnerFullAddress = string.Join(", ", new[] {
                                policyOwner.ClientAddress1,
                                policyOwner.ClientAddress2,
                                policyOwner.ClientAddress3,
                                policyOwner.ClientAddress4,
                                policyOwner.ClientAddress5
                             }.Where(x => !string.IsNullOrWhiteSpace(x))),
                OwnerAge = policyOwner.OwnerAge!,

                LifeAssuredFullName = mainLifeAssure!.FullName,
                LifeAssuredGender = mainLifeAssure.Gender,
                LifeAssuredDOB = mainLifeAssure.DateOfBirth.ToShortDateString(),
                LifeAssuredNationality = mainLifeAssure.Nationality,
                LifeAssuredEntryAge = mainLifeAssure.EntryAge.ToString(),
                LifeAssuredPhoneNumber = mainLifeAssure.PhoneNumber,
                LifeAssuredFullAddress = string.Join(", ", new[] {
                                    mainLifeAssure.ClientAddress1,
                                    mainLifeAssure.ClientAddress2,
                                    mainLifeAssure.ClientAddress3,
                                    mainLifeAssure.ClientAddress4,
                                    mainLifeAssure.ClientAddress5
                                 }.Where(x => !string.IsNullOrWhiteSpace(x))),

                PrintDate = DateTime.Now.ToShortDateString(),
                CurrentYear = DateTime.Now.Year.ToString(),
            };

            var folderPath = Path.Combine(_configuration["LetterStorage:BasePath"]!, PathStatic.COI);

            Directory.CreateDirectory(folderPath);
            var filePath = Path.Combine(folderPath, $"{policyHeader.Id}_COI_{DateTime.Today:yyyy-MM-dd}.pdf");
            await using var f = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            var html = GetCoiWealthPrestigeHtml("COI_En.html", css, letter);
            using var memoryStream = new MemoryStream();
            HtmlConverter.ConvertToPdf(html, memoryStream);
            memoryStream.Position = 0;
            await memoryStream.CopyToAsync(f);
        }

        #region 'HTML Helpers'

        private string GetCoiWealthPrestigeHtml(string htmlTemplate, string css, COIWealthPrestigeDto letter)
        {
            var html = IMRHelperManager.GetHtmlTemplate(_environment, htmlTemplate);

            var tokens = new Dictionary<string, string>
            {
                {"{{css}}", css ?? ""},
                {"{{PolicyNumber}}", letter.PolicyNumber ?? ""},
                {"{{PlanCode}}", letter.PlanCode ?? ""},
                {"{{PlanNameEn}}", letter.PlanNameEn ?? ""},
                {"{{PlanNameKh}}", letter.PlanNameKh ?? ""},
                {"{{IssueDate}}", letter.IssueDate ?? ""},
                {"{{PremiumAmount}}", letter.PremiumAmount ?? ""},
                {"{{OwnerFullName}}", letter.OwnerFullName ?? ""},
                {"{{OwnerGender}}", letter.OwnerGender ?? ""},
                {"{{OwnerDOB}}", letter.OwnerDOB ?? ""},
                {"{{OwnerPhoneNumber}}", letter.OwnerPhoneNumber ?? ""},
                {"{{OwnerFullAddress}}", letter.OwnerFullAddress ?? ""},
                {"{{OwnerAge}}", letter.OwnerAge ?? ""},
                {"{{LifeAssuredFullName}}", letter.LifeAssuredFullName ?? ""},
                {"{{LifeAssuredGender}}", letter.LifeAssuredGender ?? ""},
                {"{{LifeAssuredDOB}}", letter.LifeAssuredDOB ?? ""},
                {"{{LifeAssuredNationality}}", letter.LifeAssuredNationality ?? ""},
                {"{{LifeAssuredEntryAge}}", letter.LifeAssuredEntryAge ?? ""},
                {"{{LifeAssuredPhoneNumber}}", letter.LifeAssuredPhoneNumber ?? ""},
                {"{{LifeAssuredFullAddress}}", letter.LifeAssuredFullAddress ?? ""},
                {"{{PrintDate}}", letter.PrintDate ?? ""},
                {"{{CurrentYear}}", letter.CurrentYear ?? ""}
            };

            foreach (var kv in tokens) 
                html = html.Replace(kv.Key, kv.Value);


            return html;
        }

        #endregion

    }
}
