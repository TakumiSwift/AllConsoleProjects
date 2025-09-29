using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using WPFTask1;

namespace WPFAppTask2
{
    /// <summary>
    /// Логика взаимодействия для ConsultantWindow.xaml
    /// </summary>
    public partial class ConsultantWindow : Window
    {

        private Database data = new Database("Consultant");
        
        public ConsultantWindow()
        {
            InitializeComponent();
        }

        private void FillList()
        {
            string[] lines = (cmbClientsList.SelectedItem as Consultant).
                              PrintClient(cmbClientsList.SelectedItem as Consultant).
                              Split(' ');
            ObservableCollection<Words> words = new ObservableCollection<Words>();
            for (int i = 0; i < lines.Length; i++)
            {
                Words w = new Words(lines[i]);
                words.Add(w);
            }
            lbxClientData.ItemsSource = words;
        }

        private void cmbClientsList_DropDownOpened(object sender, EventArgs e)
        {
            cmbClientsList.ItemsSource = data.TakeData();
            lbxClientData.ItemsSource = null;
        }

        private void cmbClientsList_DropDownClosed(object sender, EventArgs e)
        {
            FillList();
            btnChangePhone.Visibility = Visibility.Visible; // Итоговый вариант наполнения
        }

        private void btnChangePhone_Click(object sender, RoutedEventArgs e)
        {
            tbxNewPhone.Visibility = Visibility.Visible;
            btnConfirm.Visibility = Visibility.Visible;
            btnChangePhone.Visibility = Visibility.Hidden;
            btnLeave.Visibility = Visibility.Hidden;
        }

        private void tbxNewPhone_GotFocus(object sender, RoutedEventArgs e)
        {
            tbxNewPhone.Text = "";
        }


        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                try
                {
                    cmbClientsList.SelectedItem = (cmbClientsList.SelectedItem as Consultant).
                                                  ChangeClientData(cmbClientsList.SelectedItem as Client,
                                                                   tbxNewPhone.Text);
                    break;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка ввода номера {ex.Message}\n" +
                                     "Возможно, вы ввели пустую строку, либо не число, попробуйте еще раз.");
                    tbxNewPhone.Text = (cmbClientsList.SelectedItem as Consultant).Phone.ToString();
                }
            }
            tbxNewPhone.Text = "Введите номер...";
            tbxNewPhone.Visibility = Visibility.Hidden;
            btnConfirm.Visibility = Visibility.Hidden;
            btnChangePhone.Visibility = Visibility.Visible;
            btnSaveLeave.Visibility = Visibility.Visible;
            lbxClientData.ItemsSource = null;
            FillList();
        }

        private void btnSaveLeave_Click(object sender, RoutedEventArgs e)
        {
            data.SaveData(cmbClientsList.ItemsSource as ObservableCollection<Client>);
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void btnLeave_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
