using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using MySql.Data.MySqlClient;

namespace kurs
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Button_Clear(object sender, RoutedEventArgs e)
        {
            tBox.Text = string.Empty;
        }

        private void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Regex.IsMatch(e.Text, "^[01]$"))
            {
                e.Handled = true; // Запрещаем ввод, если символ не является цифрой или точкой
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           // history history = new history();
           // history.Show();
            this.Close();
        }


        private void mysql()
        {
            try
            {
                var connstr = "Server=localhost;Uid=root;Pwd=1234;database=uml";
                MySqlConnection mySqlConnection = new MySqlConnection(connstr);
                mySqlConnection.Open();
                MessageBox.Show("ex.fgfgd()");
                mySqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            mysql();
        }
    }
}
