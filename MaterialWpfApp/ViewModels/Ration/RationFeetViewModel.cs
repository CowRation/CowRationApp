using MaterialDesignThemes.Wpf.Transitions;
using MaterialWpfApp.Infrastructure;
using MaterialWpfApp.ViewModels.GridView;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using MaterialWpfApp.ViewModels.Helper;
using MaterialWpfApp.Views;
using System.Data.Entity.Migrations;

namespace MaterialWpfApp.ViewModels.Ration
{
    class RationFeetViewModel
    {
        #region Filds
        private ObservableCollection<FeetGrid> storages;
        private DataRation date;
        #endregion

        #region Method

        private void SavePriceProduct()
        {
            using (var db = new CowRationContext())
            {
                foreach (var item in storages)
                {

                    Korm korm = db.Korms.Where(k => k.Id_korm == item.Id).FirstOrDefault();
                    korm.Price_korm = item.Price;
     
                }
                db.SaveChanges();
            }
        }

        #endregion

        #region Constructors
        public RationFeetViewModel()
        {
            storages = new ObservableCollection<FeetGrid>();
            using (var db = new CowRationContext())
            {
                foreach (var item in db.Korms.ToList())
                {
                    storages.Add(new FeetGrid
                    {
                        Id = item.Id_korm,
                        Name = item.Name_korm,
                        Value = true,
                        Price = item.Price_korm
                    });
                }
            }
        }
        #endregion

        #region Property
        public ObservableCollection<FeetGrid> Storages
        {
            get { return storages; }
            set
            {
                storages = value;
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
                    SavePriceProduct();
                    MainWindow main = (MainWindow)Application.Current.MainWindow;
                    date = new DataRation();
                    date.Rations = new List<RationGrid>();
                    foreach (var item in storages)
                    {
                        if (item.Value)
                        {
                            date.Rations.Add(new RationGrid
                            {
                                Name = item.Name
                            });
                        }

                    }
                    main.MoveNextAsync(new UserControlMilkData(TransitionEffectKind.SlideInFromLeft, date));

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
