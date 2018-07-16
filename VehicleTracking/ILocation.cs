using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleTracking
{
    public interface ILocation
    {
        Guid LocatonID
        { get; }

        void Transfer(ILocation newLocation, Vehicle transferedVehicle);
        void Recieve(Vehicle newVehicle);
        bool HasVehicle(Vehicle vehicle);
    }
}
