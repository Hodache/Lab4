using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab4;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4.Tests
{
    [TestClass()]
    public class DrinksTests
    {

        // Создание случайного сока
        [TestMethod()]
        public void GenerateJuiceTest()
        {
            Juice j = Juice.Generate();
            Boolean result = false;

            if ((j.type == JuiceType.apple || j.type == JuiceType.orange || j.type == JuiceType.cherry) &&
                (j.volume == 250 || j.volume == 500 || j.volume == 750 || j.volume == 1000 || j.volume == 1500 || j.volume == 2000))
            {
                result = true;
            }
            
            Assert.AreEqual(result, true);
        }

        // Создание случайной газировки
        [TestMethod()]
        public void GenerateSodaTest()
        {
            Soda s = Soda.Generate();
            Boolean result = false;

            if ((s.type == SodaType.coke || s.type == SodaType.fanta || s.type == SodaType.sprite) &&
                (s.volume == 250 || s.volume == 500 || s.volume == 750 || s.volume == 1000 || s.volume == 1500 || s.volume == 2000) &&
                (s.bubblesNumber >=0 && s.bubblesNumber <= 500))
            {
                result = true;
            }

            Assert.AreEqual(result, true);
        }

        // Создание случайного алкоголя
        [TestMethod()]
        public void GenerateAlcoholTest()
        {
            Alcohol a = Alcohol.Generate();
            Boolean result = false;

            if ((a.type == AlcoholType.beer || a.type == AlcoholType.cognac || a.type == AlcoholType.wine) &&
                (a.volume == 250 || a.volume == 500 || a.volume == 750 || a.volume == 1000 || a.volume == 1500 || a.volume == 2000) &&
                (a.strength >= 0 && a.strength <= 100))
            {
                result = true;
            }

            Assert.AreEqual(result, true);
        }
    }
}