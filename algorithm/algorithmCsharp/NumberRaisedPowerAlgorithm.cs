using System;

namespace algorithmCSharp
{
    public static class NumberRaisedPowerAlgorithm
    {
        //Cálcula um número elevado a uma potência
        public static void NumberRaisedPower(int numBase, int exp)
        {
            //int numBase = 2;
            //int exp = 4;
            int result = 1;

            while (exp > 0)
            {
                result = result * numBase;
                exp--;
            }
            Console.WriteLine($"Result is {result}");
        }
    }
}