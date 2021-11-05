using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Drink> drinksList = new List<Drink>();

        // Параграфы для работы с RichTextBox
        Paragraph infoParagraph = new Paragraph();
        Paragraph outParagraph = new Paragraph();
        Paragraph queueParagraph = new Paragraph();

        public MainWindow()
        {
            InitializeComponent();

            txtOut.Document.Blocks.Clear();
            txtQueue.Document.Blocks.Clear();
            ShowInfo();
        }

        private void btnRefill_Click(object sender, RoutedEventArgs e)
        {
            drinksList.Clear();

            var rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                switch (rnd.Next() % 3) // генерирую случайное число от 0 до 2
                {
                    case 0: // если 0, то сок
                        drinksList.Add(Juice.Generate());
                        break;
                    case 1: // если 1 то газировка
                        drinksList.Add(Soda.Generate());
                        break;
                    case 2: // если 2 то алкоголь
                        drinksList.Add(Alcohol.Generate());
                        break;
                }
            }
            ShowInfo();
            ShowQueue();
        }

        private void ShowInfo()
        {
            int juiceCount = 0;
            int sodaCount = 0;
            int alcoholCount = 0;

            foreach (var drink in this.drinksList)
            {
                if (drink is Juice)
                {
                    juiceCount++;
                }
                else if (drink is Soda)
                {
                    sodaCount++;
                }
                else if (drink is Alcohol)
                {
                    alcoholCount++;
                }
            }

            string counts = String.Format("{0}\t{1}\t\t{2}", juiceCount, sodaCount, alcoholCount);

            // Очищаем текст
            txtInfo.Document.Blocks.Clear();
            infoParagraph.Inlines.Clear();

            // Заполняем параграф новой информацией
            infoParagraph.Inlines.Add(new Bold(new Run("Сок\tГазировка\tАлкоголь\n")));
            infoParagraph.Inlines.Add(new Run(counts));
            // Выводим параграфы в поле
            txtInfo.Document.Blocks.Add(infoParagraph);
        }

        private void btnGet_Click(object sender, RoutedEventArgs e)
        {
            outParagraph.Inlines.Clear();

            if (drinksList.Count == 0) // Если список пуст
            {
                outParagraph.Inlines.Add(new Run("Автомат пуст"));
                txtOut.Document.Blocks.Add(outParagraph);
            }
            else
            {
                // Берем первый элемент и удаляем его
                Drink drink = drinksList[0];
                drinksList.RemoveAt(0);

                // Выводим информацию в поле
                outParagraph.Inlines.Add(new Run(drink.GetInfo()));
                txtOut.Document.Blocks.Add(outParagraph);
                
                ShowInfo();
                ShowQueue();
            }
        }

        public void ShowQueue()
        {
            queueParagraph.Inlines.Clear();

            if (drinksList.Count == 0) // Если список пуст
            {
                queueParagraph.Inlines.Add(new Run("Очередь пуста"));
            }
            else
            {
                foreach (var drink in drinksList)
                {
                    BitmapImage bitmap = new BitmapImage(new Uri(@"C:\Users\hodac\source\repos\Lab4\Lab4\" + drink.GetDrinkType() + ".jpg"));
                    Image image = new Image();
                    image.Source = bitmap;
                    image.Height = 20;

                    queueParagraph.Inlines.Add(image);
                    queueParagraph.Inlines.Add(new Run(drink.GetDrinkType() + "\n"));
                }
            }
            txtQueue.Document.Blocks.Add(queueParagraph);
        }
    }
}
