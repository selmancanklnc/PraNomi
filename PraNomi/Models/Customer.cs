using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PraNomi.Models
{
    public partial class Customer
    {

        public string customerName { get; set; }
        public string taxNumber { get; set; }
        public string phone { get; set; }
        public string mail { get; set; }

        
    }

    public class CustomerResponseModel
    {
        public int count { get; set; }
        public int currentPage { get; set; }
        public int currentSize { get; set; }
        public int totalPages { get; set; }
        public List<Customer> customers { get; set; }
    }
    public class CustomerSearchModel
    {

        public string customerSearchQuery { get; set; }
        [JsonProperty("page")]
        public int? Page { get; set; }
        [JsonProperty("size")]
        public int? Size { get; set; }

    }

}
