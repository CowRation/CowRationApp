using MaterialDesignThemes.Wpf.Transitions;
using MaterialWpfApp.Infrastructure;
using MaterialWpfApp.Views.LogicViews;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Collections.ObjectModel;
using MaterialWpfApp.ViewModels.GridView;

namespace MaterialWpfApp.ViewModels
{
    class LogicViewModel
    {

        #region Filds
        private ObservableCollection<ProductGrid> storages;
        private int day;
        private int minDay;
        #endregion

        #region Method

       

        private ObservableCollection<ProductGrid> Calculate()
        {
            var list = new ObservableCollection<ProductGrid>();
            var numbers = new List<int>();
            foreach (var item in Storages)
            {
                double col = MainWindowViewModel.Rations.Where(r => r.Name == item.Name).FirstOrDefault().Value;
                int d = (int)((item.Value*1000 - (col*360 * day)) / col);
                list.Add(new ProductGrid
                {
                    Name = item.Name,
                    Day = (int)((item.Value - (col * day)) / col)
                });


                numbers.Add((int)(item.Value / col));
                

            }

            day = numbers.Min();
            return list;
        }
        #endregion

        #region Constructors
        public LogicViewModel()
        {
            storages = new ObservableCollection<ProductGrid>();
            using (var db=new CowRationContext())
            {
                foreach (var item in db.Storages.Include("Korm").ToList())
                {
                    if (MainWindowViewModel.Rations.Where(r=>r.Name==item.Korm.Name_korm).FirstOrDefault()!=null)
                    {
                        storages.Add(new ProductGrid
                        {
                            Name = item.Korm.Name_korm,
                            Value = item.Quantity
                        });
                    }
                   
                }
            }
        }
        #endregion

        #region Property
        public ObservableCollection<ProductGrid> Storages
        {
            get { return storages; }
            set
            {
                storages = value;
                OnPropertyChanged();
            }
        }

        public int Day
        {
            get { return day; }
            set
            {
                day = value;
                OnPropertyChanged();
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

                    main.MoveNextAsync(new UserControlLogicResult(TransitionEffectKind.SlideInFromLeft, Calculate(), day));
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
