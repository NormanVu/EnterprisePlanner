using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubscriptionsMessaging.Models.Abstractions
{
    public interface IEventHandler
    {
        Task Handle();
    }
}
