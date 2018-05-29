using MaterialDesignThemes.Wpf.Transitions;
using MaterialWpfApp.Infrastructure;
using MaterialWpfApp.ViewModels.Helper;
using MaterialWpfApp.Views;
using MaterialWpfApp.Views.EconomyViews;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MaterialWpfApp.ViewModels.Economy
{
    class GeneralViewModel
    {
        #region Filds
        private DataMilk date;

        #endregion

        #region Property
        public int CountCow
        {
            get { return MainWindowViewModel.QuantityCow; }
            set
            {
                MainWindowViewModel.QuantityCow = value;
                OnPropertyChanged();
            }
        }
        public int PreviewQuantityMilk
        {
            get { return date.PreviewQuantityMilk; }
            set
            {
                date.PreviewQuantityMilk = value;
                OnPropertyChanged();
            }
        }
        public double PreviewAverage
        {
            get { return date.PreviewAverage; }
            set
            {
                date.PreviewAverage = value;
                OnPropertyChanged();
            }
        }
        public double MilkFatF
        {
            get
            {
                return date.FatMilkF;
            }
            set
            {
                date.FatMilkF = value;
                OnPropertyChanged();
            }
        }
       
        #endregion

        #region Method

        #endregion

        #region Constructors
        public GeneralViewModel(DataMilk date)
        {
            if (date==null)
            {
                date = new DataMilk ();
            }
            this.date = date;
            this.date.FatMilkF = 3.6;
            this.date.FatMilk = 3.6;
            MainWindowViewModel.QuantityCow = 360;
            this.date.PreviewQuantityMilk = 4636;
            this.date.PreviewAverage = 14.2;
        }
        #endregion

        #region Command

        public RelayCommand NextPageCommand
        {
            get
            {
                return new RelayCommand(c =>
                {
                    MainWindow main = (MainWindow)Application.Current.MainWindow;
                    main.MoveNextAsync(new UserControlMilk(TransitionEffectKind.SlideInFromLeft, date));
                }
                    );
            }
        }

        public RelayCommand PreviewPageCommand
        {
            get
            {
                return new RelayCommand(c =>
                {
                    MainWindow main = (MainWindow)Application.Current.MainWindow;
                }
                    );
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
