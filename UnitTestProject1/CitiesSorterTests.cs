using System;
using System.Collections.Generic;
using NUnit.DeepObjectCompare;
using NUnit.Framework;
using SortCitiesList;
using Is = NUnit.DeepObjectCompare.Is;

namespace UnitTestProject1
{
    [TestFixture]
    public class CitiesSorterTests
    {
        [Test]
        public void NullInput_NullReferenceExc()
        {
            List<CityPair> origin = null;

            Assert.That(()=> { origin.OrderByCityPairs(); }, Throws.ArgumentNullException);
        }

        [Test]
        public void EmptyInput_Empty()
        {
            var origin = new List<CityPair>();

            Assert.That(origin.OrderByCityPairs(), Is.Empty);
        }

        [Test]
        public void HomeHome_1Elem()
        {
            var origin = new List<CityPair>() {new CityPair() {First = "home", Second = "home"}};
            var rez = new List<CityPair>() { new CityPair() { First = "home", Second = "home" } };

            Assert.That(origin.OrderByCityPairs(), Is.DeepEqualTo(rez));
        }

        [Test]
        public void HomeSecondFirst_HomeFirstSecond()
        {
            var origin = new List<CityPair>()
            {
                new CityPair() {First = "home", Second = "first"},
                new CityPair() {First = "second", Second = "home"},
                new CityPair() {First = "first", Second = "second"},
            };
            var rez = new List<CityPair>()
            {
                new CityPair() {First = "home", Second = "first"},
                new CityPair() {First = "first", Second = "second"},
                new CityPair() {First = "second", Second = "home"},
            };

            Assert.That(origin.OrderByCityPairs(), Is.DeepEqualTo(rez));
        }
    }
}
