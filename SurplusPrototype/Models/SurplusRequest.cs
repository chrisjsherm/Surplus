using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Device.Location;
using System.Linq;
using System.Web;

namespace SurplusPrototype.Models
{
    public class SurplusRequest
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(9)]
        [Display(Name = "Virginia Tech asset number")]
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
            ErrorMessage = "A six digit accounting fund is required.")]
        [Display(Name = "Accounting fund")]
        public string AccountingFund { get; set; }

        [Required]
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
    }
}