using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBuy_v2._0.Models
{
    public class Car
    {
        public int Owner { get; set; }
        public int Milage { get; set; }
        public int HorsePower { get; set; }
        public int Doors { get; set; }
        public String FuelType { get; set; }
        public String Transmision { get; set; }
        public String CarType { get; set; }
        public String Registration { get; set; }
        public int Id { get; set; }
        public String Model { get; set; }
        public String CarBrand { get; set; }
        public int MakeYear { get; set; }

        public Car(int owner, int milage, int horsePower, int doors, string fuelType, string transmision, int carType, string registration, int id, string model, string carBrand, int makeYear)
        {
            Owner = owner;
            Milage = milage;
            HorsePower = horsePower;
            Doors = doors;
            FuelType = fuelType;
            Transmision = transmision;
            if (carType == 1)
                CarType = "Sedan";
            else if (carType == 2)
                CarType = "Wagon";
            else if (carType == 3)
                CarType = "Hatchback";
            else
                CarType = "Cabriolet";
            Registration = registration;
            Id = id;
            Model = model;
            CarBrand = carBrand;
            MakeYear = makeYear;
        }
    }
}
