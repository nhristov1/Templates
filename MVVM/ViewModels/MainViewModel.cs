using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MVVM.ViewModels
{
    class MainViewModel : INotifyPropertyChanged
    {
        private string _timeAndDateNow;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand PressUpdateTime { get; set; }

        public MainViewModel()
        {
            PressUpdateTime = new RelayButton(DoUpdateTime); 
        }

        private void DoUpdateTime()
        {
            TimeAndDate = DateTime.Now.ToString(); 
        }

        public string TimeAndDate
        { get
            {
                return _timeAndDateNow;
            }
            set
            {
                _timeAndDateNow = value;
                NotifyPropertyChanged(); 
            }
        }

        private void NotifyPropertyChanged([CallerMemberName]String info = null)
        {
            if (info != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info)); 
        }
    }
}
