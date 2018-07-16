using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleTracking
{
    public class Branch : ILocation
    {
        private List<Vehicle> vehicles;
        private Guid locationID;

        public Guid LocatonID
        {
            get { return locationID; }
        }
        public List<Vehicle> Vehicles
        {
            get { return this.vehicles; }
        }

        public Branch()
        {
            this.locationID = Guid.NewGuid();
        }

        public void Recieve(Vehicle newVehicle)
        {
            if (newVehicle is Van || newVehicle is Truck)
            {
                if (vehicles == null)
                {
                    this.vehicles = new List<Vehicle>();
                }
                if (!HasVehicle(newVehicle))
                {
                    this.vehicles.Add(newVehicle);
                }
                else
                {
                    throw new InvalidOperationException("Vehicle already located here");
                }
            }
            else
            {
                throw new ArgumentException("Only Vans and Trucks can be transfered to branches");
            }
        }

        public void Transfer(ILocation newLocation, Vehicle transferedVehicle)
        {
            newLocation.Recieve(transferedVehicle);
            this.vehicles.Remove(transferedVehicle);
        }

        public bool HasVehicle(Vehicle vehicle)
        {
            return vehicles.Contains(vehicle);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            ILocation r = (ILocation)obj;
            return this.LocatonID.Equals(r.LocatonID);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
