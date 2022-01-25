using System;

namespace VehicleFleet.Vehicles.Vehicles
{
    /// <summary>
    /// VIN Generator - Vehicle Identification Number Generator
    /// </summary>
    public class VINGenerator
    {
        public string GenerateVIN()
        {
            string VIN = string.Empty;
            int vinSize = 17;
            Random random = new Random();

            for (int vinLength = 0; vinLength < vinSize; vinLength++)
            {
                //decide what will be added a letter or a digit
                int digitsOrLetters = random.Next(2);

                switch (digitsOrLetters)
                {
                    //add number
                    case 0:
                        int randomNumber = random.Next(10);
                        VIN += randomNumber.ToString();

                        break;
                    //add letter
                    case 1:
                        int randomLetter = random.Next(65, 90);

                        //
                        if (randomLetter == 73 || randomLetter == 79 || randomLetter == 81)
                        {
                            randomLetter -= random.Next(5);
                        }
                        VIN += (char)randomLetter;

                        break;
                }
            }

            return VIN;
        }
    }


}
