using System.Collections.Generic;
using System.Linq;

namespace SortCitiesList
{
    public static class IEnumerableExtension
    {
        /// <summary>
        /// сортирует список пар городов так, что первый город в следующей паре равен второму городу в текущей
        /// считается что получится один список карточек без циклов и пропусков.
        /// </summary>
        /// <param name="origin"></param>
        /// <returns></returns>
        public static ICollection<CityPair> OrderByCityPairs(this IEnumerable<CityPair> origin)
        {
            var tmp = origin.ToDictionary(c => c.First);
            var rez = new List<CityPair>(tmp.Count);

            if (tmp.Count == 0)
                return rez;

            var first = tmp.First().Value;
            CityPair pop;
            for (pop = first; pop.Second != first.First; pop = tmp[pop.Second])
                rez.Add(pop);

            rez.Add(pop);

            return rez;
        }
    }
}