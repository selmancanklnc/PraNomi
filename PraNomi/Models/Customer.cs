using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PraNomi.Models
{
    public partial class Customer
    {
        [JsonProperty("addressLine")]
        public string AddressLine { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("district")]
        public string District { get; set; }

        [JsonProperty("neighborhood")]
        public string Neighborhood { get; set; }

        [JsonProperty("zipCode")]
        public string ZipCode { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("customerName")]
        public string CustomerName { get; set; }

        [JsonProperty("customerTaxNumber")]
        public string CustomerTaxNumber { get; set; }

        [JsonProperty("customerTaxOffice")]
        public string CustomerTaxOffice { get; set; }

        [JsonProperty("customerCitizenShipId")]
        public string CustomerCitizenShipId { get; set; }

        [JsonProperty("customerGsm")]
        public string CustomerGsm { get; set; }

        [JsonProperty("customerPhone")]
        public string CustomerPhone { get; set; }
    }

}
