using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace SmokersWPF_MVVM.Classes
{
    class SmokerVM : INotifyPropertyChanged

    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        private bool smokingState;
        public bool SmokingState
        {
            get => smokingState;
            set { smokingState = value; OnPropertyChanged(); }
        }
    }       
}