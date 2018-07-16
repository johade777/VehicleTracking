using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VehicleTracking;

namespace TrackingUnitTests
{
    [TestClass]
    public class VehicleUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void VINLengthLessThan()
        {
            Van mycar = new Van("1999", "asdfgsdsafadsfasda12345", "Nissan", "Altima");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void VINLengthGreaterThan()
        {
            Van mycar = new Van("1999", "asdfgsdsafadsffsadfasasda12345", "Nissan", "Altima");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void VINLessThanAlpha()
        {
            Van mycar = new Van("1999", "2323232323554545das12345", "Nissan", "Altima");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void VINLastNumbers()
        {
            Van mycar = new Van("1999", "2323232323554545das123g5", "Nissan", "Altima");
        }

        [TestMethod]
        public void CorrectYearFormat()
        {
            Van mycar = new Van("1999", "asdfgsdsafadsfasdas12345", "Nissan", "Altima");
        }

        [TestMethod]
        public void IncorrectYearFormatAllZero()
        {
            Van mycar = new Van("0000", "asdfgsdsafadsfasdas12345", "Nissan", "Altima");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IncorrectYearFormat()
        {
            Van mycar = new Van("0", "asdfgsdsafadsfasdas12345", "Nissan", "Altima");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IncorrectYearFormatLetters()
        {
            Van mycar = new Van("abcd", "asdfgsdsafadsfasdas12345", "Nissan", "Altima");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IncorrectYearFormatNull()
        {
            Van mycar = new Van("", "asdfgsdsafadsfasdas12345", "Nissan", "Altima");
        }
    }
}
