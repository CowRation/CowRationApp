using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MaterialWpfApp.ViewModels.GridView
{
   public  class ExpensisGrid
    {
        private int id;
        private string _article;

        private double _value;

        private double _percenent;


        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Article
        {
            get { return _article; }
            set
            {
                if (_article == value) return;
                _article = value;
                OnPropertyChanged();
            }
        }


        public double Value
        {
            get { return _value; }
            set
            {
                if (_value == value) return;
                _value = value;
                OnPropertyChanged();
            }
        }

        public double Percenent
        {
            get { return _percenent; }
            set
            {
                if (_percenent == value) return;
                _percenent = value;
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
