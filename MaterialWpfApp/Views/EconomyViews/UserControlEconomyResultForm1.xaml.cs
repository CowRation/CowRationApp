using MaterialDesignThemes.Wpf.Transitions;
using MaterialWpfApp.ViewModels.Economy;
using MaterialWpfApp.ViewModels.GridView;
using MaterialWpfApp.ViewModels.Helper;
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

namespace MaterialWpfApp.Views.EconomyViews
{
    /// <summary>
    /// Логика взаимодействия для UserControlEconomyResultForm1.xaml
    /// </summary>
    public partial class UserControlEconomyResultForm1 : UserControl
    {
        public UserControlEconomyResultForm1(TransitionEffectKind transition, List<ExpensisGrid> expensis, DataMilk data)
        {
            InitializeComponent();
            this.DataContext = new ResultViewModel(expensis, data);
            TrainsitionigContentSlide.OpeningEffect = new TransitionEffect(transition, new TimeSpan(0, 0, 0, 0, 800));

        }
    }
}
