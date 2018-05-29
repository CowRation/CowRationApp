using MaterialDesignThemes.Wpf.Transitions;
using MaterialWpfApp.Infrastructure;
using MaterialWpfApp.ViewModels.Helper;
using MaterialWpfApp.Views.RationViews;
using System;
using System.Linq;
using System.Windows;

namespace MaterialWpfApp.ViewModels.Ration
{
    class ResultFoodViewModel
    {
        #region Fields

        private DataRation ration;

        #endregion

        #region Property

        public double MilkFormation { get; set; }
        public double MilkXp { get; set; }
        public double MilkSv { get; set; }
        public double MilkCellulose { get; set; }
        public double MilkCa { get; set; }
        public double Humidity { get; set; }
        #endregion

        #region Commands

        public RelayCommand PreviewPageCommand
        {
            get
            {
                return new RelayCommand(c =>
                {
                    MainWindow main = (MainWindow)Application.Current.MainWindow;

                    DataRation ration = new DataRation();
                    ration.Rations = MainWindowViewModel.Rations.ToList();

                    main.MoveNextAsync(new UserControlResultRation(TransitionEffectKind.SlideInFromRight,ration));

                }
                    );
            }
        }

        #endregion

        #region Constructors

        public ResultFoodViewModel(DataRation ration)
        {
            this.ration = ration;

           

            using (var db=new CowRationContext())
            {
                //Молокообразование ЧЭЛ,кг
                double sumForm1 = 0;
                foreach (var item in ration.Rations)
                {
                    sumForm1 += item.Value * (db.NNutritionalCharacteristics.Include("Korm")
                        .Where(k => k.Korm.Name_korm == item.Name)
                        .Where(f => f.Id_index == 7).FirstOrDefault() ?? new NNutritionalCharacteristic())
                        .NValue;
                }
                MilkFormation = sumForm1 - ((0.528 * Math.Pow(535, 0.75) * 0.6 * 1.05) + 6);
                ////////////////////////

                //Молокообразование nXP,кг
                double sumForm2 = 0;
                foreach (var item in ration.Rations)
                {
                    sumForm2 += item.Value * (db.NNutritionalCharacteristics.Include("Korm")
                       .Where(k => k.Korm.Name_korm == item.Name)
                       .Where(f => f.Id_index == 13).FirstOrDefault() ?? new NNutritionalCharacteristic())
                       .NValue;
                }
                MilkXp = (sumForm2 - ((400 * 1.12) - 132))/84;
                //////////////////////

                //Потребление СВ,кг
                double sumSv = 0;
                string name;
                for (int i = 0; i <4; i++)
                {
                    name= ration.Rations[i].Name.Trim();
                    sumSv +=(ration.Rations[i].Value) * (db.FNutritionalCharacteristics.Include("Korm")
                       .Where(k => k.Korm.Name_korm == name)
                       .Where(f => f.Id_index == 3).FirstOrDefault() ?? new FNutritionalCharacteristic())
                       .FValue;
                }
                name = ration.Rations[5].Name.Trim();
                MilkSv =sumSv+ ((ration.Rations[5].Value) * (db.FNutritionalCharacteristics.Include("Korm")
                       .Where(k => k.Korm.Name_korm == name)
                       .Where(f => f.Id_index == 3).FirstOrDefault() ?? new FNutritionalCharacteristic())
                       .FValue);
                ////////////////////

                //Клетчатка в СВ
                double sumK1 = 0;
                double sumK2 = 0;
                foreach (var item in ration.Rations)
                {
                    sumK1 += item.Value * (db.FNutritionalCharacteristics.Include("Korm")
                        .Where(k => k.Korm.Name_korm == item.Name)
                        .Where(f => f.Id_index == 3).FirstOrDefault() ?? new FNutritionalCharacteristic())
                        .FValue;

                    sumK2 += item.Value * (db.FNutritionalCharacteristics.Include("Korm")
                       .Where(k => k.Korm.Name_korm == item.Name)
                       .Where(f => f.Id_index == 6).FirstOrDefault() ?? new FNutritionalCharacteristic())
                       .FValue;
                }
                MilkCellulose = (sumK1 * 100) / (sumK2 * 1000);
                //////////////////


                //Ca:P
                double sumCa1 = 0;
                double sumCa2 = 0;
                foreach (var item in ration.Rations)
                {
                    sumCa1 += item.Value * (db.NNutritionalCharacteristics.Include("Korm")
                       .Where(k => k.Korm.Name_korm == item.Name)
                       .Where(f => f.Id_index == 9).FirstOrDefault() ?? new NNutritionalCharacteristic())
                       .NValue;

                    sumCa2 += item.Value * (db.NNutritionalCharacteristics.Include("Korm")
                       .Where(k => k.Korm.Name_korm == item.Name)
                       .Where(f => f.Id_index == 10).FirstOrDefault() ?? new NNutritionalCharacteristic())
                       .NValue;
                }
                MilkCa = sumCa1 / sumCa2;
                /////////////////



                //Влажность кормосмеси
                double sumHumidity = 0;
                foreach (var item in ration.Rations)
                {
                    sumHumidity += item.Value * (db.FNutritionalCharacteristics.Include("Korm")
                       .Where(k => k.Korm.Name_korm == item.Name)
                       .Where(f => f.Id_index == 3).FirstOrDefault() ?? new FNutritionalCharacteristic())
                       .FValue;
                }
                //////////////////
                Humidity = 100 - (sumHumidity / ration.Rations.Sum(r => r.Value)) * 100;
            }
           
        }

        #endregion
    }
}
