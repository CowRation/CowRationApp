using MaterialDesignThemes.Wpf.Transitions;
using MaterialWpfApp.Infrastructure;
using MaterialWpfApp.ViewModels.GridView;
using MaterialWpfApp.ViewModels.Helper;
using MaterialWpfApp.Views.RationViews;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace MaterialWpfApp.ViewModels.Ration
{
    class MilkDataViewModel:NotifyPropertyChanged
    {
        #region Fields
        private DataRation ration;

        private int quantity=22;
        private double feet=3.8;
        private double protein=3.1;



        #endregion


        #region Propertes
        public int Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                OnPropertyChanged();
            }
        }
        public double Feet
        {
            get { return feet; }
            set
            {
                feet = value;
                OnPropertyChanged();
            }
        }
        public double Protein
        {
            get
            {
                return protein;
            }

            set
            {
                protein = value;
                OnPropertyChanged();
            }
        }
        #endregion


        #region Constructor
        public MilkDataViewModel(DataRation date)
        {
            this.ration = date;
        }
        #endregion

        #region Method
        private DataRation GetRation()
        {
            using (var db = new CowRationContext())
            {
                foreach (var item in db.RationCows.Include("Milk").Include("Korm").Where(r=>r.Milk.MilkQuantity==quantity).ToList())
                {
                    RationGrid date = ration.Rations.Where(r => r.Name == item.Korm.Name_korm).FirstOrDefault();
                    if (date!=null)
                    {
                        ration.Rations.Where(r => r.Name == item.Korm.Name_korm).FirstOrDefault().Value = item.Value;
                        ration.Rations.Where(r => r.Name == item.Korm.Name_korm).FirstOrDefault().Cost = item.Value * (double)item.Korm.Price_korm;

                    }
                }
            }
            return ration;
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
                    MainWindowViewModel.Quantity = quantity;
                    main.MoveNextAsync(new UserControlLaboratory(TransitionEffectKind.SlideInFromLeft, GetRation()));

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
                    main.MoveNextAsync(new UserControlRationFeed(TransitionEffectKind.SlideInFromRight));

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
