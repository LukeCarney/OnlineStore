using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace OnlineStore.Models
{
    public class Order
    {
        [BindNever]
        public int OrderID { get; set; }

        [BindNever]
        public ICollection<CartLine> Lines { get; set; }

        [Required(ErrorMessage ="Please enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the first address line")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Please enter city name")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter county name")]
        public string County { get; set; }

        [Required(ErrorMessage = "Please enter postcode")]
        public string PostCode { get; set; }

        [Required(ErrorMessage = "Please enter country")]
        public string Country { get; set; }
        public string GiftWrap { get; set; }
    }
}
