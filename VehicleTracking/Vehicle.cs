using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace VehicleTracking
{
    public class Vehicle
    {
        private string year;
        private string vin;
        protected string make;
        protected string model;
        protected VehicleStatus currentStatus;
       
        public VehicleStatus CurrentStatus
        {
            get { return this.currentStatus; }
            set { }
        }

        public string Year
        {
            get { return this.year; }
            set
            {
                this.year = value;
                ValidateYear(this.year);
            }
        }

        public string VIN
        {
            get { return this.vin; }
            set
            {
                this.vin = value;
                ValidateVIN(this.vin.ToCharArray());
            }
        }

        private void ValidateYear(string year)
        {
            string pattern = @"^\d\d\d\d$";
            Regex r = new Regex(pattern);

            string temp = year.ToString();
            if (!r.IsMatch(year.ToString()))
            {
                throw new ArgumentException("Invalid Year format", "year");
            }
        }

        //Regex is another solution
        private void ValidateVIN(char[] vin)
        {
            int alphaCount = 0;
            if (vin.Length != 24)
            {
                throw new ArgumentException("Invalid VIN format", "year");
            }

            foreach (char c in vin)
            {
                if (Char.IsLetter(c))
                {
                    alphaCount++;
                }
            }
            if (alphaCount < 8)
            {
                throw new ArgumentException("Invalid Year format", "year");
            }

            for (int i = 19; i < 24; i++)
            {
                if (!Char.IsNumber(vin[i]))
                {
                    throw new ArgumentException("Invalid Year format, requires 5 ending numbers");
                }
            }
        }

        //Example of regex that checks for 5 ending numbers
        public bool testRegex(String testString)
        {
            string pattern = "[0-9]{5}$";
            Regex r = new Regex(pattern, RegexOptions.IgnoreCase);
            return r.IsMatch(testString);
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            Vehicle r = (Vehicle)obj;
            return this.VIN.Equals(r.VIN);
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
