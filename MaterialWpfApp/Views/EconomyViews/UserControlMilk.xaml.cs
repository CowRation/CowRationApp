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

namespace MaterialWpfApp.Views.EconomyViews
{
    /// <summary>
    /// Логика взаимодействия для UserControlMilk.xaml
    /// </summary>
    public partial class UserControlMilk : UserControl
    {
        public UserControlMilk(TransitionEffectKind transition, DataMilk date)
        {
            InitializeComponent();
            this.DataContext = new MilkViewModel(date);
            TrainsitionigContentSlide.OpeningEffect = new TransitionEffect(transition, new TimeSpan(0,0,0,0,800));


        }
    }
}
