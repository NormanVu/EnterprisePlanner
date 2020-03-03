﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.HttpClients
{
    public class CustomersHttpClient : BaseMicroservicesHttpClient
    {
        public CustomersHttpClient()
        {
            this.BaseAddress = new Uri("http://localhost:5001/api/customer");
        }
    }
}
