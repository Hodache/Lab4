using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Drink {
        public int volume; // Объем
        static protected int[] possibleVolumes = new int[] { 250, 500, 750, 1000, 1500, 2000 }; // Возможные объемы
        static protected Random rnd = new Random(); // Переменная рандома для случайного заполнения полей объектов

        public virtual string GetInfo()
        {
            string info = String.Format("Объем: {0} мл.\n", this.volume);
            return info;
        }

        public virtual string GetDrinkType()
        {
            return "Напиток";
        }
    }

    // Варианты видов сока
    public enum JuiceType { apple, orange, cherry };

    public class Juice : Drink
    {
        public JuiceType type;
        public bool withPulp;

        // Геттер информации о соке
        public override string GetInfo()
        {
            string info = "Сок\n";
            info += base.GetInfo();

            string ingridient = "";
            switch (this.type) {
                case JuiceType.apple:
                    ingridient = "Яблоко";
                    break;
                case JuiceType.orange:
                    ingridient = "Апельсин";
                    break;
                case JuiceType.cherry:
                    ingridient = "Вишня";
                    break;
            }

            info += String.Format("Вкус: {0}\nМякоть: {1}", ingridient, this.withPulp == true ? "Есть" : "Нет");
            return info;
        }

        public override string GetDrinkType()
        {
            return "Сок";
        }

        // Создание экземпляра класса со случайными значениями полей
        public static Juice Generate()
        {
            return new Juice
            {
                volume = Drink.possibleVolumes[rnd.Next(6)],
                type = (JuiceType)rnd.Next(3),
                withPulp = rnd.Next(2) == 0
            };
        }
    }

    // Варианты видов газировки
    public enum SodaType { coke, fanta, sprite };

    public class Soda : Drink
    {
        public SodaType type;
        public int bubblesNumber;

        // Геттер информации о газировке
        public override string GetInfo()
        {
            string info = "Газировка\n";
            info += base.GetInfo();

            string type = "";
            switch (this.type)
            {
                case SodaType.coke:
                    type = "Кока-кола";
                    break;
                case SodaType.fanta:
                    type = "Фанта";
                    break;
                case SodaType.sprite:
                    type = "Спрайт";
                    break;
            }

            info += String.Format("Вид: {0}\nКоличество пузырьков: {1}", type, this.bubblesNumber);
            return info;
        }

        public override string GetDrinkType()
        {
            return "Газировка";
        }

        // Создание экземпляра класса со случайными значениями полей
        public static Soda Generate()
        {
            return new Soda
            {
                volume = Drink.possibleVolumes[rnd.Next(6)],
                type = (SodaType)rnd.Next(3),
                bubblesNumber = rnd.Next(501)
            };
        }
    }

    // Варианты видов алкоголя
    public enum AlcoholType {beer, wine, cognac};

    public class Alcohol : Drink
    {
        public int strength;
        public AlcoholType type;

        // Геттер информации об алкоголе
        public override string GetInfo()
        {
            string info = "Алкоголь\n";
            info += base.GetInfo();

            string type = "";
            switch (this.type)
            {
                case AlcoholType.beer:
                    type = "Пиво";
                    break;
                case AlcoholType.wine:
                    type = "Вино";
                    break;
                case AlcoholType.cognac:
                    type = "Коньяк";
                    break;
            }

            info += String.Format("Крепость: {0}%\nТип: {1}", this.strength, type);
            return info;
        }

        public override string GetDrinkType()
        {
            return "Алкоголь";
        }
        
        // Создание экземпляра класса со случайными значениями полей
        public static Alcohol Generate()
        {
            return new Alcohol
            {
                volume = Drink.possibleVolumes[rnd.Next(6)],
                type = (AlcoholType)rnd.Next(3),
                strength = rnd.Next(101)
            };
        }
    }
}