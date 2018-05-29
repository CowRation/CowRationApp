using MaterialWpfApp.ViewModels.Economy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf.Transitions;
using MaterialWpfApp.ViewModels.Helper;
using MaterialWpfApp.ViewModels.GridView;
using System.Collections.ObjectModel;

namespace MaterialWpfApp.Views.EconomyViews
{
    /// <summary>
    /// Логика взаимодействия для UserControlEconomyResultForm2.xaml
    /// </summary>
    public partial class UserControlEconomyResultForm2 : UserControl
    {
        public UserControlEconomyResultForm2(TransitionEffectKind transition, DataIncome income, DataMilk date, ObservableCollection<ExpensisGrid> list)
        {
            InitializeComponent();
            this.DataContext = new ResultViewModel(income, date,list);
            TrainsitionigContentSlide.OpeningEffect = new TransitionEffect(transition, new TimeSpan(0, 0, 0, 0, 800));
        }
    }
}
