using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWebApp.Models;

namespace MyWebApp.ViewModels
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }

        public String Title
        {
            get
            {
                if (Customer != null && Customer.ID != 0)
                    return "Edit Customer";

                return "New Customer";
            }
        }
    }
}