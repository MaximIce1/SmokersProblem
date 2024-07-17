using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace SmokersWPF_MVVM
{
    public class Table : INotifyPropertyChanged
    {
        public Semaphore sem = new(2, 4);
        public Table()
        {
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = "OnPropertyChanged")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private byte res1;
        public byte Res1 { get { return res1; } set { res1 = value; OnPropertyChanged(nameof(Res1)); } }
        private byte res2;
        public byte Res2 { get { return res2; } set { res2 = value; OnPropertyChanged(nameof(Res2)); } }
        private byte res3;
        public byte Res3 { get { return res3; } set { res3 = value; OnPropertyChanged(nameof(Res3)); } }
        private bool smokingState;
        public bool SmokingState { get { return smokingState; } set { smokingState = value; OnPropertyChanged(nameof(SmokingState)); } }
    }
}