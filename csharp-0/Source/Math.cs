using System;
using System.Collections.Generic;

namespace Codenation.Challenge {
    public class Math
    {
        public List<int> Fibonacci()
        {
            List<int> fibonacci = new List<int> { 0, 1 };

            int posPri = 0, posSeg = 1;

            while (fibonacci[posSeg] <= 350)
            {
                int primeiro = fibonacci[posPri], segundo = fibonacci[posSeg];

                fibonacci.Add(primeiro + segundo);

                posPri++;
                posSeg++;
            }
            fibonacci.RemoveAt(posSeg);

            return fibonacci;
        }

        public bool IsFibonacci(int numberToTest) {
            List<int> fibonacci = Fibonacci();

            int res = fibonacci.Find(x => x == numberToTest);

            return (numberToTest==0 || res>0) ? true : false;
        }
    }
}
