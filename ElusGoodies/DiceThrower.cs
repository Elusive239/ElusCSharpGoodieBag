using System;

namespace ElusGoodies
{
    public static class DiceThrower{
        static Random randomness = new Random();
        /// <summary>
        /// Rolls a specific die.
        /// </summary>
        /// <param name="die"></param>
        /// <returns>Returns what is "rolled".</returns>
        public static int Roll(int die){
            int rolled = randomness.Next(die) + 1;
            return rolled;
        }
        /// <summary>
        /// Rolls the specified amount of die.
        /// </summary>
        /// <param name="die"></param>
        /// <param name="amount"></param>
        /// <returns>Returns all of the individual rolls.</returns>
        public static int[] Roll(int die, int amount){
            int[] rolls = new int[amount];
            int index = 0;
            while (index < amount)
            {
                rolls[index] = Roll(die);
                index++;
            }
            return rolls;
        }
        /// <summary>
        /// Rolls a specified amount of die. Prints the individual results if print == true.
        /// </summary>
        /// <param name="die"></param>
        /// <param name="amount"></param>
        /// <param name="print"></param>
        /// <returns>Returns all of the rolls added together.</returns>
        public static int Roll(int die, int amount, bool print){
            int rolls = 0;
            int index = 0;
            while (index < amount)
            {
                int temp = Roll(die);
                rolls += temp;
                if(print)
                Console.WriteLine(index+": "+temp);
                index++;
            }
            return rolls;
        }

        public static int D2 => randomness.Next(2) + 1;
        public static int D3 => randomness.Next(3) + 1;
        public static int D4 => randomness.Next(4) + 1;
        public static int D6 => randomness.Next(6) + 1;
        public static int D8 => randomness.Next(8) + 1;
        public static int D10 => randomness.Next(10) + 1;
        public static int D12 => randomness.Next(12) + 1;
        public static int D20 => randomness.Next(20) + 1;
        public static int D100 => randomness.Next(100) + 1;
    }
}