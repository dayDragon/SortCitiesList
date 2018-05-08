using System.Collections.Generic;
using System.Linq;

namespace SortCitiesList
{
    public static class IEnumerableExtension
    {
        /// <summary>
        /// ��������� ������ ��� ������� ���, ��� ������ ����� � ��������� ���� ����� ������� ������ � �������
        /// ��������� ��� ��������� ���� ������ �������� ��� ������ � ���������.
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