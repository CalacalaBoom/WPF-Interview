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
    /// LearnTemplate.xaml 的交互逻辑
    /// </summary>
    public partial class LearnTemplate : Window
    {
        public LearnTemplate()
        {
            InitializeComponent();

            this.DataContext = new LearnTemplateViewModel();

            List<People> peoples = new List<People>()
            {
                new People()
                {
                    Name="Nancy",
                    Age=18
                },
                new People()
                {
                    Name="Jack",
                    Age=15
                }
            };
            lb.ItemsSource = peoples;
            LoadData();
            listBox.ItemsSource = list;
        }

        public List<People> list { get; set; }
        private void LoadData()
        {
            Random r = new Random();
            list = new List<People>();
            for (int i = 0; i < 10; i++)
            {
                var person = new People()
                {
                    Name = "张三" + i,
                    Age = r.Next(100)
                };

                person.Sex = person.Age % 2 == 0 ? "男" : "女";
                list.Add(person);
            }
        }

        private void MyButtonMouseEvent(object sender, MouseEventArgs e)
        {
            if (MyButton.IsMouseOver)
            {
                VisualStateManager.GoToElementState(MyButton, "BlueState", true);
            }
            else
            {
                VisualStateManager.GoToElementState(MyButton, "OrangeState", true);
            }
        }
    }
}
