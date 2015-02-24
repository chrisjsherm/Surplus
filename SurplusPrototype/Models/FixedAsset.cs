using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SurplusPrototype.Models
{
    public class FixedAsset
    {
        public int Id { get; set; }

        [Required]
        [StringLength(9)]
        [Index]
        public string AssetNumber { get; set; }
    }
}