using MaterialWpfApp.ViewModels.GridView;
using System.Collections.ObjectModel;
namespace MaterialWpfApp.ViewModels
{
    class MainWindowViewModel
    {

        #region Filds
        private static double price;
        private static double quantity;
        private static int quantityCow = 360;
        #endregion

        #region Method

        #endregion

        #region Constructors
     
        #endregion

        #region Property
        public static double Price
        {
            get{ return price;}
            set
            {
                price = value;
            }
        }
        public static double Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
            }
        }
        public static int QuantityCow
        {
            get { return quantityCow; }
            set
            {
                quantityCow = value;
            }
        }
        public static ObservableCollection<RationGrid> Rations { get; set; }
        #endregion

        #region Command

        #endregion
    }
}
