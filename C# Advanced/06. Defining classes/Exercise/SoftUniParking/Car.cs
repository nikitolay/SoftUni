using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    class Car
    {
        public Car()
        {

        }

        public Car(string make, string model, int horsePower, string registrationNumber)
        {
            Make = make;
            Model = model;
            HorsePower = horsePower;
            RegistrationNumber = registrationNumber;
        }

        public string Make { get; set; }
        public string Model { get; set; }

        public int HorsePower { get; set; }
        public string RegistrationNumber { get; set; }
        public override string ToString()
        {

            //Make: Skoda 

            //Model: Fabia 

            //HorsePower: 65 

            //RegistrationNumber: CC1856BG 
            return @$"Make: {Make}
Model: {Model} 
HorsePower: {HorsePower} 
RegistrationNumber: {RegistrationNumber} ";
        }
    }
}
