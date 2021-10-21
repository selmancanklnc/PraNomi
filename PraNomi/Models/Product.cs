using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PraNomi.Models
{
    public class Product
    {
        public Product()
        {
            UniqueIdentifier = Guid.NewGuid().ToString("N");
        }
        public string productName { get; set; }
        public string stockCode { get; set; }
        public decimal stockAmount { get; set; }
        public double price { get; set; }
        [JsonIgnore]
        public string UniqueIdentifier { get; set; }
        [JsonIgnore]
        public bool IsChecked { get; set; }
    }
    public class ProductSearchModel
    {
     
        public string productSearchQuery { get; set; }
        [JsonProperty("page")]
        public int? Page { get; set; }
        [JsonProperty("size")]
        public int? Size { get; set; }

    }

    public class ProductResponseModel
    {
        public int count { get; set; }
        public int currentPage { get; set; }
        public int currentSize { get; set; }
        public int totalPages { get; set; }
        public List<Product> products { get; set; } = new List<Product>();
    }

}
