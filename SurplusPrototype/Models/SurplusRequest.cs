using SurplusPrototype.DataAccess;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Configuration;

namespace SurplusPrototype.Models
{
    [CustomValidation(typeof(FixedAssetValidationAttribute), "HasValidFixedAssetQuantity")]
    public class SurplusRequest
    {
        public SurplusRequest()
        {
            VTBarcode = WebConfigurationManager
                .AppSettings["notFixedAssetSentinel"];
            Quantity = 1;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(9)]
        [Display(Name = "Virginia Tech asset number")]
        [CustomValidation(typeof(FixedAssetValidationAttribute),
            "FixedAssetWithVTTitleExists")]
        public string VTBarcode { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [StringLength(35)]
        public string Manufacturer { get; set; }

        [StringLength(30)]
        public string Model { get; set; }

        [StringLength(40)]
        [Display(Name = "Serial number")]
        public string SerialNumber { get; set; }

        public int Quantity { get; set; }

        [Display(Name = "Quantity description")]
        public Guid QuantityDescriptionId { get; set; }

        public QuantityDescription QuantityDescription { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Estimated value")]
        public int? EstimatedValue { get; set; }

        [Display(Name = "Condition")]
        public Guid ItemConditionId { get; set; }

        public ItemCondition ItemCondition { get; set; }

        [Required]
        [StringLength(6, MinimumLength = 6,
            ErrorMessage = ACCOUNTING_FUND_ERROR_MSG)]
        [RegularExpression(NUMERIC_ONLY_NO_SPACES_REGEX,
            ErrorMessage = ACCOUNTING_FUND_ERROR_MSG)]
        [Display(Name = "Accounting fund")]
        public string AccountingFund { get; set; }

        [Required]
        [StringLength(6, MinimumLength = 6,
            ErrorMessage = DEPARTMENT_NUMBER_ERROR_MSG)]
        [RegularExpression(NUMERIC_ONLY_NO_SPACES_REGEX, 
            ErrorMessage = DEPARTMENT_NUMBER_ERROR_MSG)]
        [Display(Name = "Organization code")]
        public string DepartmentNumber { get; set; }

        [StringLength(4)]
        [Display(Name = "Mail code")]
        public string MailCode { get; set; }

        [Required]
        public string Building { get; set; }

        [Required]
        [Display(Name = "Room")]
        public string FloorLevel { get; set; }

        [Required]
        [Display(Name = "Contact name")]
        public string ContactName { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Contact phone")]
        [StringLength(10)]
        public string ContactPhone { get; set; }

        [Required]
        [Display(Name = "Authorizer name")]
        public string AuthorizerName { get; set; }

        [StringLength(200)]
        [Display(Name = "Additional details")]
        public string AdditionalDetails { get; set; }

        private const string ACCOUNTING_FUND_ERROR_MSG = 
            "A six digit accounting fund is required.";
        private const string DEPARTMENT_NUMBER_ERROR_MSG = 
            "A six digit organization code is required.";
        private const string NUMERIC_ONLY_NO_SPACES_REGEX = @"^\d+$";           
    }
}