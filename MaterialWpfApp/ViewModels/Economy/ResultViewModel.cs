using MaterialDesignThemes.Wpf.Transitions;
using MaterialWpfApp.Infrastructure;
using MaterialWpfApp.ViewModels.GridView;
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
using MaterialWpfApp.ViewModels.Helper;

namespace MaterialWpfApp.ViewModels.Economy
{
    class ResultViewModel
    {
        #region Filds

        private ObservableCollection<ExpensisGrid> list;
        private double milkCount;
        private double expensesDay;

        private DataMilk data;
        private DataIncome income;

        #endregion

        #region Property
        public ObservableCollection<ExpensisGrid> List
        {
            get { return list; }
        }
        public double MilkCount
        {
            get
            {
                return milkCount;
            }
        }
        public double ExpensesDay
        {
            get
            {
                return expensesDay;
            }
        }

        public double Receipts
        {
            get
            {
                return income.Receipts;
            }
        }
        public double Income
        {
            get { return income.Income; }
        }
        public double Profitability
        {
            get { return income.Profitability; }
        }
        public double UnitProfitability
        {
            get { return income.UnitProfitability; }
        }
        #endregion

        #region Method

        #endregion

        #region Constructors
        public ResultViewModel(List<ExpensisGrid> expensis, DataMilk data)
        {
            this.data = data;
            expensesDay = expensis.Sum(p => p.Value);
            list = new ObservableCollection<ExpensisGrid>();
            foreach (var item in expensis)
            {
                item.Percenent = item.Value / expensesDay * 100;
                list.Add(item);
                

            }
            milkCount = (MainWindowViewModel.QuantityCow * MainWindowViewModel.Quantity)*data.FatMilkF/data.FatMilk*0.9;
        }

        public ResultViewModel(DataIncome income, DataMilk date, ObservableCollection<ExpensisGrid> list)
        {
            this.income = income;
            this.data = date;
            this.list = list;
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
                    double receip = MainWindowViewModel.Quantity * MainWindowViewModel.QuantityCow *
                        ((data.ExtraPrice * data.ExtraPercent / 100) + (data.HigherPrice * data.HigherPercent / 100) + (data.FirstPercent * data.FirstPrice /100));
                    DataIncome income = new DataIncome
                    {
                        Receipts = receip,
                        Income = receip - ExpensesDay,
                        Profitability = ((receip - ExpensesDay) / ExpensesDay)*100,
                        UnitProfitability= (((receip - ExpensesDay) / ExpensesDay )/ MainWindowViewModel.Quantity)*100
                        
                       
                    };

                    main.MoveNextAsync(new UserControlEconomyResultForm2(TransitionEffectKind.SlideInFromLeft, income, data,list));
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
                    main.MoveNextAsync(new UserControlEconomyResultForm1(TransitionEffectKind.SlideInFromRight, list.ToList(), data));
                });
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
