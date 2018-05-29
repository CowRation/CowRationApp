using MaterialWpfApp.ViewModels.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MaterialWpfApp.ViewModels.GridView;
using MaterialWpfApp.Infrastructure;
using System.Windows;
using MaterialDesignThemes.Wpf.Transitions;
using MaterialWpfApp.Views.RationViews;

namespace MaterialWpfApp.ViewModels.Ration
{
    class ResultRationViewModel
    {
        #region Fields

        private DataRation ration;
        private ObservableCollection<RationGrid> list;
        #endregion

        #region Properts
        public ObservableCollection<RationGrid> List
        {
            get
            {
                return list;
            }
        }

        public double Expenses
        {
            get { return MainWindowViewModel.Price; }
        }
        #endregion

        #region Constructors
        public ResultRationViewModel(DataRation ration)
        {
            MainWindowViewModel.Price = 0;
            this.ration = ration;
      
            list = new ObservableCollection<RationGrid>();

            foreach (var item in ration.Rations)
            {
                list.Add(item);
                MainWindowViewModel.Price += item.Cost;
            }

            MainWindowViewModel.Rations = list;
            
        }
        #endregion

        #region Commands

        public RelayCommand NextPageCommand
        {
            get
            {
                return new RelayCommand(c =>
                {
                    MainWindow main = (MainWindow)Application.Current.MainWindow;



                    main.MoveNextAsync(new UserControlResultFood(TransitionEffectKind.SlideInFromLeft, ration));
                    

                }
                    );
            }
        }

        #endregion
    }
}
