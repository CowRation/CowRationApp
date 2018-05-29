using MaterialWpfApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MaterialWpfApp.ViewModels.GridView
{
   public class LaboratoryGrid:NotifyPropertyChanged
    {
        private string name;

        private double _sv;
        private double _sp;
        private double _sg;
        private double _sk;



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


        public double Sv
        {
            get { return _sv; }
            set
            {
                if (_sv == value) return;
                _sv = value;
                OnPropertyChanged();
            }
        }
        public double Sp
        {
            get { return _sp; }
            set
            {
                if (_sp == value) return;
                _sp = value;
                OnPropertyChanged();
            }
        }
        public double Sg
        {
            get { return _sg; }
            set
            {
                if (_sg == value) return;
                _sg = value;
                OnPropertyChanged();
            }
        }
        public double Sk
        {
            get { return _sk; }
            set
            {
                if (_sk == value) return;
                _sk = value;
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
