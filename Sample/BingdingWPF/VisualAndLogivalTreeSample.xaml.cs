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
using System.Windows.Shapes;

namespace BingdingWPF
{
    /// <summary>
    /// VisualAndLogivalTreeSample.xaml 的交互逻辑
    /// </summary>
    public partial class VisualAndLogivalTreeSample : Window
    {
        public VisualAndLogivalTreeSample()
        {
            InitializeComponent();

            var parent = VisualTreeHelper.GetParent(btn1);

            var childCount = VisualTreeHelper.GetChildrenCount(parent);

            for (int i = 0; i < childCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);

                Button button= child as Button;

                button.Content = "按钮1218";
            }


            var lparent = LogicalTreeHelper.GetParent(btn1);
            var children = LogicalTreeHelper.GetChildren(lparent);

            foreach (var child in children)
            {
                
            }
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
