using System.ComponentModel;

namespace BingdingWPF
{
    public class LearnTemplateViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChaged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private int myValue;

        public int MyValue
        {
            get { return myValue; }
            set
            {
                myValue = value;
                OnPropertyChaged(nameof(MyValue));
            }
        }

        public LearnTemplateViewModel()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(1000);
                    MyValue = new Random().Next(100);
                }
            });
        }
    }
}
