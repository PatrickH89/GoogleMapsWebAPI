using Newtonsoft.Json;

namespace GoogleMapsWebAPI.Models
{
    // blueprint of address objects which will be saved in sql db
    public class AddressOutputModel
    {
        public int Id { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }

        public string StreetNumber { get; set; }

        public string PostCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public float? Latitude { get; set; } // ger: Breitengrad

        public float? Longitude { get; set; } // ger: Längengrad
    }
}
