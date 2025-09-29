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
    /// Логика взаимодействия для ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        
        private Database data = new Database("Manager");
        private string newWords;
        public ManagerWindow()
        {
            InitializeComponent();
        }

        private ObservableCollection<Words> FillList()
        {
            ObservableCollection<Words> words = new ObservableCollection<Words>();

            string[] lines = (cmbClientsList.SelectedItem as Manager).
                              PrintClient(cmbClientsList.SelectedItem as Manager).
                              Split(' ');

            for (int i = 0; i < lines.Length; i++)
            {
                Words w = new Words(lines[i]);
                words.Add(w);
            }
            return words;
        }

        private void cmbClientsList_DropDownOpened(object sender, EventArgs e)
        {
            cmbClientsList.ItemsSource = data.TakeData();
            lbxClientData.ItemsSource = null;
        }

        private void cmbClientsList_DropDownClosed(object sender, EventArgs e)
        {
            lbxClientData.ItemsSource = FillList();
            btnChangeData.Visibility = Visibility.Visible; // Итоговый вариант наполнения
        }

        private void btnChangeData_Click(object sender, RoutedEventArgs e)
        {
            tbkChangeData.Visibility = Visibility.Visible;
            lbxChangeData.Visibility = Visibility.Visible;
            btnConfirm.Visibility = Visibility.Visible;
            btnChangeData.Visibility = Visibility.Hidden;
            btnLeave.Visibility = Visibility.Hidden;
            lbxChangeData.ItemsSource = FillList();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                try
                {
                    cmbClientsList.SelectedItem = (cmbClientsList.SelectedItem as Manager).
                                                  ChangeClientData(cmbClientsList.SelectedItem as Client,
                                                                   newWords);
                    break;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка ввода {ex.Message}\n" +
                                     "Возможно, вы ввели пустую строку, либо не число "+
                                     "в поле номера телефона, попробуйте еще раз.");
                    lbxChangeData.ItemsSource = FillList();
                }
            }
            lbxChangeData.Visibility = Visibility.Hidden;
            btnConfirm.Visibility = Visibility.Hidden;
            tbkChangeData.Visibility = Visibility.Hidden;
            btnChangeData.Visibility = Visibility.Visible;
            btnSaveLeave.Visibility = Visibility.Visible;
            lbxClientData.ItemsSource = null;
            lbxClientData.ItemsSource = FillList();
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

        private void TextBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            var textBox = sender as TextBox;            
            if (textBox != null)
            {
                newWords += $"{textBox.Text} ";                
            }
        }
    }
}
