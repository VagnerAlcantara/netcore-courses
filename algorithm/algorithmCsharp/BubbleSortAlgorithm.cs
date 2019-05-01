using System;

namespace algorithmCSharp
{
    public static class BubbleSorteAlgorithm
    {

        public static void BubbleSort()
        {
            //declarando um array de numeros não organizadoss
            int[] nums = { 5, 10, 3, 4 };
            //Mostra a lista de numeros desorganizados
            Console.WriteLine("Before: 5, 10, 3, 4");
            //Será urilizado para saber quando finalizar a rotina
            bool swapped;
            do
            {
                //Setar o swapped para falso para início da rotinas
                swapped = false;

                //Interagir com a lista de número desordenadoss
                for (int i = 0; i < nums.Length - 1; i++)
                {
                    // here we use the i for the position in the array
                    // So i is the first value to compare and i + 1 compares the adjacent value
                    // Once i is incremented at the end of this loop, we compare the next two sets of values, etc.
                    if (nums[i] > nums[i + 1])
                    {
                        // swap routine.  Could be a separate method as well but is used inline for simplicity here
                        // temp is used to hold the right value in the comparison so we don't lose it.  That value will be replaced in the next step
                        int temp = nums[i + 1];
                        // Here we replace the right value with the larger value that was on the left.   See why we needed the temp variable above?
                        nums[i + 1] = nums[i];
                        // Now we assign the value that is in temp, the smaller value, to the location that was just vacated by the larger number
                        nums[i] = temp;
                        // Indicate that we did a swap, which means we need to continue to check the remaining values.
                        swapped = true;

                    }
                }
            } while (swapped);

            Console.WriteLine("After: ");
            for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine("{0}, ", nums[i]);
            }
            // Use Console.ReadLine() in the event application was started with debugging.
            Console.ReadLine();

        }
    }
}