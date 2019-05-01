using System;

namespace algorithmCSharp
{
    public static class CylinderVolumeAlgorithm
    {
        //Cálcula um volume de um cilindro
        public static void CalculateCylinderVolume()
        {
            var radius = 6.0;
            var height = 20;

            var volume = Math.PI * Math.Pow(radius, 2) * height;

            //Console.WriteLine($"Volume of cylinder is {volume}");
            Console.WriteLine($"Volume of cylinder is {volume:0.##}");
        }
    }
}