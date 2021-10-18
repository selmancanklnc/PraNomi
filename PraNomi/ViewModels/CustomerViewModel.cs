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
                for (int i = 0; i < 100; i++)
                {

                    CustomerList.Add(new Customer { CustomerPhone = "05355554025", CustomerName = $"Müşteri {Guid.NewGuid():N}" });
                }

            }
            catch (Exception ex)
            {

            }
        }

    }
}
