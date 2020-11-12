using System;
using System.Runtime.Serialization.Formatters;

namespace Gcd
{
    /// <summary>
    /// Provide methods with integers.
    /// </summary>
    public static class IntegerExtensions
    {
        /// <summary>
        /// Calculates GCD of two integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(int a, int b)
        {
            if (a == 0 && b == 0)
            {
                throw new ArgumentException("All numbers cannot be 0 at the same time.");
            }

            if (a == int.MinValue || b == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"Number cannot be {int.MinValue}.");
            }

            a = Math.Abs(a);
            b = Math.Abs(b);
            while (a != 0 && b != 0)
            {
                if (a > b)
                {
                    a %= b;
                }
                else
                {
                    b %= a;
                }
            }

            return a + b;
        }

        /// <summary>
        /// Calculates GCD of three integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="c">Third integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(int a, int b, int c)
        {
            if (a == 0 && b == 0 && c == 0)
            {
                throw new ArgumentException("All numbers cannot be 0 at the same time.");
            }

            if (a == int.MinValue || b == int.MinValue || c == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"Number cannot be {int.MinValue}.");
            }

            a = Math.Abs(a);
            b = Math.Abs(b);
            c = Math.Abs(c);
            while (a != 0 && b != 0)
            {
                if (a > b)
                {
                    a %= b;
                }
                else
                {
                    b %= a;
                }
            }

            var result = a + b;
            while (result != 0 && c != 0)
            {
                if (c > result)
                {
                    c %= result;
                }
                else
                {
                    result %= c;
                }
            }

