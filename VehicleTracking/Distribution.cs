using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleTracking
{
    public class Distribution : ILocation
    {
        private List<ILocation> branches;
        private List<Vehicle> vehicles;
        private Guid locationID;
        public List<ILocation> Branches
        {
            get { return branches; }
        }
        public List<Vehicle> Vehicles
        {
            get { return this.vehicles; }
        }

        public Guid LocatonID
        {
            get { return locationID; }
        }

        public Distribution()
        {
            this.branches = new List<ILocation>();
            this.vehicles = new List<Vehicle>();
            this.locationID = Guid.NewGuid();
        }

        public void AddBranch(ILocation newBranch)
        {
            if (!this.branches.Contains(newBranch))
            {
                this.branches.Add(newBranch);
            }
        }

        public void Recieve(Vehicle newVehicle)
        {
            if (newVehicle is Semi)
            {
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
                throw new ArgumentException("Only Semis can be transfered to Distribution");
            }
        }

        public void Transfer(ILocation newLocation, Vehicle transferedVehicle)
        {
            if (HasVehicle(transferedVehicle))
            {
                newLocation.Recieve(transferedVehicle);
                this.vehicles.Remove(transferedVehicle);
            }
            else
            {
                throw new ArgumentException("Vehicle not at this location");
            }
        }

        public bool HasVehicle(Vehicle vehicle)
        {
            return vehicles.Contains(vehicle);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
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
