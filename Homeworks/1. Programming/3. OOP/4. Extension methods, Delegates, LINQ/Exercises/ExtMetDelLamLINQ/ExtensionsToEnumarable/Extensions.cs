using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtensionsToEnumarable
{
    public static class Extensions
    {
        //sum of elements
        public static T Sum<T>(this IEnumerable<T> elements)
        {
            if (elements.FirstOrDefault() == null)
            {
                throw new ArgumentException("No arguments!");
            }

            T sum = (dynamic)0;

            foreach (var item in elements)
            {
                sum += (dynamic)item;
            }

            return sum;
        }

        //product of elements
        public static T Product<T>(this IEnumerable<T> elements)
        {
            if (elements.FirstOrDefault() == null)
            {
                throw new ArgumentException("No arguments!");
            }

            T product = (dynamic)1;

            foreach (var item in elements)
            {
                product *= (dynamic)item;
            }

            return product;
        }

        //minimum of elements
        public static T Min<T>(this IEnumerable<T> elements) where T: IComparable<T>
        {
            if (elements.FirstOrDefault() == null)
            {
                throw new ArgumentException("No arguments!");
            }

            T minValue = elements.First();

            foreach (var item in elements)
            {
                if (item < (dynamic)minValue)
                {
                    minValue = item;
                }
            }

            return minValue;
        }

        //max elements
        public static T Max<T>(this IEnumerable<T> elements) where T : IComparable<T>
        {
            if (elements.FirstOrDefault() == null)
            {
                throw new ArgumentException("No arguments!");
            }

            T maxValue = elements.First();

            foreach (var item in elements)
            {
                if (item > (dynamic)maxValue)
                {
                    maxValue = item;
                }
            }

            return maxValue;
        }
        
        //average
        public static decimal Average<T>(this IEnumerable<T> elements) where T : IComparable<T>
        {
            if (elements.FirstOrDefault() == null)
            {
                throw new ArgumentException("No arguments!");
            }

            T averageValue = (dynamic)0;
            int counter = 0;

            foreach (var item in elements)
            {
                averageValue += (dynamic)item;
                counter++;
            }

            return (dynamic)averageValue / (decimal)counter;
        }
    }
}
