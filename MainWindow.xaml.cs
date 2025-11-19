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

namespace kviz
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
        string nev;
        
        private void btn_nev_Click(object sender, RoutedEventArgs e)
        {
            nev = tbox_nev.Text;
            stack_start.Visibility = Visibility.Hidden;
            dock_quiz.Visibility = Visibility.Visible;
        }
    }
}