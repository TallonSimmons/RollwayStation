using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollwayStation.Extensions
{
    public static class ListExtensions
    {
        public static bool TryGetElementAtIndex<T>(this List<T> list, int index, out T element)
            where T : class
        {
            if (list == null)
            {
                throw new NullReferenceException();
            }

            element = null;

            var listAsDictionary = list.ToDictionary(x => list.IndexOf(x));

            return listAsDictionary.TryGetValue(index, out element);

        }
    }
}
