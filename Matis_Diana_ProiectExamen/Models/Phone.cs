using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Matis_Diana_ProiectExamen.Models
{

    public class Phone
    {
        public int ID { get; set; }

        [Required, StringLength(50, MinimumLength = 3)]
        [Display(Name = "Phone Model")]
        public string PhoneModel { get; set; }
        [Required, RegularExpression(@".*[gG][bB].*", ErrorMessage="Exprimare exacta in GB")]
        public string Capacity { get; set; }

        [Range(1, 3000)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime LunchDate { get; set; }

        public int BrandID { get; set; }

        public Brand Brand { get; set; }

        public ICollection<PhoneCondition> PhoneConditions { get; set; }
    }
}
