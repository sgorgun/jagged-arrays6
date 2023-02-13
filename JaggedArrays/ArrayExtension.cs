using System;
using System.Globalization;

namespace JaggedArrays
{
    public static class ArrayExtension
    {
        /// <summary>
        /// Orders the rows in a jagged-array by ascending of the sum of the elements in them.
        /// </summary>
        /// <param name="source">The jagged-array to sort.</param>
        /// <exception cref="ArgumentNullException">Thrown when source in null.</exception>
        public static void OrderByAscendingBySum(this int[][]? source)
        {
            _ = source ?? throw new ArgumentNullException(nameof(source));

            for (int i = 1; i < source.Length; i++)
            {
                for (int j = i - 1; j > -1 && GetRowSums(source[j]) > GetRowSums(source[j + 1]); j--)
                {
                    (source[j], source[j + 1]) = (source[j + 1], source[j]);
                }
            }
        }

        /// <summary>
        /// Orders the rows in a jagged-array by descending of the sum of the elements in them.
        /// </summary>
        /// <param name="source">The jagged-array to sort.</param>
        /// <exception cref="ArgumentNullException">Thrown when source in null.</exception>
        public static void OrderByDescendingBySum(this int[][]? source)
        {
            _ = source ?? throw new ArgumentNullException(nameof(source));

            for (int i = 1; i < source.Length; i++)
            {
                for (int j = i - 1; j > -1 && GetRowSums(source[j]) < GetRowSums(source[j + 1]); j--)
                {
                    (source[j], source[j + 1]) = (source[j + 1], source[j]);
                }
            }
        }

        /// <summary>
        /// Orders the rows in a jagged-array by ascending of the max of the elements in them.
        /// </summary>
        /// <param name="source">The jagged-array to sort.</param>
        /// <exception cref="ArgumentNullException">Thrown when source in null.</exception>
        public static void OrderByAscendingByMax(this int[][]? source)
        {
            _ = source ?? throw new ArgumentNullException(nameof(source));

            for (int i = 1; i < source.Length; i++)
            {
                for (int j = i - 1; j > -1 && GetMaxElement(source[j]) > GetMaxElement(source[j + 1]); j--)
                {
                    (source[j], source[j + 1]) = (source[j + 1], source[j]);
                }
            }
        }
        
        /// <summary>
        /// Orders the rows in a jagged-array by descending of the max of the elements in them.
        /// </summary>
        /// <param name="source">The jagged-array to sort.</param>
        /// <exception cref="ArgumentNullException">Thrown when source in null.</exception>
        public static void OrderByDescendingByMax(this int[][]? source)
        {
            _ = source ?? throw new ArgumentNullException(nameof(source));

            for (int i = 1; i < source.Length; i++)
            {
                for (int j = i - 1; j > -1 && GetMaxElement(source[j]) < GetMaxElement(source[j + 1]); j--)
                {
                    (source[j], source[j + 1]) = (source[j + 1], source[j]);
                }
            }
        }

        private static int GetRowSums(int[]? array)
        {
            int result = 0;
            if (array is null)
            {
                return result;
            }

            foreach (var t in array)
            {
                result += t;
            }

            return result;
        }

        private static int GetMaxElement(int[]? array)
        {
            int result = int.MinValue;
            if (array is null)
            {
                return result;
            }

            foreach (var max in array)
            {
                if (max > result)
                {
                    result = max;
                }
            }

            return result;
        }
    }
}
