﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleTracking
{
   public class Semi : Vehicle
    {
        public Semi(string year, string vin, string make, string model)
        {
            this.Year = year;
            this.VIN = vin;
            this.make = make;
            this.model = model;
            this.currentStatus = VehicleStatus.STANDBY;
        }       
    }
}
