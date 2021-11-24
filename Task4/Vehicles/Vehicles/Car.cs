using System;
using Task4.Vehicles.Parts;

namespace Task4.Vehicles.Vehicles
{
    public class Car : Vehicle
    {
        private int seatsNumber;
        public override Engine Engine { get; set; }
        public override Chassis Chassis { get; set; }
        public override Transmission Transmission { get; set; }
        public int SeatsNumber
        {
            get => seatsNumber;
            set
            {
                if (value <= 0 || value > 9)
                    throw new ArgumentException("Seats number must be greater then 0 and lower then 10");
                seatsNumber = value;
            }
        }

        public override string GetInfo()
        {
            return "Car:\n" + Engine.GetInfo() + Chassis.GetInfo() + Transmission.GetInfo();
        }
    }
}
