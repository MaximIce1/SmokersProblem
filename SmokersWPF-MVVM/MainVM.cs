using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Documents;
using SmokersWPF_MVVM.Classes;

namespace SmokersWPF_MVVM
{
    class MainVM : INotifyPropertyChanged
    {
        private string whosSmoking = "";
        private string agentLog = "";
        public event PropertyChangedEventHandler? PropertyChanged;
        public virtual void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        public byte Res1
        {
            get { return Table_.res1; }
            set { Table_.res1 = value; OnPropertyChanged(nameof(Res1)); }
        }
        public byte Res2
        {
            get { return Table_.res2; }
            set { Table_.res2 = value; OnPropertyChanged(nameof(Res2)); }
        }
        public byte Res3
        {
            get { return Table_.res3; }
            set { Table_.res3 = value; OnPropertyChanged(nameof(Res3)); }
        }
        public string WhosSmoking
        {
            get => whosSmoking;
            set {  whosSmoking = value; OnPropertyChanged(nameof(WhosSmoking)); }
        }
        public string AgentLog
        {
            get => agentLog;
            set { agentLog = value; OnPropertyChanged(nameof(AgentLog)); }
        }
    }
}
