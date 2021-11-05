using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Drink { }

    public enum JuiceType { apple, orange, cherry };

    public class Juice : Drink
    {
        public JuiceType type = JuiceType.apple;
        public bool withPulp = false;
    }

    public enum SodaType { coke, fanta, sprite };

    public class Soda : Drink
    {
        public SodaType type = SodaType.coke;
        public int bubblesNumber = 0;
    }

    public enum AlcoholType {beer, wine, cognac};

    public class Alcohol : Drink
    {
        public int strength = 0;
        public AlcoholType type = AlcoholType.beer;
    }
}