using System;
using System.Threading.Tasks;

namespace Laboratory1
{
    public static class Prime
    {
        public static bool IsPrime(int num)
        {
            for (var i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                    return false;
            }

            return true;
        }
        
        public static async Task<int> MethodOne(int num)
        {
            for (var i = num; i >= 2; i--)
            {
                if (IsPrime(i))
                {
                    return i;
                }
            }

            return -1;
        }

        public static async Task<int> MethodTwo(int num)
        {
            var foundPrime = -1;
            for (var i = 2; i < num; i++)
            {
                if (IsPrime(i))
                {
                    foundPrime = i;
                }
            }

            return foundPrime;
        }
    }
}
