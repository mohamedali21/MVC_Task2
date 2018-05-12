using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Task2.MyHubs
{

    [HubName("ChangeQty")]
    public class ChangeQty : Hub
    {
    }
}