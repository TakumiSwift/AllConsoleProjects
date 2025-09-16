using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace WPFTask1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void textBoxSentence_GotFocus(object sender, RoutedEventArgs e)
        {
            textBoxSentence.Text = string.Empty;
        }

        private void btnSplitWords_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Words> words = new ObservableCollection<Words>();
            listBoxWords.ItemsSource = words;
            string[] lines = textBoxSentence.Text.Split(' ');
            for (int i = 0;  i < lines.Length; i++)
            {
                Words w = new Words(lines[i]);
                words.Add(w);
            }
            listBoxWords.ItemsSource = words;
            textBoxSentence.Text = "Начните ввод предложения...";
        }

        private void btnMixWords_Click(object sender, RoutedEventArgs e)
        {            
            string[] lines = textBoxSentence.Text.Split(' ');
            lines.Reverse();
            string line = "";
            for (int i = lines.Length - 1; i >= 0; i--)
            {
                line += $"{lines[i]} \n";
            }
            labelReversedSentence.Content = line;
            textBoxSentence.Text = "Начните ввод предложения...";
        }

    }
}