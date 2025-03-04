using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace KursUML
{
   
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void Button_Clear(object sender, RoutedEventArgs e)
        {
            InputTextBox.Text = string.Empty;
        }
        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // Проверяем, является ли нажатая клавиша цифрой
            if ((e.Key >= Key.D0 && e.Key <= Key.D9) ||
                (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9))
            {
                e.Handled = true; // Отменяем событие, если это цифра или специальный символ
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            deKoding a = new deKoding();    
            a.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            history history = new history();
            history.Show();
            this.Close();
        }






        private void EncodeButton_Click(object sender, RoutedEventArgs e)
        {
            string input = InputTextBox.Text;
            var encoded = FanoEncode(input);
            OutputTextBlock.Text = encoded;
        }

        private string FanoEncode(string input)
        {
            // Подсчет частоты символов
            var frequency = input.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
            var sortedFrequency = frequency.OrderByDescending(f => f.Value).ToList();

            // Генерация кодов Фано
            var codes = new Dictionary<char, string>();
            GenerateFanoCodes(sortedFrequency, "", codes);

            // Кодирование строки с сохранением пробелов
            string encodedString = "";
            foreach (char c in input)
            {
                if (c == ' ') // Если символ - пробел, добавляем пробел в закодированную строку
                {
                    encodedString += " "; // Можно использовать специальный символ или код для пробела
                }
                else
                {
                    encodedString += codes[c]; // Закодированный символ
                }
            }

            return encodedString;
        }

        private void GenerateFanoCodes(List<KeyValuePair<char, int>> frequencies, string code, Dictionary<char, string> codes)
        {
            if (frequencies.Count == 0) return;

            // Если остался только один символ, присваиваем ему код
            if (frequencies.Count == 1)
            {
                codes[frequencies[0].Key] = code;
                return;
            }

            // Сумма всех частот
            int total = frequencies.Sum(f => f.Value);
            int cumulative = 0;
            int index = 0;

            // Находим индекс, где сумма частот становится больше или равна половине
            while (index < frequencies.Count && cumulative + frequencies[index].Value < total / 2)
            {
                cumulative += frequencies[index].Value;
                index++;
            }

            // Если индекс равен количеству элементов, значит все элементы относятся к первой группе
            if (index == frequencies.Count) index--;

            // Разделяем на две группы и рекурсивно вызываем для каждой группы
            GenerateFanoCodes(frequencies.Take(index + 1).ToList(), code + "0", codes);
            GenerateFanoCodes(frequencies.Skip(index + 1).ToList(), code + "1", codes);
        }



        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string input = InputTextBox.Text;
            var encoded = FanoEncode(input);
            OutputTextBlock.Text = encoded;
        }
    }
}
