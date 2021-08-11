using System.ComponentModel.DataAnnotations;

namespace GoogleMapsWebAPI.Models
{
    // blueprint of address objects passed in html forms
    public class AddressInputModel
    {
        [Required]
        public string Street { get; set; }

        [Required]
        public string StreetNumber { get; set; }

        [MinLength(5)]
        [MaxLength(5)]
        [Required]
        public string PostCode { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        // id will be created autmatically
    }
}
