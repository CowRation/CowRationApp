using MaterialDesignThemes.Wpf.Transitions;
using MaterialWpfApp.Infrastructure;
using MaterialWpfApp.ViewModels.Helper;
using MaterialWpfApp.Views;
using MaterialWpfApp.Views.RationViews;
using System.Linq;
using System.Windows;
using System.Collections.ObjectModel;
using MaterialWpfApp.ViewModels.GridView;

namespace MaterialWpfApp.ViewModels.Ration
{
    class LaboratoryViewModel
    {
        #region Fields
        private DataRation ration;
        private ObservableCollection<LaboratoryGrid> list;
        #endregion

        #region Property

        public ObservableCollection<LaboratoryGrid> List
        {
            get { return list; }
            set
            {
                list = value;
            }
        }

        #endregion

        #region Constructor
        public LaboratoryViewModel(DataRation ration)
        {
            this.ration = ration;

            list = new ObservableCollection<LaboratoryGrid>();

            using (var db = new CowRationContext())
            {

                foreach (var item in db.Korms.ToList())
                {

                    list.Add(new LaboratoryGrid
                    {
                        Name = item.Name_korm,
                        Sv = (db.FNutritionalCharacteristics.Where(k => k.Id_korm == item.Id_korm).Where(f => f.Id_index == 3).FirstOrDefault() ?? new FNutritionalCharacteristic () ).FValue,
                        Sp = (db.FNutritionalCharacteristics.Where(k => k.Id_korm == item.Id_korm).Where(f => f.Id_index == 4).FirstOrDefault() ?? new FNutritionalCharacteristic()).FValue,
                        Sg = (db.FNutritionalCharacteristics.Where(k => k.Id_korm == item.Id_korm).Where(f => f.Id_index == 5).FirstOrDefault() ?? new FNutritionalCharacteristic()).FValue,
                        Sk = (db.FNutritionalCharacteristics.Where(k => k.Id_korm == item.Id_korm).Where(f => f.Id_index == 6).FirstOrDefault() ?? new FNutritionalCharacteristic()).FValue
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
                    ration.LaboratoryValues = list.ToList();
                    MainWindow main = (MainWindow)Application.Current.MainWindow;
                    main.MoveNextAsync(new UserControlResultRation(TransitionEffectKind.SlideInFromLeft, ration));

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
                    main.MoveNextAsync(new UserControlMilkData(TransitionEffectKind.SlideInFromRight, new DataRation()));

                }
                    );
            }
        }
        #endregion
    }
}
