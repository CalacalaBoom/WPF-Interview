using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BingdingWPF
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChaged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private string testValue;

        public string TestValue
        {
            get { return testValue; }
            set
            {
                testValue = value;
                OnPropertyChaged(nameof(TestValue));
            }
        }

        

        public ICommand EventCommand { get; set; }
        public ICommand SbCommand { get; set; }

        public MainViewModel()
        {
            EventCommand = new RelayCommand(OnEvent);
            SbCommand = new RelayCommand(
            _ => OnEvent(null),
            _ => IsLastCharEven()
        );

            Task.Run(async () =>
            {
                while (true) 
                {
                    TestValue = DateTime.Now.ToString();
                    await Task.Delay(1000);
                }
            });
        }

        private void OnEvent(object obj)
        {
            MessageBox.Show("事件触发");
        }

        private bool IsLastCharEven()
        {
            if (string.IsNullOrEmpty(TestValue)) return false;

            // 获取最后一个字符并判断是否为偶数
            char lastChar = TestValue[^1]; // 等价于 TestValue[TestValue.Length - 1]
            return char.IsDigit(lastChar) && (lastChar - '0') % 2 == 0;
        }
    }
}