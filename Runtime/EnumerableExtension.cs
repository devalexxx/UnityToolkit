using System.Collections.Generic;

namespace UnityToolkit
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<(T item, int index)> Enumerate<T>(this IEnumerable<T> source)
        {
            int i = 0;
            foreach (var item in source)
            {
                yield return (item, i);
                i++;
            }
        }
    }
}