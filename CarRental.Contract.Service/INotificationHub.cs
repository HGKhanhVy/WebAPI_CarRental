﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service
{
    public interface INotificationHub
    {
        public Task SendNotification(string message);
    }
}
