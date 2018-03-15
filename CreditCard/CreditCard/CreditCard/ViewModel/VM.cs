using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CreditCard.ViewModel
{
    public class VM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        decimal num;
        public VM()
        {
            Number = 123456789123;
        }
        public decimal Number
        {
            get { return num; }

            set
            {
                num = value;
                OnPropertyChanged("Number");
            }
        }
        public void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this,
              new PropertyChangedEventArgs(propertyName));
        }
    }
}
