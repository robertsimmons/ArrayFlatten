using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ArrayFlatten
{
    public static class TheFlattener
    {
        /// <summary>
        /// Flattens a string representation of arbitrarily nested integer arrays into a single array of integers.
        /// </summary>
        /// <param name="input">Example: "[[1,2,[3]],4]"</param>
        /// <returns>Example: new[] { 1, 2, 3, 4 }</returns>
        public static int[] Flattenize(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return new int[0];
            }

            // Let's cheat! No need to try to force that into an object.

            var justNumbersAndCommas = input.Replace(" ", string.Empty).Replace("[", string.Empty).Replace("]", string.Empty);

            if (string.IsNullOrWhiteSpace(justNumbersAndCommas))
            {
                return new int[0];
            }

            var numbers = justNumbersAndCommas.Split(',');
            
            return numbers.Select(x => int.Parse(x)).ToArray();
        }

        /// <summary>
        /// Flattens a string representation of arbitrarily nested integer arrays into a single array of integers using Regex.
        /// </summary>
        /// <param name="input">Example: "[[1,2,[3]],4]"</param>
        /// <returns>Example: new[] { 1, 2, 3, 4 }</returns>
        public static int[] FlattenizeWithRegex(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return new int[0];
            }

            var match = Regex.Match(input, @"[\d]+");

            var integers = new List<int>();

            while (match.Success)
            {
                integers.Add(int.Parse(match.Value));

                match = match.NextMatch();
            }

            return integers.ToArray();
        }

        /// <summary>
        /// Flattens an arbitrarily nested set of integer arrays into a single array of integers.
        /// </summary>
        /// <param name="input">Example: new object[] { new object[] { 1, 2, new [] { 3 } }, 4}</param>
        /// <returns>Example: new[] { 1, 2, 3, 4 }</returns>
        public static int[] FlattenizeObject(IEnumerable input)
        {
            if (input is null)
            {
                return new int[0];
            }

            var integers = new List<int>();
            var enumerator = input.GetEnumerator();

            while (enumerator.MoveNext())
            {
                var value = enumerator.Current;

                if (value is int)
                {
                    integers.Add((int)value);
                    continue;
                }

                if (value is IEnumerable)
                {
                    integers.AddRange(FlattenizeObject((IEnumerable)value));
                }
            }

            return integers.ToArray();
        }
    }
}
