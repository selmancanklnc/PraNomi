using PraNomi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PraNomi.ViewModels
{
    [QueryProperty(nameof(Selected), nameof(Selected))]
    public class ProductSelectViewModel : BaseViewModel
    {
        public ProductSelectViewModel()
        {
            productList.Add(new ProductSelectModel() { Text = "A" });
            productList.Add(new ProductSelectModel() { Text = "B" });
            productList.Add(new ProductSelectModel() { Text = "C" });
            productList.Add(new ProductSelectModel() { Text = "D" });
        }
        private List<ProductSelectModel> productList = new List<ProductSelectModel>();
        private string selected;



        public List<ProductSelectModel> ProductList
        {
            get => productList;
            set => SetProperty(ref productList, value);
        }
        public string Selected
        {
            get
            {
                return selected;
            }
            set
            {
                selected = value;
                CheckItems(selected.Split(',').ToList());
            }

        }

        public void CheckItems(List<string> selected)
        {
            foreach (var item in ProductList.Where(x => selected.Contains(x.Text)))
            {
                item.IsChecked = true;
            }
        }
    }
    public class ProductSelectModel
    {
        public string Text { get; set; }
        public bool IsChecked { get; set; }
    }
}