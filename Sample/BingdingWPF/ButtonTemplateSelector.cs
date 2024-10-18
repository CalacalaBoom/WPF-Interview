using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BingdingWPF
{
    public class ButtonTemplateSelector:DataTemplateSelector
    {

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var fe = container as FrameworkElement;
            var obj = item as People;
            DataTemplate dt = null;
            if (obj != null && fe != null)
            {
                if (obj.Age > 50)
                    dt = fe.FindResource("one") as DataTemplate;
                else
                    dt = fe.FindResource("two") as DataTemplate;

            }
            return dt;
        }
    }



    public class People
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
    }
}
