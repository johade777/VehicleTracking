using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VehicleTracking;

namespace TrackingUnitTests
{
    [TestClass]
    public class DistributionUnitTests
    {
        public void AddBranch()
        {
            Distribution myDistribution = new Distribution();
            Branch myBranch = new Branch();
            myDistribution.AddBranch(myBranch);
            Assert.IsTrue(myDistribution.Branches.Contains(myBranch));
            Assert.AreEqual(1, myDistribution.Branches.Count);
        }

        [TestMethod]
        public void AddBranchOnlyOnce()
        {
            Distribution myDistribution = new Distribution();
            Branch myBranch = new Branch();
            myDistribution.AddBranch(myBranch);
            myDistribution.AddBranch(myBranch);
            Assert.IsTrue(myDistribution.Branches.Contains(myBranch));
            Assert.AreEqual(1, myDistribution.Branches.Count);
        }

        [TestMethod]
        public void RecieveVehicle()
        {
            Semi mycar = new Semi("1999", "asdfgsdsafadsfasdas12345", "Nissan", "Altima");
            Distribution myDistribution = new Distribution();
            myDistribution.Recieve(mycar);
            Assert.AreEqual(mycar, myDistribution.Vehicles[0]);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void DistributionTruckRecieve()
        {
            Truck mycar = new Truck("1999", "asdfgsdsafadsfasdas12345", "Nissan", "Altima");
            Distribution myDistribution = new Distribution();
            myDistribution.Recieve(mycar);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void DistributionVanRecieve()
        {
            Van mycar = new Van("1999", "asdfgsdsafadsfasdas12345", "Nissan", "Altima");
            Distribution myDistribution = new Distribution();
            myDistribution.Recieve(mycar);
        }

        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public void RecieveVehicleOnlyOnce()
        {
            Semi mycar = new Semi("1999", "asdfgsdsafadsfasdas12345", "Nissan", "Altima");
            Distribution myDistribution = new Distribution();
            myDistribution.Recieve(mycar);
            myDistribution.Recieve(mycar);
            Assert.AreEqual(1, myDistribution.Vehicles.Count);
        }

        [TestMethod]
        public void TransferSemiFromToDistribtion()
        {
            Semi mycar = new Semi("1999", "asdfgsdsafadsfasdas12345", "Nissan", "Altima");
            Distribution myDistributionSend = new Distribution();
            Distribution myDistributionRecieve = new Distribution();
            myDistributionSend.Recieve(mycar);
            myDistributionSend.Transfer(myDistributionRecieve, mycar);

            Assert.AreEqual(0, myDistributionSend.Vehicles.Count);
            Assert.AreEqual(1, myDistributionRecieve.Vehicles.Count);
            Assert.AreEqual(mycar, myDistributionRecieve.Vehicles[0]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TransferWithNoVehicle()
        {
            Semi mycar = new Semi("1999", "asdfgsdsafadsfasdas12345", "Nissan", "Altima");
            Distribution myDistributionSend = new Distribution();
            Distribution myDistributionRecieve = new Distribution();
            myDistributionSend.Transfer(myDistributionRecieve, mycar);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TransferSemiToBranch()
        {
            Semi mycar = new Semi("1999", "asdfgsdsafadsfasdas12345", "Nissan", "Altima");
            Distribution myDistributionSend = new Distribution();
            Branch myBranchRecieve = new Branch();
            myDistributionSend.Transfer(myBranchRecieve, mycar);
        }
    }
}
