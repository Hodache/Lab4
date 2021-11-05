using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Drink {
        public int volume;
        static protected int[] possibleVolumes = new int[] { 250, 500, 750, 1000, 1500, 2000 }; // Возможные объемы

        public virtual string GetInfo()
        {
            string info = String.Format("Объем: {0}\n", this.volume);
            return info;
        }
    }

    public enum JuiceType { apple, orange, cherry };

    public class Juice : Drink
    {
        public JuiceType type = JuiceType.apple;
        public bool withPulp = false;

        public override string GetInfo()
        {
            string info = "Сок\n";
            info += base.GetInfo();
            info += String.Format("Вкус: {0}\nМякоть: {1}", this.type, this.withPulp);
            return info;
        }

        public static Juice Generate()
        {
            var rnd = new Random();
            return new Juice
            {
                volume = Drink.possibleVolumes[rnd.Next(6)],
                type = (JuiceType)rnd.Next(3),
                withPulp = rnd.Next(2) == 0
            };
        }
    }

    public enum SodaType { coke, fanta, sprite };

    public class Soda : Drink
    {
        public SodaType type = SodaType.coke;
        public int bubblesNumber = 0;

        public override string GetInfo()
        {
            string info = "Газировка\n";
            info += base.GetInfo();
            info += String.Format("Вид: {0}\nКоличество пузырьков: {1}", this.type, this.bubblesNumber);
            return info;
        }

        public static Soda Generate()
        {
            var rnd = new Random();
            return new Soda
            {
                volume = Drink.possibleVolumes[rnd.Next(6)],
                type = (SodaType)rnd.Next(3),
                bubblesNumber = rnd.Next(501)
            };
        }
    }

    public enum AlcoholType {beer, wine, cognac};

    public class Alcohol : Drink
    {
        public float strength = 0;
        public AlcoholType type = AlcoholType.beer;

        public override string GetInfo()
        {
            string info = "Алкоголь\n";
            info += base.GetInfo();
            info += String.Format("Крепость: {0}\nТип: {1}", this.strength, this.type);
            return info;
        }

        public static Alcohol Generate()
        {
            var rnd = new Random();
            return new Alcohol
            {
                volume = Drink.possibleVolumes[rnd.Next(6)],
                type = (AlcoholType)rnd.Next(3),
                strength = rnd.Next(101)
            };
        }
    }
}