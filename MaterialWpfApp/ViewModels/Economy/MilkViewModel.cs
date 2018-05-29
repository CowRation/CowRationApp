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
    class MilkViewModel
    {
        #region Filds
        private DataMilk date;
        private int maxPercent = 100;
        #endregion

        #region Property
        public int ExtraPercent
        {
            get
            {
                return date.ExtraPercent;
            }
            set
            {
                if (value + HigherPercent + FirstPercent >= 101)
                {
                    return;
                }
               else
                {
                    date.ExtraPercent = value;
                }
               
                OnPropertyChanged();
            }
        }
        public int HigherPercent
        {
            get
            {
                return date.HigherPercent;
            }
            set
            {
                if (value  + ExtraPercent + FirstPercent >= 101)
                {
                    return;
                }
               else
                {
                    date.HigherPercent = value;

                }
                OnPropertyChanged();
            }
        }
        public int FirstPercent
        {
            get
            {
                return date.FirstPercent;
            }
            set
            {

                if (value + HigherPercent + ExtraPercent >= 101)
                {
                    return;
                }
                else
                {
                    date.FirstPercent = value;
                }
                OnPropertyChanged();
            }
        }


        public double ExtraPrice
        {
            get
            {
                return date.ExtraPrice;
            }
            set
            {
                date.ExtraPrice = value;
                OnPropertyChanged();
            }
        }
        public double HigherPrice
        {
            get
            {
                return date.HigherPrice;
            }
            set
            {
                date.HigherPrice = value;
                OnPropertyChanged();
            }
        }
        public double FirstPrice
        {
            get
            {
                return date.FirstPrice;
            }
            set
            {

                date.FirstPrice = value;
                OnPropertyChanged();
            }
        }
        public int MaxPerecent
        {
            get
            {
                return maxPercent;
            }
            set
            {
                maxPercent = value;
                OnPropertyChanged();
            }
        }



        public double FatMilk
        {
            get
            {
                return date.FatMilk;
            }
            set
            {
                date.FatMilk = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Method

        #endregion

        #region Constructors
        public MilkViewModel(DataMilk date)
        {
            this.date = date;
            this.date.HigherPercent = 10;
            this.date.FirstPercent = 10;
            this.date.ExtraPercent = 80;
            this.date.ExtraPrice = 0.67492;
            this.date.HigherPrice = 0.58121;
            this.date.FirstPrice = 0.53618;
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
                    main.MoveNextAsync(new UserControlArticle(TransitionEffectKind.SlideInFromLeft, date));
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
                    main.MoveNextAsync(new UserControlGeneral(TransitionEffectKind.SlideInFromRight,date));
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
