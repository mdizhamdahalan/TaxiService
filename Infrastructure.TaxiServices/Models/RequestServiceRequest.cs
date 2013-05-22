using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infrastructure.TaxiServices.Models
{
    public class RequestServiceRequest
    {
        public string PhoneNumber { get; set; }
        public string Location { get; set; }
    }
}