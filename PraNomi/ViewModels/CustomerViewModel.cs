using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using PraNomi.Models;

namespace PraNomi.ViewModels
{
    public class CustomerViewModel
    {
        public IList<Customer> CustomerList { get; set; }


        public CustomerViewModel()
        {
            try
            {
                CustomerList = new ObservableCollection<Customer>();
                CustomerList.Add(new Customer { CustomerPhone = "05355554025", CustomerName = "Müşteri 1" });
                CustomerList.Add(new Customer { CustomerPhone = "05355554029", CustomerName = "Müşteri 2" });
            }
            catch (Exception ex)
            {

            }
        }

    }
}
