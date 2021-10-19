using System;
using System.Collections.Generic;

namespace PraNomi.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string Price { get; set; }
        public string CustomerName { get; set; }
        public List<string> SelectedProdcuts { get; set; } = new List<string>();
    }
}