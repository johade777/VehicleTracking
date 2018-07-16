using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VehicleTracking;

namespace TrackingUnitTests
{
    [TestClass]
    public class BranchUnitTests
    {
        [TestMethod]
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
    }
}
