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

namespace WebServiceClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ServiceReference1.SampleServiceSoapClient client;
        public MainWindow()
        {
            InitializeComponent();
            client = new ServiceReference1.SampleServiceSoapClient(ServiceReference1.SampleServiceSoapClient.EndpointConfiguration.SampleServiceSoap12);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int x = int.Parse(a.Text);
            int y = int.Parse(b.Text);

            var result = client.AddAsync(x, y).Result;

            MessageBox.Show(result.ToString());
        }
    }
}