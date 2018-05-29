using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MaterialWpfApp.ViewModels.Helper
{
    class FeetGrid
    {
      
        private string name;

        private bool _value;
     
        private decimal? price;


        public int Id { get; set; }




        public string Name
        {
            get { return name; }
            set
            {
                if (name == value) return;
                name = value;
                OnPropertyChanged();
            }
        }


        public bool Value
        {
            get { return _value; }
            set
            {
                if (_value == value) return;
                _value = value;
                OnPropertyChanged();
            }
        }

        public decimal? Price
        {
            get { return price; }
            set
            {
                if (price == value) return;
                price = value;
                OnPropertyChanged();
            }
        }

      

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
