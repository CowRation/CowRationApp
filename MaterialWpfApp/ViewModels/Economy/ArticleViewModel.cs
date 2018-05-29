using MaterialDesignThemes.Wpf.Transitions;
using MaterialWpfApp.Infrastructure;
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
using System.Collections.ObjectModel;
using MaterialWpfApp.ViewModels.GridView;
using MaterialWpfApp.ViewModels.Helper;

namespace MaterialWpfApp.ViewModels.Economy
{
    class ArticleViewModel
    {
        #region Filds

        ObservableCollection<ExpensisGrid> list;
        private double expenses = 2046;
        private DataMilk date;
        #endregion

        #region Property
        public ObservableCollection<ExpensisGrid> List
        {
            get
            {
                return list;
            }
        }
        public double Expenses
        {
            get { return expenses; }
            set
            {
                expenses = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Method

        private List<ExpensisGrid> Calculate()
        {
            List<ExpensisGrid> l = new List<ExpensisGrid>();
            foreach (var item in List)
            {
                double result = item.Value * date.PreviewAverage / MainWindowViewModel.Quantity;
                  l.Add(new ExpensisGrid
                {
                    Article = item.Article,
                    Value = result
                });

            }
            l.Where(e => e.Article == "Корма").FirstOrDefault().Value =MainWindowViewModel.Price*MainWindowViewModel.QuantityCow;
            return l;
        }

        #endregion

        #region Constructors
        public ArticleViewModel(DataMilk date)
        {

            this.date = date;

            list = new ObservableCollection<ExpensisGrid>();
            using (var db = new CowRationContext())
            {
                foreach (var item in db.Expenses.ToList())
                {
                    double v = item.Value;
                    double p = v / expenses * 100;
                    list.Add(new ExpensisGrid
                    {
                        Article = item.Article,
                        Value = v,
                        Percenent = p
                    });
                }
            }
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
                   
                    main.MoveNextAsync(new UserControlEconomyResultForm1(TransitionEffectKind.SlideInFromLeft,Calculate(), date));
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
                    main.MoveNextAsync(new UserControlMilk(TransitionEffectKind.SlideInFromRight, date));
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
