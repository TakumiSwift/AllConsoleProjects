using System.Collections.ObjectModel;
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

namespace WPFAppTask2
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

        private void btnConsultant_Click(object sender, RoutedEventArgs e)
        {
            ConsultantWindow cw = new ConsultantWindow();
            cw.Show();
            this.Close();
        }

        private void btnManager_Click(object sender, RoutedEventArgs e)
        {
            ManagerWindow mw = new ManagerWindow();
            mw.Show();
            this.Close();
        }
    }
}