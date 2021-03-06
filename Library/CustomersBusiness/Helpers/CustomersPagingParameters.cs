﻿using System;
using System.Collections.Generic;
using System.Text;
using WebApiHelpers.Helpers;

namespace CustomersBusiness.Helpers
{
    public class CustomersPagingParameters : PagingParameters
    {
        //Search values for the customers
        public string Name { get; set; }
        public string Address { get; set; }
        public string Business { get; set; }
    }
}