            return result + c;
        }

        /// <summary>
        /// Calculates the GCD of integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="other">Other integers.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(int a, int b, params int[] other)
        {
            var cnt = 0;
            foreach (int i in other)
            {
                if (i == 0)
                {
                    cnt++;
                }
            }

            if (cnt == other.Length && a == 0 && b == 0)
            {
                throw new ArgumentException("All numbers cannot be 0 at the same time.");
            }

            foreach (int i in other)
            {
                if (i == int.MinValue)
                {
                    throw new ArgumentOutOfRangeException($"Number cannot be {int.MinValue}.");
                }
            }

            if (a == int.MinValue || b == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"Number cannot be {int.MinValue}.");
            }

            a = Math.Abs(a);
            b = Math.Abs(b);
            while (a != 0 && b != 0)
            {
                if (a > b)
                {
                    a %= b;
                }
                else
                {
                    b %= a;
                }
            }

            var result = a + b;

            for (int i = 0; i < other.Length; i++)
            {
                other[i] = Math.Abs(other[i]);
                while (result != 0 && other[i] != 0)
                {
                    if (result > other[i])
                    {
                        result %= other[i];
                    }
                    else
                    {
                        other[i] %= result;
                    }
                }

                result += other[i];
            }

            return result;
        }

        /// <summary>
        /// Calculates GCD of two integers [-int.MaxValue;int.MaxValue] by the Stein algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        public static int GetGcdByStein(int a, int b)
        {
            if (a == 0 && b == 0)
            {
                throw new ArgumentException("All numbers cannot be 0 at the same time.");
            }

            if (a == int.MinValue || b == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"Number cannot be {int.MinValue}.");
            }

            a = Math.Abs(a);
            b = Math.Abs(b);
            if (a == b || a == 0)
            {
                return b;
            }

            if (b == 0)
            {
                return a;
            }

            bool aIsEven = (a & 1) == 0;
            bool bIsEven = (b & 1) == 0;

            if (aIsEven && !bIsEven)
            {
                return GetGcdByStein(a >> 1, b);
            }
            else if (aIsEven && bIsEven)
            {
                return GetGcdByStein(a >> 1, b >> 1) << 1;
            }
            else if (bIsEven)
            {
                return GetGcdByStein(a, b >> 1);
            }
            else if (a > b)
            {
                return GetGcdByStein((a - b) >> 1, b);
            }
            else
            {
                return GetGcdByStein(a, (b - a) >> 1);
            }
        }

        /// <summary>
        /// Calculates GCD of three integers [-int.MaxValue;int.MaxValue] by the Stein algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="c">Third integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByStein(int a, int b, int c)
        {
            if (a == 0 && b == 0 && c == 0)
            {
                throw new ArgumentException("All numbers cannot be 0 at the same time.");
            }

            if (a == int.MinValue || b == int.MinValue || c == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"Number cannot be {int.MinValue}.");
            }

            a = Math.Abs(a);
            b = Math.Abs(b);
            c = Math.Abs(c);
            int intermediateResult;
            if (a == b || a == 0)
            {
                intermediateResult = b;
            }

            if (b == 0)
            {
                intermediateResult = a;
            }

            bool aIsEven = (a & 1) == 0;
            bool bIsEven = (b & 1) == 0;

            if (aIsEven && !bIsEven)
            {
                intermediateResult = GetGcdByStein(a >> 1, b);
            }
            else if (aIsEven && bIsEven)
            {
                intermediateResult = GetGcdByStein(a >> 1, b >> 1) << 1;
            }
            else if (bIsEven)
            {
                intermediateResult = GetGcdByStein(a, b >> 1);
            }
            else if (a > b)
            {
                intermediateResult = GetGcdByStein((a - b) >> 1, b);
            }
            else
            {
                intermediateResult = GetGcdByStein(a, (b - a) >> 1);
            }

            if (intermediateResult == c || intermediateResult == 0)
            {
                return c;
            }

            if (c == 0)
            {
                return intermediateResult;
            }

            bool iIsEven = (intermediateResult & 1) == 0;
            bool cIsEven = (c & 1) == 0;

            if (iIsEven && !cIsEven)
            {
                return GetGcdByStein(intermediateResult >> 1, c);
            }
            else if (iIsEven && cIsEven)
            {
                return GetGcdByStein(intermediateResult >> 1, c >> 1) << 1;
            }
            else if (cIsEven)
            {
                return GetGcdByStein(intermediateResult, c >> 1);
            }
            else if (intermediateResult > c)
            {
                return GetGcdByStein((intermediateResult - c) >> 1, c);
            }
            else
            {
                return GetGcdByStein(intermediateResult, (c - a) >> 1);
            }
        }

        /// <summary>
        /// Calculates the GCD of integers [-int.MaxValue;int.MaxValue] by the Stein algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="other">Other integers.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByStein(int a, int b, params int[] other)
        {
            throw new NotImplementedException("You need to implement this function.");
        }

        /// <summary>
        /// Calculates GCD of two integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(out long elapsedTicks, int a, int b)
        {
            throw new NotImplementedException("You need to implement this function.");
        }

        /// <summary>
        /// Calculates GCD of three integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="c">Third integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(out long elapsedTicks, int a, int b, int c)
        {
            throw new NotImplementedException("You need to implement this function.");
        }

        /// <summary>
        /// Calculates the GCD of integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in Ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="other">Other integers.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(out long elapsedTicks, int a, int b, params int[] other)
        {
            throw new NotImplementedException("You need to implement this function.");
        }

        /// <summary>
        /// Calculates GCD of two integers from [-int.MaxValue;int.MaxValue] by the Stein algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        public static int GetGcdByStein(out long elapsedTicks, int a, int b)
        {
            throw new NotImplementedException("You need to implement this function.");
        }

        /// <summary>
        /// Calculates GCD of three integers from [-int.MaxValue;int.MaxValue] by the Stein algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="c">Third integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByStein(out long elapsedTicks, int a, int b, int c)
        {
            throw new NotImplementedException("You need to implement this function.");
        }

        /// <summary>
        /// Calculates the GCD of integers from [-int.MaxValue;int.MaxValue] by the Stein algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in Ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="other">Other integers.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByStein(out long elapsedTicks, int a, int b, params int[] other)
        {
            throw new NotImplementedException("You need to implement this function.");
        }
    }
}
