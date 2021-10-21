using PraNomi.Models;
using PraNomi.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PraNomi.ViewModels
{
    public class ProductSelectViewModel : BaseViewModel
    {
        public ProductSelectViewModel(string selected)
        {
            ProductSearchModel searchModel = new ProductSearchModel()
            {
               
                Page =0,
                Size = 10
            };
            var productResult = ProductServices.ProductList(searchModel);
            productList = productResult.products;

            Selected = selected ?? "";
        }

        private List<Product> productList = new List<Product>();
        private string selected = "";



        public List<Product> ProductList
        {
            get
            {
                //CheckItems(selected.Split(',').ToList()); 
                return productList;
            }
            set
            {
                SetProperty(ref productList, value);
                CheckItems(selected.Split(',').ToList());
            }
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
            foreach (var item in ProductList.Where(x => selected.Contains(x.UniqueIdentifier)))
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