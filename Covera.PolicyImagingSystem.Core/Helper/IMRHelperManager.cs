using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace Covera.PolicyImagingSystem.Core.Helper
{
    public static class IMRHelperManager
    {
        public static string GetDefaultCssTemplate(IWebHostEnvironment environment, string filename = "style.css")
        {
            var cssFilePath = Path.Combine(environment.WebRootPath, "Templates", "css", filename);

            if (!File.Exists(cssFilePath))
            {
                throw new FileNotFoundException($"CSS file not found: {cssFilePath}");
            }

            return File.ReadAllText(cssFilePath);
        }

        /// <summary>
        /// Converts a decimal or double to a currency-formatted string, e.g. "3,220.00 USD"
        /// </summary>
        public static string ToCurrencyFormat(this decimal amount, string currencySymbol = "USD", string culture = "en-US")
        {
            // Format with thousands separator, 2 decimal places
            var formatted = amount.ToString("N2", CultureInfo.GetCultureInfo(culture));
            return $"{formatted} {currencySymbol}";
        }

        /// <summary>
        /// Converts a double to a currency-formatted string.
        /// </summary>
        public static string ToCurrencyFormat(this double amount, string currencySymbol = "USD", string culture = "en-US")
        {
            var formatted = amount.ToString("N2", CultureInfo.GetCultureInfo(culture));
            return $"{formatted} {currencySymbol}";
        }

        public static string GetHtmlTemplate(IWebHostEnvironment environment, string htmlTemplate)
        {
            var htmlFilePath = Path.Combine(environment.WebRootPath, "Templates", "views", htmlTemplate);

            return !File.Exists(htmlFilePath) ? "" : File.ReadAllText(htmlFilePath);
        }
    }
}
