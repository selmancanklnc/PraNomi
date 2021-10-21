using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using PraNomi.Models;
using PraNomi.Services;

namespace PraNomi.ViewModels
{
    public class CustomerViewModel
    {
        public IList<Customer> customerList { get; set; }


        public CustomerViewModel()
        {
           customerList = new ObservableCollection<Customer>();
            CustomerSearchModel searchModel = new CustomerSearchModel()
            {
               
                Page = 0,
                Size = 10,
            };
            var customerResponse = CustomerServices.CustomerList(searchModel);
            customerList = customerResponse.customers;
          

        }

    }
}
