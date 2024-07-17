using System.ComponentModel;
namespace smokersWPF
{
    public class Table : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public int[] onTable = { 0, 0, 0 };
        public Semaphore sem = new Semaphore(2, 4);
        public bool isSomeoneSmoking = false;


        
        public int res1 { get { return onTable[0]; } set { onTable[0] = value; OnPropertyChanged("res1"); } }
        public int res2 { get { return onTable[1]; } set { onTable[1] = value; OnPropertyChanged("res2"); } }
        public int res3 { get { return onTable[2]; } set { onTable[2] = value; OnPropertyChanged("res3"); } }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); }
        }
    }
}