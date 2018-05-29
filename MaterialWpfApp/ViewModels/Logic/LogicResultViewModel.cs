using MaterialDesignThemes.Wpf.Transitions;
using MaterialWpfApp.Infrastructure;
using MaterialWpfApp.Views.LogicViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using MaterialWpfApp.ViewModels.GridView;

namespace MaterialWpfApp.ViewModels.Logic
{
    class LogicResultViewModel
    {
        #region Filds
       
        #endregion

        #region Method

        #endregion

        #region Constructors
        public LogicResultViewModel(ObservableCollection<ProductGrid> collection, int i)
        {
            Storages = collection;

            MinDay = i;
        }
        #endregion

        #region Property
        public ObservableCollection<ProductGrid> Storages { get; set; }
        public int MinDay { get; set; }
        #endregion

        #region Command
        public RelayCommand PreviewPageCommand
        {
            get
            {
                return new RelayCommand(c =>
                {
                    MainWindow main = (MainWindow)Application.Current.MainWindow;
                    
                    main.MoveNextAsync(new UserControlLogic(TransitionEffectKind.SlideInFromRight));
                }
                    );
            }
        }
        #endregion
    }
}
