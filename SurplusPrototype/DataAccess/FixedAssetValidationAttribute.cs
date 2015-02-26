using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SurplusPrototype.Models;
using System.Web.Configuration;
using System.Linq;

namespace SurplusPrototype.DataAccess
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class FixedAssetValidationAttribute : ValidationAttribute
    {
        public static ValidationResult HasValidFixedAssetQuantity(SurplusRequest surplusRequest)
        {
            var barcode = surplusRequest.VTBarcode;
            if (barcode == WebConfigurationManager
                .AppSettings["notFixedAssetSentinel"])
            {
                return ValidationResult.Success;
            }
            else if (surplusRequest.Quantity == 1)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Fixed assets must have a " +
                "quantity equal to one.", new List<string>() { "Quantity" });
        }

        public static ValidationResult FixedAssetWithVTTitleExists(string assetNumber)
        {
            if (assetNumber == WebConfigurationManager
                .AppSettings["notFixedAssetSentinel"])
            {
                return ValidationResult.Success;
            }
            
            var errorMessage = "Virginia Tech does not have title " +
                "to a fixed asset with the number " +
                assetNumber + ".";

            var db = new SurplusDbContext();

            var surplusRequest = db.FixedAssets
                .FirstOrDefault(a => a.AssetNumber == assetNumber);

            if (surplusRequest != null)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(errorMessage);
        }
    }
}